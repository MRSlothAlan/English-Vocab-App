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
    /// Interaction logic for displayExamplesWindow.xaml
    /// </summary>
    public partial class displayExamplesWindow : Window
    {
        /*
         * A general class for displaying any non-editable word data.
         * For my own conveniences.
         * */
        private string currentVocabId;
        private int wordPad = 100;

        public displayExamplesWindow(string in_vocabId, string in_vocab)
        {
            InitializeComponent();
            this.currentVocabId = in_vocabId;
            vocabTextBlock.Text = in_vocab;
            System.Data.DataTable dtMeaning = SQLcontrol.getInstance()
                .ExecuteSQLQuery("Select * from [dbo].[EngVocabMeanings] " +
                "WHERE VocabId = " + '\'' + this.currentVocabId + '\'');
            foreach (System.Data.DataRow dtMeaningRow in (System.Data.DataRowCollection)dtMeaning.Rows)
            {
                displayWordMeaningsUserControl dat = new displayWordMeaningsUserControl();
                dat.wordFormLabel.Content = dtMeaningRow[2].ToString();
                string curMeaning = dtMeaningRow[3].ToString();
                for (int i = this.wordPad - 30; i < curMeaning.Length; i += this.wordPad - 30)
                {
                    curMeaning = curMeaning.Insert(i, "-\n");
                }
                dat.wordMeaningTextBlock.Text = curMeaning;
                this.vocabMeaningsStackPanel.Children.Add(dat);
            }
            System.Data.DataTable dtExample = SQLcontrol.getInstance()
               .ExecuteSQLQuery("Select * from [dbo].[EngVocabExamples] " +
               "WHERE VocabId = " + '\'' + this.currentVocabId + '\'');
            foreach (System.Data.DataRow dtExampleRow in (System.Data.DataRowCollection)dtExample.Rows)
            {
                TextBlock dat = new TextBlock();
                string curExample = dtExampleRow[2].ToString();
                for (int i = this.wordPad; i < curExample.Length; i += this.wordPad)
                {
                    curExample = curExample.Insert(i, "-\n");
                }
                dat.Text = curExample;
                dat.HorizontalAlignment = HorizontalAlignment.Left;
                dat.FontSize = 16;
                this.vocabExamplesStackPanel.Children.Add(dat);
            }
        }
    }
}
