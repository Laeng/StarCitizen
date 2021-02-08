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

namespace SCTool_Redesigned.Windows
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _PhaseNumber;
        PrefaceWindow _prologue;
        public MainWindow()
        {
            InitializeComponent();
            _PhaseNumber = 0;
            _prologue = new PrefaceWindow();
            Phase = 0;
        }

        public int Phase
        {
            get { return _PhaseNumber; }
            set
            {
                switch (value)
                {
                    case 0:     //launcher update
                        Hide();
                        _prologue.Content = new Pages.updateProgress();
                        _prologue.Show();
                        break;
                    case 1:     //select laucher language
                        Hide();
                        _prologue.Content = new Pages.selectLang();
                        _prologue.Show();
                        break;
                    case 2: //select patch Language
                        _prologue.Close();
                        Show();
                        frame_left.Content = null;
                        frame_right.Content = new Pages.selectPatchLang();
                        frame_all.Content = null;
                        logoCanvas.Visibility = Visibility.Visible;
                        logotitle.Visibility = Visibility.Visible;
                        InstallBtn.Visibility = Visibility.Visible;
                        InstallBtn.Visibility = Visibility.Hidden;
                        UninstallBtn.Visibility = Visibility.Hidden;
                        NextBtn.Visibility = Visibility.Hidden;
                        PrevBtn.Visibility = Visibility.Hidden;
                        break;
                    case 3: //main Install
                        frame_left.Content = null;
                        frame_right.Content = new Pages.mainNotes();
                        frame_all.Content = null;
                        logoCanvas.Visibility = Visibility.Visible;
                        logotitle.Visibility = Visibility.Visible;
                        InstallBtn.Visibility = Visibility.Visible;
                        UninstallBtn.Visibility = Visibility.Visible;
                        NextBtn.Visibility = Visibility.Hidden;
                        PrevBtn.Visibility = Visibility.Hidden;
                        break;
                    case 4: //select Dir
                        frame_left.Content = null;
                        frame_right.Content = null;
                        frame_all.Content = new Pages.selectDir();
                        logoCanvas.Visibility = Visibility.Hidden;
                        logotitle.Visibility = Visibility.Hidden;
                        InstallBtn.Visibility = Visibility.Hidden;
                        UninstallBtn.Visibility = Visibility.Hidden;
                        NextBtn.Visibility = Visibility.Visible;
                        NextBtn.Text = "다음";
                        PrevBtn.Visibility = Visibility.Visible;
                        PrevBtn.Text = "이전";
                        break;
                    case 5: //select Version
                        frame_left.Content = null;
                        frame_right.Content = null;
                        frame_all.Content = new Pages.selectVersion();
                        logoCanvas.Visibility = Visibility.Hidden;
                        logotitle.Visibility = Visibility.Hidden;
                        InstallBtn.Visibility = Visibility.Hidden;
                        UninstallBtn.Visibility = Visibility.Hidden;
                        NextBtn.Visibility = Visibility.Visible;
                        NextBtn.Text = "설치";
                        PrevBtn.Visibility = Visibility.Visible;
                        PrevBtn.Text = "이전";
                        break;
                    case 6: //installing?
                        frame_left.Content = null;
                        frame_right.Content = null;
                        frame_all.Content = new Pages.installProgress();
                        logoCanvas.Visibility = Visibility.Hidden;
                        logotitle.Visibility = Visibility.Hidden;
                        InstallBtn.Visibility = Visibility.Hidden;
                        UninstallBtn.Visibility = Visibility.Hidden;
                        NextBtn.Visibility = Visibility.Hidden;
                        PrevBtn.Visibility = Visibility.Visible;
                        PrevBtn.Text = "취소";
                        break;
                    case 7: //installComplete
                        frame_left.Content = null;
                        frame_right.Content = null;
                        frame_all.Content = new Pages.installComplete();
                        logoCanvas.Visibility = Visibility.Hidden;
                        logotitle.Visibility = Visibility.Hidden;
                        InstallBtn.Visibility = Visibility.Hidden;
                        UninstallBtn.Visibility = Visibility.Hidden;
                        NextBtn.Visibility = Visibility.Visible;
                        NextBtn.Text = "종료";

                        PrevBtn.Visibility = Visibility.Hidden;
                        break;
                    case 8:
                        Application.Current.Shutdown();
                        break;
                    default: throw new Exception(value.ToString()+" Phase is not exist");
                }
                //MessageBox.Show("Convert to Phase " + value.ToString());
                _PhaseNumber = value;
            }
        }

        private void InstallBtn_Click(object sender, RoutedEventArgs e)
        {
            Phase++;
        }

        private void NextBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Phase++;
        }

        private void PrevBtn_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Phase--;
        }
    }
}
