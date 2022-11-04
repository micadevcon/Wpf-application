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

namespace Магазин_техники.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddInfornationAboutTecnica.xaml
    /// </summary>
    public partial class PageAddInfornationAboutTecnica : Page
    {
        public PageAddInfornationAboutTecnica()
        {
            InitializeComponent();
            cbTypetechnica.ItemsSource = Classes.ClassContext.GetContext().T_Вид_техники.ToList();
            cbManuf.ItemsSource = Classes.ClassContext.GetContext().T_Производитель.ToList();
        }

        private void btnAddType_Click(object sender, RoutedEventArgs e)
        {
            T_Вид_техники texnic = new T_Вид_техники()
            {
                тип_техники = tbxType.Text.ToString(), 
            };

                Classes.ClassContext.GetContext().T_Вид_техники.Add(texnic);

            Classes.ClassContext.GetContext().SaveChanges();
            MessageBox.Show("Данные добавлены");
        }

        private void btnAddManuf_Click(object sender, RoutedEventArgs e)
        {
            T_Производитель texnic = new T_Производитель()
            {
                Производитель = tbxManuf.Text.ToString(), //  
            };

            Classes.ClassContext.GetContext().T_Производитель.Add(texnic);

            Classes.ClassContext.GetContext().SaveChanges();
            MessageBox.Show("Данные добавлены");
        }
    }
}
