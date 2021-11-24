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
using System.Data.SqlClient;
using System.Data;

namespace EngVocabApp
{
    /// <summary>
    /// Interaction logic for UpdateWordWindow.xaml
    /// </summary>
    public partial class UpdateWordWindow : Window
    {
        DataGrid mainWindowDataGridHandle;

        public UpdateWordWindow() {
            InitializeComponent();
        }
        public UpdateWordWindow(DataGridSelectedVocab in_data, DataGrid inDataGrid)
        {
            InitializeComponent();
            this.mainWindowDataGridHandle = inDataGrid;
            OriginalIDLabel.Content = (object)in_data.curVocab.Id;
            OriginalSpellingLabel.Content = in_data.curVocab.Vocab;
            OriginalMeaningLabel.Content = in_data.curVocab.Meaning;
        }

        private void UpdatedSpellingTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextBox curTextBox = (TextBox)sender;
                EngVocabApp.MainWindow.wordValidationGlobal(null, curTextBox.Text, isValidSpellingLabel);
            }
            catch (Exception)
            {
                return;
            }
            // EngVocabApp.MainWindow.wordValidationGlobal(null, )
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {       
            SQLcontrol.getInstance().ExecuteSQLNonQuery("UPDATE [dbo].[EngVocab] "
                + "SET Meaning = " + '\'' + UpdatedMeaningTextBox.Text.Replace("'", "''") + '\''
                + ", Vocab = " + '\'' + UpdatedSpellingTextBox.Text.Replace("'", "''") + '\''
                + ", UpdateDate = CURRENT_TIMESTAMP "
                + "WHERE Id = " + '\'' + OriginalIDLabel.Content.ToString() + '\'');
            this.mainWindowDataGridHandle.ItemsSource =
                SQLcontrol.getInstance().ExecuteSQLQuery("Select * from [dbo].[EngVocab]").AsDataView();
            this.Close();
        }
    }
}
