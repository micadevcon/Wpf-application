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
    /// Логика взаимодействия для PageListViewVeggie.xaml
    /// </summary>
    public partial class PageListViewTecnica : Page
    {
        public PageListViewTecnica()
        {
            InitializeComponent();
            #region для AllTypeTecnica
            //временная переменная
            var AllTypeTecnica = Classes.ClassContext.GetContext().T_Вид_техники.ToList();
            AllTypeTecnica.Insert(0, new T_Вид_техники
            {
                тип_техники = "Все типы"
            });
            CbTypeTecnica.ItemsSource = AllTypeTecnica;
            CbTypeTecnica.SelectedIndex = 0;//при запуске выбран индекс=0
            #endregion
            var newInstanceTecnica = Classes.ClassContext.GetContext().T_Техника.ToList();
            LVTecnica.ItemsSource = newInstanceTecnica.OrderBy(p => p.модель).ToList();
        }

        private void CbTypeTecnica_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateListVeggie();
        }

        private void btnClearFilterAndSeach_Click(object sender, RoutedEventArgs e)
        {
            UpdateListVeggie();
        }
        /// <summary>
        /// Метод для создания объекта типа List
        /// включает поиск, сортировку и выборку методом фильтрации  Where
        /// </summary>
        private void UpdateListVeggie()
        {
            var UpdateList = Classes.ClassContext.GetContext().T_Техника.ToList();
            if (CbTypeTecnica.SelectedIndex > 0)
                UpdateList = UpdateList.Where(p => p.тип_техники.Contains(CbTypeTecnica.SelectedValue.ToString())).ToList();

            //сравнение выбранного значения из ComboBox c List
            UpdateList = UpdateList.Where(predicate => predicate.модель.ToLower().Contains(TbxSeachNameTecnica.Text.ToLower())).ToList();
            LVTecnica.ItemsSource = UpdateList.OrderBy(p => p.модель).ToList();//Сортировка по указанному атрибуту
            btnClearFilterAndSeach.Visibility = Visibility.Visible;
            // поиск с переводом строки к строчным буквам


            if (UpdateList.Count <= 0)
            {
                TextError.Visibility = Visibility.Visible;
                LVTecnica.Visibility = Visibility.Collapsed;

            }
            else
            {
                LVTecnica.Visibility = Visibility.Visible;
                TextError.Visibility = Visibility.Collapsed;
            }
            if(CbTypeTecnica.SelectedIndex == 0 && TbxSeachNameTecnica.Text == "")
                btnClearFilterAndSeach.Visibility = Visibility.Hidden;
        }

        private void TbxSeachNameTecnica_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateListVeggie();
        }

        private void btnClearFilterAndSeach_Click_1(object sender, RoutedEventArgs e)
        {
            var newInstanceTecnica = Classes.ClassContext.GetContext().T_Техника.ToList();
            LVTecnica.ItemsSource = newInstanceTecnica.OrderBy(p => p.модель).ToList();
            CbTypeTecnica.SelectedIndex = 0;
            TbxSeachNameTecnica.Text = "";
            btnClearFilterAndSeach.Visibility = Visibility.Hidden;
        }
    }
    
    
}
