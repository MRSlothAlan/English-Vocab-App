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
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        private int currentCorrectIdx;
        public QuizWindow()
        {
            InitializeComponent();
        }
        private void generateQuiz()
        {
            /*
             * Generate a sample quiz using SQL.
             * */
            System.Data.DataTable dtQuestionContent =
                SQLcontrol.getInstance().ExecuteSQLQuery(
                    @" SELECT Id, Vocab, Content, Meaning FROM 
	                        (SELECT *, ROW_NUMBER() OVER (PARTITION BY Id ORDER BY NEWID()) AS row_num FROM (	
		                        SELECT Id, Vocab, RES.Content, RES.Meaning FROM dbo.EngVocab
		                        JOIN (
			                        SELECT M.Meaning, E.VocabId, E.Content FROM dbo.EngVocabExamples AS E
			                        JOIN (
				                        SELECT Meaning, VocabId FROM dbo.EngVocabMeanings
			                        ) AS Ms
			                        ON E.VocabId = M.VocabId
			                        WHERE E.VocabId IN ('3ea5d2f1-0a91-4e0f-92ad-a896683368a6',
		                        'b5655eeb-adcb-4a9b-8aaf-36e60bb7421f',
		                        '5419704c-64e4-4a72-ac06-fa768c5e3382',
		                        'ef652d8a-08d3-4a8a-bf6f-02033293a863',
		                        'f1d7b999-3a07-458b-9abd-5858124e35bd')
		                        ) AS RES
		                        ON RES.VocabId = Id
	                        ) AS FINAL
                        ) AS FINALQUIZ
                        WHERE FINALQUIZ.row_num = 1
                        ORDER BY NEWID()    --WHAT A CODE!
                        "
                    );
            Random random = new Random();
            this.currentCorrectIdx = random.Next(0,4);

        }
    }
}
