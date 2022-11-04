using System.Windows;

namespace Магазин_техники
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.ClassFrame.frameMain = FraimMainWin;
            FraimMainWin.Navigate(new Pages.PageReadInformation());
        }

        private void BtnGoPage1_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageAddTecnica(null));
        }

        private void BtnGoPage2_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageForDataGrid());
        }

        private void BtnGoPage3_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageForListBox());
        }

        private void BtnGoPage4_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageListViewTecnica()); 
        }

        private void BtnGoPage5_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageAddInfornationAboutTecnica());
        }

        private void BtnGoPageInformation_Click(object sender, RoutedEventArgs e)
        {
            FraimMainWin.Navigate(new Pages.PageReadInformation());
        }
    }
}
