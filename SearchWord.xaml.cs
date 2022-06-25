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

namespace EngVocabApp
{
    /// <summary>
    /// Interaction logic for SearchWord.xaml
    /// </summary>
    public partial class SearchWord : Window
    {
        public SearchWord()
        {
            InitializeComponent();
        }

        private void SearchWord_TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox curTextBox = (TextBox)sender;
            MainWindow.wordValidationGlobal(SearchSuggestedWord_ListView,
                curTextBox.Text, SearchWordValidationLabel);
        }

        private void SearchSuggestedWord_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SearchWord_TextBox.Text = (string)e.AddedItems[0];
                MainWindow.wordValidationGlobal(SearchSuggestedWord_ListView,
                    SearchWord_TextBox.Text, SearchWordValidationLabel);
            }
            catch (Exception)
            {
                Console.WriteLine("Skipping the copying of word");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string target_word = SearchWord_TextBox.Text;
            MainWindow.SelectSearchVocabGlobal(target_word);
            this.Close();
        }
    }
}
