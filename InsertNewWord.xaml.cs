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
            // first, naively check the fields
            // kinda borning but necessary.
            if (WordMeaningStackPanel.Children.Count <= 0 ||
                this.WordExampleStackPanel.Children.Count <= 0)
            {
                System.Windows.MessageBox.Show("[ERROR] Entry invalid: Please write at least one meaning and one example related to the vocabulary."
                    ,"Entry invalid", MessageBoxButton.OK);
                return;
            }
            // check spelling using word trie
            MainWindow.wordValidationGlobal(InsertSuggestedWords_ListView,
                this.InsertNewWord_TextBox.Text.ToLower(), InsertNewWordValidationLabel);
            bool proceed = false;
            if (InsertNewWordValidationLabel.Content.ToString().Equals("[NOT VALID]"))
            {
                System.Windows.MessageBoxResult res = System.Windows.MessageBox.Show(
                    "[ERROR] Entry invalid:  The "
                    , "Entry invalid", MessageBoxButton.OKCancel);
                if (res == MessageBoxResult.OK) { proceed = true; }
            }
            else { proceed = true; }
            if (proceed)
            {
                // check existing database of words.
                System.Data.DataTable dt = SQLcontrol.getInstance()
                    .ExecuteSQLQuery("Select * from [dbo].[EngVocab] WHERE Vocab = " + '\'' + InsertNewWord_TextBox.Text.ToLower() + '\'');
                if (dt.Rows.Count > 0)
                {
                    // update entries using many ids (@_@) / 

                }
                else
                {
                    // new data (@_@) / insert la.
                    for (int i = 0; i < WordMeaningStackPanel.Children.Count; i++)
                    {
                        vocabMeaningUserControl meaningData;
                        meaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[i];
                        // modify data.

                    }
                }
            }
        }
    }
}
