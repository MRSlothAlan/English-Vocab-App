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

        }

        private void AddWordMeaningButton_Press(object sender, RoutedEventArgs e)
        {
            vocabMeaningUserControl newVocabMeaningControl = new vocabMeaningUserControl();
            // WordMeaningListView.Items.Add((object)newVocabMeaningControl);
            WordMeaningStackPanel.Children.Add(newVocabMeaningControl);
        }
    }
}
