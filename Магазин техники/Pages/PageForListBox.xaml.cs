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
    /// Логика взаимодействия для PageForListBox.xaml
    /// </summary>
    public partial class PageForListBox : Page
    {
        public PageForListBox()
        {
            InitializeComponent();
            LBoxTechica.ItemsSource = Classes.ClassContext.GetContext().T_Техника.ToList();
        }
    }
}
