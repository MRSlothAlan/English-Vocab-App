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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EngVocabApp
{
    /// <summary>
    /// Interaction logic for vocabMeaningUserControl.xaml
    /// </summary>
    public partial class vocabMeaningUserControl : UserControl
    {
        public vocabMeaningUserControl()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Search in parent window and delete entries based on button.
             * Each button has unique addresses and configurations.
             * */
            System.Windows.Controls.StackPanel curObjPanel = (System.Windows.Controls.StackPanel)Parent;
            foreach (EngVocabApp.vocabMeaningUserControl element in curObjPanel.Children)
            {
                if (element.CancelButton == sender)
                {
                    curObjPanel.Children.Remove(element);
                    return;
                }
            }
        }
    }
}
