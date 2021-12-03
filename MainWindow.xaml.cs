using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using InAppDictionary;

/*
 * Today's to-do:
 * Add datatable, meaning table and example table
 * Update the UI, make an insert UI.
 * */

namespace EngVocabApp
{
    /*
         * System classes
         * */
    public class EngVocab
    {
        public Guid Id { get; set; }
        public string Vocab { get; set; }
        public string Meaning { get; set; }
        public EngVocab()
        {
            this.Id = Guid.Empty;
            this.Vocab = "";
            this.Meaning = "";
        }
    }
    public class DataGridSelectedVocab
    {
        public EngVocab curVocab { get; set; }
        public DataGridSelectedVocab()
        {
            this.curVocab = new EngVocab();
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         *  =============== System parameters
         * */
        static ListView curGlobalListView;
        bool initFlag = false;
        DataGridSelectedVocab curSelectedVocab;
        Point curMousePointInGrid;
        Transform originalWordMenuTrans;
        static InAppDictionary.BasicTrie appVocabTrie;
        static DataGrid globalEngVocabDataGrid;
        /*
         * ================ System parameters 
         * */
        string connectionString = (string)System.Configuration.ConfigurationManager.AppSettings["dbConnStr"].ToString();

        // this is not needed anymore
        // private SqlConnection db;

        public static void SelectAllVocabGlobal()
        {
            globalEngVocabDataGrid.ItemsSource =
                SQLcontrol.getInstance().ExecuteSQLQuery("Select * from [dbo].[EngVocab]").AsDataView();
        }

        public static void wordValidationGlobal(ListView inSuggestionListView, string cur_word, Label inValidDisplayLabel)
        {
            // update: need a current handle for the textbox.
            // set visibility of menu into hidden first.
            if (inSuggestionListView == null)
                inSuggestionListView = curGlobalListView;
            inSuggestionListView.Visibility = Visibility.Hidden;
            cur_word = cur_word.ToLower();
            if (appVocabTrie.isValidWord(cur_word)) { inValidDisplayLabel.Content = "[VALID]"; }
            else
            {
                inValidDisplayLabel.Content = "[NOT VALID]";
                List<string> suggestions = appVocabTrie.findSimilarWords(cur_word);
                inSuggestionListView.Items.Clear();
                // int max_word_len = -1;
                for (int i = 0; i < suggestions.Count; i++)
                {
                    inSuggestionListView.Items.Add(suggestions[i]);
                    // max_word_len = Math.Max(max_word_len, suggestions[i].Length);
                }
                inSuggestionListView.FontSize = 15;
                inSuggestionListView.Visibility = Visibility.Visible;
            }
        }

        public MainWindow()
        {
            globalEngVocabDataGrid = engVocabDataGrid;
            this.initFlag = false;
            InitializeComponent();
            vocabTextBox.Text = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.originalWordMenuTrans = SelectWordMenu.RenderTransform;
            // load the trie and dictionary
            appVocabTrie = new InAppDictionary.BasicTrie((string)System.Configuration.ConfigurationManager.AppSettings["defaulDictionaryPath"].ToString());
            appVocabTrie.setDefaultDictionaryTrie();
            this.vocabTextBox.Text = "";
            this.vocabValidCheck_TextBox.Content = "";
            curGlobalListView = suggestedWords_ListView;
            SQLcontrol.createInstance(this.connectionString);
            SelectAllVocab();
            this.initFlag = true;
        }

        private void SelectAllVocab()
        {
            engVocabDataGrid.ItemsSource = 
                SQLcontrol.getInstance().ExecuteSQLQuery("Select * from [dbo].[EngVocab]").AsDataView();
            globalEngVocabDataGrid = engVocabDataGrid;
        }

        private void HideSelectWordMenu()
        {
            SelectWordMenu.Visibility = Visibility.Hidden;
            SelectWordMenu.RenderTransform = this.originalWordMenuTrans;
            SelectWordMenu.UpdateLayout();
            TranslateTransform backTrans = new TranslateTransform();
            backTrans.X = 0;
            backTrans.Y = 0;
            SelectWordMenu.RenderTransform = backTrans;
            SelectWordMenu.UpdateLayout();
        }

        private void EngVocabDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Need to handle the case such that no click was made.
            if (initFlag) {
                if (sender.GetType().ToString().Equals("System.Windows.Controls.DataGrid")) {
                    try
                    {
                        HideSelectWordMenu();
                        DataGrid data = (DataGrid)sender;
                        DataRowView selectedData = (DataRowView)data.CurrentCell.Item;
                        TranslateTransform wordTransform = new TranslateTransform();
                        wordTransform.X = this.curMousePointInGrid.X;
                        wordTransform.Y = this.curMousePointInGrid.Y;

                        if (SelectWordMenu.Height + this.curMousePointInGrid.Y >= EngVocabAppMainWindow.Height)
                        {
                            wordTransform.Y -= SelectWordMenu.Height;
                        }

                        try
                        {
                            EngVocabApp.EngVocabDataSet.EngVocabRow vocabData = (EngVocabApp.EngVocabDataSet.EngVocabRow)selectedData.Row;
                            this.curSelectedVocab = new DataGridSelectedVocab();
                            this.curSelectedVocab.curVocab.Id = (System.Guid)vocabData.Id;
                            this.curSelectedVocab.curVocab.Vocab = vocabData.Vocab;
                            this.curSelectedVocab.curVocab.Meaning = vocabData.Meaning;
                            Console.WriteLine("Coordinates: " + curMousePointInGrid.X.ToString() + "," + curMousePointInGrid.Y.ToString());
                            SelectWordMenu.RenderTransform = wordTransform; // TranslatePoint(wordPoint, engVocabDataGrid);
                            SelectWordMenu.UpdateLayout();
                            // SelectWordMenu.TransformToVisual(engVocabDataGrid);
                            SelectWordMenu.Visibility = Visibility.Visible;
                        }
                        catch (Exception)
                        {
                            Console.Write("[LOG] Fall back to general row class.");
                            DataRow vocabData = selectedData.Row;
                            this.curSelectedVocab = new DataGridSelectedVocab();
                            this.curSelectedVocab.curVocab.Id = (System.Guid)vocabData.ItemArray[0];
                            this.curSelectedVocab.curVocab.Vocab = (string)vocabData.ItemArray[1];
                            this.curSelectedVocab.curVocab.Meaning = (string)vocabData.ItemArray[2];
                            Console.WriteLine("Coordinates: " + curMousePointInGrid.X.ToString() + "," + curMousePointInGrid.Y.ToString());
                            SelectWordMenu.RenderTransform = wordTransform; // TranslatePoint(wordPoint, engVocabDataGrid);
                            SelectWordMenu.UpdateLayout();
                            // SelectWordMenu.TransformToVisual(engVocabDataGrid);
                            SelectWordMenu.Visibility = Visibility.Visible;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("[ERROR] Failed to update view, omitted");
                        HideSelectWordMenu();
                    }
                }
            }
        }

        private void ResetDBMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*
            * Get familar with C# stuff first, then the SQL logic (challenging) will be added.
            */
            MessageBoxResult res = System.Windows.MessageBox.Show(
                "[WARNING] Are you sure you want to CLEAR the database?", "Reset Database Confirmation",
                MessageBoxButton.OKCancel, MessageBoxImage.Hand, MessageBoxResult.No, System.Windows.MessageBoxOptions.None);
            if (res == MessageBoxResult.OK)
            {
                SQLcontrol.getInstance().ExecuteSQLNonQuery("TRUNCATE TABLE[dbo].[EngVocab]");
                SQLcontrol.getInstance().ExecuteSQLNonQuery("TRUNCATE TABLE[dbo].[EngVocabMeanings]");
                SQLcontrol.getInstance().ExecuteSQLNonQuery("TRUNCATE TABLE[dbo].[EngVocabExamples]");
                SelectAllVocab();
            }
        }

        private void FilterWordsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Filter the word selected. pop up a dialogue box to get requirements.
             */
        }

        private void WordQuizMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*
            * Create a new window for the quiz
            * Pass the set of words selected from the database.
            */
            Window QuizWindow = new QuizWindow();
            QuizWindow.Show();
        }

        private void SelectWordMenuQuit_Click(object sender, RoutedEventArgs e)
        {
            HideSelectWordMenu();
        }

        private void SelectWordMenuUpdateWord_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateExistingWordWindow = new UpdateExistingWord(this.curSelectedVocab.curVocab.Id.ToString(),
                                                                       this.curSelectedVocab.curVocab.Vocab.ToString());
            // Window UpdateWindow = new UpdateWordWindow(this.curSelectedVocab, engVocabDataGrid);
            UpdateExistingWordWindow.Show();
        }

        private void engVocabDateGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void engVocabDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
            this.curMousePointInGrid = e.GetPosition(EngVocabAppMainWindow);
        }

        private void SelectWordMenuDeleteWord_Click(object sender, RoutedEventArgs e)
        {
            SQLcontrol.getInstance().ExecuteSQLNonQuery(
                "DELETE FROM [dbo].[EngVocab] WHERE Id = " + '\'' + 
                this.curSelectedVocab.curVocab.Id.ToString().Replace("'", "''") + '\'' + "");
            SQLcontrol.getInstance().ExecuteSQLNonQuery(
                "DELETE FROM [dbo].[EngVocabMeanings] WHERE VocabId = " + '\'' +
                this.curSelectedVocab.curVocab.Id.ToString().Replace("'", "''") + '\'' + "");
            SQLcontrol.getInstance().ExecuteSQLNonQuery(
                "DELETE FROM [dbo].[EngVocabExamples] WHERE VocabId = " + '\'' + 
                this.curSelectedVocab.curVocab.Id.ToString().Replace("'", "''") + '\'' + "");
            SelectAllVocab();
            HideSelectWordMenu();
        }

        private void wordValidation()
        {
            // update: need a current handle for the textbox.
            // set visibility of menu into hidden first.
            suggestedWords_ListView.Visibility = Visibility.Hidden;
            string cur_word = this.vocabTextBox.Text.ToLower();
            if (appVocabTrie.isValidWord(cur_word)) { this.vocabValidCheck_TextBox.Content = "[VALID]"; }
            else
            {
                this.vocabValidCheck_TextBox.Content = "[NOT VALID]";
                List<string> suggestions = appVocabTrie.findSimilarWords(cur_word);
                suggestedWords_ListView.Items.Clear();
                // int max_word_len = -1;
                for (int i = 0; i < suggestions.Count; i++)
                {
                    suggestedWords_ListView.Items.Add(suggestions[i]);
                    // max_word_len = Math.Max(max_word_len, suggestions[i].Length);
                }
                suggestedWords_ListView.FontSize = 15;
                suggestedWords_ListView.Visibility = Visibility.Visible;
            }
        }

        private void vocabTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            this.wordValidation();
        }

        private void SuggestedWords_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // callback, fill in the textbox with the selected word
            // return the word / phrase returned.
            try
            {
                this.vocabTextBox.Text = (string)e.AddedItems[0]; // sender.Text;
                this.wordValidation();
            }
            catch (Exception)
            {

            }
        }

        private void InsertWordMenuItem_Click(object sender, RoutedEventArgs e)
        {
            InsertNewWord insertNewWordWindow = new InsertNewWord();
            insertNewWordWindow.Show();
        }

        private void EngVocabAppMainWindow_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            int i = 0;
        }

        private void EngVocabDataGrid_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            engVocabDataGrid.UnselectAllCells();
            SelectWordMenu.Visibility = Visibility.Hidden;
        }
    }
}
