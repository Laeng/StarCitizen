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

namespace SCTool_Redesigned.Pages
{
    /// <summary>
    /// selectLang.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class selectLang : Page
    {
        public selectLang()
        {
            InitializeComponent();
        }

        private void applyBtn_Click(object sender, RoutedEventArgs e)
        {
            ((Windows.MainWindow)Application.Current.MainWindow).Phase++;
        }
    }
}
