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
    /// Interaction logic for VocabExamplesUserControl.xaml
    /// </summary>
    public partial class VocabExamplesUserControl : UserControl
    {
        public VocabExamplesUserControl()
        {
            InitializeComponent();
        }

        private void WordExampleDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.StackPanel curObjPanel = (System.Windows.Controls.StackPanel)Parent;
            foreach (EngVocabApp.VocabExamplesUserControl element in curObjPanel.Children)
            {
                if (element.WordExampleDeleteButton == sender)
                {
                    curObjPanel.Children.Remove(element);
                    return;
                }
            }
        }
    }
}
