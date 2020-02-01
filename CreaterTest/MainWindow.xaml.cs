using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Net.Sockets;
namespace CreaterTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        AddRedTest adred = new AddRedTest();
        string js = File.ReadAllText(@"C:\Users\User\Desktop\q\qqq.json");
        public int tempID;
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            adred.ShowDialog();
            this.Show();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            
            tempID = dgView.SelectedIndex;
            //tblTV.Text = outjs.testsq.FirstOrDefault(n => n.name == tempID).randomOrder.ToString();
            
            adred.indexTMP = tempID;
            adred.move = "Редактирование";
            adred.ShowDialog();
            this.Close();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string tt = (dgView.Columns[0].GetCellContent(dgView.SelectedItem) as TextBlock).Text;
                tbStroka.Text = tt;
            }
            catch
            {
                MessageBox.Show("Выберите тест для удаления", "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                try
                {
                Test outjs = JsonConvert.DeserializeObject<Test>(js);
                dgView.ItemsSource = outjs.questions.Select(n =>new { n.idQuestion, n.quest }).ToList() ;
                }
                catch
                {
                    MessageBox.Show("Тесты не обнаружены", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void DgView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

