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

        }
    }
}
