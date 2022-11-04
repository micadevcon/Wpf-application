using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Магазин_техники.Pages
{
    
    /// <summary>
    /// Логика взаимодействия для PageAddVegetable.xaml
    /// </summary>
    public partial class PageAddTecnica : Page
    {
        string addPathImg;
        string pathImgFortxb = "";
        private T_Техника instanceTechnica = new T_Техника();
        public PageAddTecnica(T_Техника t_Техника)
        {
            
            
            if (instanceTechnica != null)
                instanceTechnica = t_Техника;
            DataContext = instanceTechnica;
           
            InitializeComponent();
            #region переименование кнопки при переходе на редактирование
            if (instanceTechnica != null) 
            {
                cbTypetechnica.Text = instanceTechnica.тип_техники.ToString();
                cbTypeManuf.Text = instanceTechnica.производитель.ToString();
                btnDelete.Visibility = Visibility.Visible;
                btnAdd.Content = "Редактировать";
            }
            #endregion
            else
                btnDelete.Visibility = Visibility.Hidden;
            cbTypetechnica.ItemsSource = Classes.ClassContext.GetContext().T_Вид_техники.ToList(); 
            // Получение строк для Item
            cbTypeManuf.ItemsSource = Classes.ClassContext.GetContext().T_Производитель.ToList(); 
            // Получение строк для Item

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (instanceTechnica != null)
            {
                if (MessageBox.Show("Вы уверены?", "Save delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Classes.ClassContext.GetContext().T_Техника.Remove(instanceTechnica);
                    Classes.ClassContext.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    Classes.ClassFrame.frameMain.Navigate(new PageForDataGrid());
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            T_Техника texnic = new T_Техника()
            {

                T_Производитель = cbTypeManuf.SelectedItem as T_Производитель,
                T_Вид_техники = cbTypetechnica.SelectedItem as T_Вид_техники, //  
                цена = int.Parse(tbxPrice.Text), //
                модель = (tbxModel.Text).ToString(), //
                фото = addPathImg
            };
            if(instanceTechnica==null)
            {
                Classes.ClassContext.GetContext().T_Техника.Add(texnic);
            }
            
            Classes.ClassContext.GetContext().SaveChanges();
            MessageBox.Show("Данные добавлены");
        }

        private void btnAddImgTechica_Click(object sender, RoutedEventArgs e)
        {
            #region Работа с файлом
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //вызываем диалоговое окно для выбора изображения
            openFileDialog.ShowDialog();

            //сохраняем путь к выбранному файлу
            string filePath = openFileDialog.FileName.ToString();
            //для сохранения имени файла
            
            FileInfo file = new FileInfo(filePath);
            
            //путь относительно *.exe файла проекта
            string newPath = "..\\..\\imgTexnicaSource\\" + file.Name;
            //копируем файл в указанный ранее путь
            file.CopyTo(newPath, true);
            //строковая переменная для записи в БД
            addPathImg = "..\\imgTexnicaSource\\" + file.Name;
            //строковая переменная для записи пути файла в tbxForPathImgFortxb

            pathImgFortxb = addPathImg;
            #endregion
        }
    }
}
