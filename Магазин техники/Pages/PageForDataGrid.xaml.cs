using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Магазин_техники.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageForDataGrid.xaml
    /// </summary>
    public partial class PageForDataGrid : Page
    {
        public PageForDataGrid()
        {
            InitializeComponent();
            dgTechnica.ItemsSource = Classes.ClassContext.GetContext().T_Техника.ToList();// Получение строк для Item
            dgTechnica.AutoGenerateColumns = false;
            dgTechnica.IsReadOnly = true;
        }

        private void btnEditVeggie_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frameMain.Navigate(new PageAddTecnica((sender as Button).DataContext as T_Техника));
        }
    }
}
