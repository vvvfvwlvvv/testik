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
        string js = File.ReadAllText(@"C:\Users\User\Desktop\q\qqq.json");
        public string tempID;
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            AddRedTest adred = new AddRedTest();
            adred.Show();
            this.Hide();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            TestList outjs = JsonConvert.DeserializeObject<TestList>(js);
            tempID = (dgView.Columns[0].GetCellContent(dgView.SelectedItem) as TextBlock).Text;
            tblTV.Text = outjs.testsq.FirstOrDefault(n => n.name == tempID).randomOrder.ToString();
            AddRedTest adred = new AddRedTest();
            adred.indexTMP = tempID;
            adred.Show();
            this.Hide();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("qq");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TestList outjs = JsonConvert.DeserializeObject<TestList>(js);
            try
            {
                dgView.ItemsSource = outjs.testsq.Select(n => new { n.name, s = n.randomOrder.ToString() }).ToList();
            }
            catch
            {
                MessageBox.Show("Тесты не обнаружены", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}

