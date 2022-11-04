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
    /// Логика взаимодействия для PageReadInformation.xaml
    /// </summary>
    public partial class PageReadInformation : Page
    {
        public PageReadInformation()
        {
            InitializeComponent();
            dgTechnica.ItemsSource = Classes.ClassContext.GetContext().count().ToList();
            dgTechnica.AutoGenerateColumns = false;
            dgTechnica.IsReadOnly = true;
        
    }
    }
}
