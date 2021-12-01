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
    public partial class UpdateExistingWord : Window
    {
        private string existingVocabId;

        public UpdateExistingWord(string in_VocabId_str, string in_vocab)
        {
            InitializeComponent();
            existingVocabulary_TextBlock.Text = in_vocab;
            this.existingVocabId = in_VocabId_str;
            System.Data.DataTable dtMeaning = SQLcontrol.getInstance()
                .ExecuteSQLQuery("Select * from [dbo].[EngVocabMeanings] " +
                "WHERE VocabId = " + '\'' + this.existingVocabId + '\'');
            foreach (System.Data.DataRow dtMeaningRow in (System.Data.DataRowCollection)dtMeaning.Rows)
            {
                vocabMeaningUserControl dat = new vocabMeaningUserControl();
                dat.MeaningTextBox.Text = dtMeaningRow[3].ToString();
                dat.WordFormTextBox.Text = dtMeaningRow[2].ToString();
                WordMeaningStackPanel.Children.Add(dat);
            }
            System.Data.DataTable dtExample = SQLcontrol.getInstance()
                .ExecuteSQLQuery("Select * from [dbo].[EngVocabExamples] " +
                "WHERE VocabId = " + '\'' + this.existingVocabId + '\'');
            foreach (System.Data.DataRow dtExampleRow in (System.Data.DataRowCollection)dtExample.Rows)
            {
                VocabExamplesUserControl dat = new VocabExamplesUserControl();
                dat.WordExampleTextBox.Text = dtExampleRow[2].ToString();
                WordExampleStackPanel.Children.Add(dat);
            }
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

        private void UpdateExistingWordSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < WordMeaningStackPanel.Children.Count;)
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
                    , "Entry invalid", MessageBoxButton.OK);
                return;
            }
            System.Windows.MessageBoxResult res = System.Windows.MessageBox.Show(
                    "[WARNING] Are you sure you want to proceed?"
                    , "Proceed", MessageBoxButton.OKCancel);
            if (res == MessageBoxResult.OK)
            {
                SQLcontrol.getInstance().ExecuteSQLNonQuery(
                    "DELETE FROM [dbo].[EngVocabMeanings] " +
                    "WHERE VocabId = " + '\'' + this.existingVocabId + '\'' + "");
                SQLcontrol.getInstance().ExecuteSQLNonQuery(
                    "DELETE FROM [dbo].[EngVocabExamples] " +
                    "WHERE VocabId = " + '\'' + this.existingVocabId + '\'' + "");
                for (int i = 0; i < WordMeaningStackPanel.Children.Count; i++)
                {
                    vocabMeaningUserControl meaningData;
                    meaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[i];
                    SQLcontrol.getInstance().ExecuteSQLNonQuery(
                        "INSERT INTO [dbo].[EngVocabMeanings] ([Id], [VocabId], [WordForm], [Meaning]) " +
                        "VALUES ( NEWID(), "
                     + '\'' + this.existingVocabId + '\'' + ","
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
                     + '\'' + this.existingVocabId + '\'' + ","
                     + '\'' + exampleData.WordExampleTextBox.Text.Replace("'", "''") + '\'' + ")");
                }
                vocabMeaningUserControl firstMeaningData;
                firstMeaningData = (vocabMeaningUserControl)WordMeaningStackPanel.Children[0];
                SQLcontrol.getInstance().ExecuteSQLNonQuery(
                    "UPDATE [dbo].[EngVocab] "
                    + "SET Meaning = " + '\'' + firstMeaningData.MeaningTextBox.Text.Replace("'", "''") + '\'' + ","
                    + "UpdateDate = CURRENT_TIMESTAMP "
                    + "WHERE Id = " + '\'' + this.existingVocabId + '\'');
                MainWindow.SelectAllVocabGlobal();
            }
            else
            {
                return;
            }
        }
    }
}
