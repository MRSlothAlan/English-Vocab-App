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
using System.Data;

namespace EngVocabApp
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private int currentCorrectIdx;
        private string cur_selection;
        private System.Data.DataTable dtQuestionContent;

        public QuizWindow()
        {
            InitializeComponent();
            generateQuiz();
        }
        private void generateQuiz()
        {
            /*
             * Generate a sample quiz using SQL.
             * Currently, the old version of the code does not include the newly added dts
             * After modifying all the values, the quiz function will work.
             * in the meantime, revise the vocab.
             * */
            this.cur_selection = "";
            this.dtQuestionContent = 
                SQLcontrol.getInstance().ExecuteSQLQuery(
                    @" SELECT Id, Vocab, Content, Meaning, WordForm FROM 
	                        (SELECT *, ROW_NUMBER() OVER (PARTITION BY Id ORDER BY NEWID()) AS row_num FROM (	
		                        SELECT Id, Vocab, RES.Content, RES.Meaning, RES.WordForm FROM dbo.EngVocab
		                        JOIN (
			                        SELECT M.Meaning, M.WordForm, E.VocabId, E.Content FROM dbo.EngVocabExamples AS E
			                        JOIN (
				                        SELECT Meaning, VocabId, WordForm FROM dbo.EngVocabMeanings
			                        ) AS M
			                        ON E.VocabId = M.VocabId
			                        WHERE E.VocabId IN (SELECT TOP 5 Id FROM dbo.EngVocab ORDER BY NEWID())
		                        ) AS RES
		                        ON RES.VocabId = Id
	                        ) AS FINAL
                        ) AS FINALQUIZ
                        WHERE FINALQUIZ.row_num = 1
                        ORDER BY NEWID()    
                        "
                    );
            Random random = new Random();
            // pick an index as correct ans
            this.currentCorrectIdx = random.Next(0,4);
            QuizVocabTextBlock.Text = (string)dtQuestionContent.Rows[currentCorrectIdx][1];
            System.Data.DataTable dtForUserSelection = new System.Data.DataTable();
            DataColumn dcToAdd = new DataColumn("Meaning");
            DataColumn dcToAddWordForm = new DataColumn("WordForm");

            dtForUserSelection.Columns.Add(dcToAddWordForm);
            dtForUserSelection.Columns.Add(dcToAdd);

            foreach (System.Data.DataRow dr in dtQuestionContent.Rows)
            {
                DataRow dataRow = dtForUserSelection.NewRow();
                dataRow["WordForm"] = (string)dr[4];
                dataRow["Meaning"] = (string)dr[3];
                dtForUserSelection.Rows.Add(dataRow);
            }
            DataView resDataView = dtForUserSelection.AsDataView();
            this.PossibleMeaningsDataGrid.ItemsSource = dtForUserSelection.AsDataView();
        }

        private void QuizWindowSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.cur_selection.Equals(
                (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][3]))
            {
                MessageBox.Show(
@"
@_@ GOOD! THAT's correct.


The word {} means: [] in the form <>.


Example sentence is : ()."
                        .Replace("{}", QuizVocabTextBlock.Text)
                        .Replace("[]", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][3])
                        .Replace("()", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][2])
                        .Replace("<>", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][4]),
                    "CORRECT ANSWER (@_@) /''", MessageBoxButton.OK);
                generateQuiz();
            }
            else
            {
                MessageBox.Show(
@"
T_T NO! THAT's WRONG.


The word {} actually means: [] in the form <>.


Example sentence is : ()."
                        .Replace("{}", QuizVocabTextBlock.Text)
                        .Replace("<>", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][4])
                        .Replace("[]", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][3])
                        .Replace("()", (string)this.dtQuestionContent.Rows[this.currentCorrectIdx][2]),
                    "WRONG ANSWER (T_T)", MessageBoxButton.OK);
                generateQuiz();
            }
        }

        private void PossibleMeaningsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView curR = (DataRowView)e.AddedItems[0];
                this.cur_selection = (string)curR.Row.ItemArray[1];
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
            catch (Exception)
            {
                throw new Exception("Update grid caused error");
            }
        }
    }
}
