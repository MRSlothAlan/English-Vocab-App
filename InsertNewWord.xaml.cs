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
using System.Windows.Shapes;

/*
 * Users can add multiple meanings / examples into the database
 * a script to manually update the existing database is needed as well
 * focus on that first.
 * */

namespace EngVocabApp
{
    /// <summary>
    /// Interaction logic for InsertNewWord.xaml
    /// </summary>
    public partial class InsertNewWord : Window
    {
        public InsertNewWord()
        {
            InitializeComponent();
        }

        private void InsertSuggestedWords_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                InsertNewWord_TextBox.Text = (string)e.AddedItems[0]; // sender.Text;
                MainWindow.wordValidationGlobal(InsertSuggestedWords_ListView,
                                        InsertNewWord_TextBox.Text, InsertNewWordValidationLabel);
            }
            catch (Exception)
            {
                // a customized logger class will be made, users can undo operations made before.
                // including database operations.
                Console.WriteLine("Skipping the copying of word");
            }
            
        }

        private void InsertNewWord_TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox curTextBox = (TextBox)sender;
            MainWindow.wordValidationGlobal(InsertSuggestedWords_ListView,
                                                curTextBox.Text, InsertNewWordValidationLabel);
        }

        private void AddWordMeaningButton_Press(object sender, RoutedEventArgs e)
        {
            vocabMeaningUserControl newVocabMeaningControl = new vocabMeaningUserControl();
            WordMeaningStackPanel.Children.Add(newVocabMeaningControl);
        }

        private void AddWordExampleButton_Press(object sender, RoutedEventArgs e)
        {
            VocabExamplesUserControl newVocabExamplesUserControl = new VocabExamplesUserControl();
            WordExampleStackPanel.Children.Add(newVocabExamplesUserControl);
        }

        private void InsertNewWordSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Insert values into databases accordingly
             * */
            string insertedNewWord = this.InsertNewWord_TextBox.Text.ToLower().Replace("'", "''");
            if (insertedNewWord.Length == 0)
            {
                System.Windows.MessageBox.Show("[ERROR] Entry invalid: Please enter the vocabulary."
                    , "Entry invalid", MessageBoxButton.OK);
                return;
            }
            for (int i = 0; i < WordMeaningStackPanel.Children.Count; )
            {
                vocabMeaningUserControl meaningData;
                meaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[i];
                if (meaningData.MeaningTextBox.Text.Replace(" ", "").Length == 0)
                {
                    WordMeaningStackPanel.Children.RemoveAt(i);
                    if (i >= WordMeaningStackPanel.Children.Count) { break; }
                }
                else { i++; }
            }
            for (int i = 0; i < WordExampleStackPanel.Children.Count;)
            {
                VocabExamplesUserControl exampleData;
                exampleData = (VocabExamplesUserControl)WordExampleStackPanel.Children[i];
                if (exampleData.WordExampleTextBox.Text.Replace(" ", "").Length == 0)
                {
                    WordExampleStackPanel.Children.RemoveAt(i);
                    if (i >= WordExampleStackPanel.Children.Count) { break; }
                }
                else { i++; }
            }

            if (WordMeaningStackPanel.Children.Count <= 0 ||
                this.WordExampleStackPanel.Children.Count <= 0)
            {
                System.Windows.MessageBox.Show("[ERROR] Entry invalid: Please write at least one meaning and one example related to the vocabulary."
                    ,"Entry invalid", MessageBoxButton.OK);
                return;
            }
            MainWindow.wordValidationGlobal(InsertSuggestedWords_ListView,
                insertedNewWord, InsertNewWordValidationLabel);
            bool proceed = false;
            if (InsertNewWordValidationLabel.Content.ToString().Equals("[NOT VALID]"))
            {
                System.Windows.MessageBoxResult res = System.Windows.MessageBox.Show(
                    "[WARNING] Entry invalid:  The new word might be unconventional. Continue?"
                    , "Entry invalid", MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK) { proceed = true; }
            }
            else { proceed = true; }
            if (proceed)
            {
                string vocabGuidStr = "";
                vocabMeaningUserControl firstMeaningData;
                firstMeaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[0];

                // check existing database of words.
                System.Data.DataTable dt = SQLcontrol.getInstance()
                    .ExecuteSQLQuery("Select * from [dbo].[EngVocab] WHERE Vocab = " + '\'' + insertedNewWord + '\'');
                if (dt.Rows.Count > 0)
                {
                    // prompt: will ERASE all existing definitions and update the meanings and examples.
                    System.Windows.MessageBoxResult res = System.Windows.MessageBox.Show(
                        "[WARNING] The word " + '\'' + insertedNewWord + '\'' + " already exist in the database. " +
                        "New meanings and examples will be inserted into the database (You can modify those entries in a separate window).\n" +
                        "Continue?"
                        , "Duplicated entry", MessageBoxButton.OKCancel);
                    if (res == MessageBoxResult.Cancel) { return; }
                    SQLcontrol.getInstance().ExecuteSQLNonQuery("UPDATE [dbo].[EngVocab] "
                        + "SET Meaning = " + '\'' + firstMeaningData.MeaningTextBox.Text.Replace("'", "''") + '\'' + ","
                        + "UpdateDate = CURRENT_TIMESTAMP "
                        + "WHERE Vocab = " + '\'' + insertedNewWord + '\'');
                    System.Data.DataRow curVocabData = (System.Data.DataRow)dt.Rows[0];
                    System.Guid vocabGuid = (System.Guid)curVocabData.ItemArray[0];
                    vocabGuidStr = vocabGuid.ToString();
                }
                else
                {
                    // new data (@_@) / insert la
                    SQLcontrol.getInstance().ExecuteSQLNonQuery("INSERT INTO [dbo].[EngVocab] ([Id], [Vocab], [Meaning], [InsertDate], [UpdateDate]) " +
                        "VALUES ( NEWID(), " + '\'' + insertedNewWord + '\'' + ","
                     + '\'' + firstMeaningData.MeaningTextBox.Text.Replace("'", "''") + '\'' + ","
                     + "CURRENT_TIMESTAMP" + ","
                     + "CURRENT_TIMESTAMP" + ")");
                    dt = SQLcontrol.getInstance()
                        .ExecuteSQLQuery("Select * from [dbo].[EngVocab] WHERE Vocab = " + '\'' + insertedNewWord + '\'');
                    System.Data.DataRow curVocabData = (System.Data.DataRow)dt.Rows[0];
                    System.Guid vocabGuid = (System.Guid)curVocabData.ItemArray[0];
                    vocabGuidStr = vocabGuid.ToString();
                }
                // vocabBuidStr received.
                // insert data, meaning and examples @_@ / 
                for (int i = 0; i < WordMeaningStackPanel.Children.Count; i++)
                {
                    vocabMeaningUserControl meaningData;
                    meaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[i];
                    SQLcontrol.getInstance().ExecuteSQLNonQuery(
                        "INSERT INTO [dbo].[EngVocabMeanings] ([Id], [VocabId], [WordForm], [Meaning]) " +
                        "VALUES ( NEWID(), " 
                     + '\'' + vocabGuidStr + '\'' + ","
                     + '\'' + meaningData.WordFormTextBox.Text.ToLower().Replace("'", "''") + '\'' + ","
                     + '\'' + meaningData.MeaningTextBox.Text.Replace("'", "''") + '\'' + ")");
                }
                for (int i = 0; i < WordExampleStackPanel.Children.Count; i++)
                {
                    VocabExamplesUserControl exampleData;
                    exampleData = (VocabExamplesUserControl)WordExampleStackPanel.Children[i];
                    SQLcontrol.getInstance().ExecuteSQLNonQuery(
                        "INSERT INTO [dbo].[EngVocabExamples] (Id, VocabId, Content) " +
                        "VALUES ( NEWID(), " 
                     + '\'' + vocabGuidStr + '\'' + ","
                     + '\'' + exampleData.WordExampleTextBox.Text.Replace("'", "''") + '\'' + ")");
                }
                MainWindow.SelectAllVocabGlobal();
            }
        }
    }
}
