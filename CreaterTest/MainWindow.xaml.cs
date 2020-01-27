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
        
        string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\CreaterTest\qqq.json");
        public int tempID;
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            AddRedTest adred = new AddRedTest();
            this.Hide();
            adred.ShowDialog();
            this.Show();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            TestList outjs = JsonConvert.DeserializeObject<TestList>(js);
            tempID = dgView.SelectedIndex;
            //tblTV.Text = outjs.testsq.FirstOrDefault(n => n.name == tempID).randomOrder.ToString();
            AddRedTest adred = new AddRedTest();
            adred.indexTMP = tempID;
            adred.move = "Редактирование";
            adred.Show();
            this.Hide();


        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            TestList outjs = JsonConvert.DeserializeObject<TestList>(js);
            outjs.testsq.RemoveAt(dgView.SelectedIndex);
            object testinput = new
            {
                testsqq = outjs
            };

            using (StreamWriter writer = File.CreateText(@"C:\Users\User\Desktop\q\qqq.json"))
            {
                string qq = JsonConvert.SerializeObject(testinput);
                writer.Write(outjs);
            }
            try
            {
                
                dgView.ItemsSource = outjs.testsq.Select(n => new { n.idTest, n.name, s = n.randomOrderTest.ToString(), q = n.randomOrderQuest.ToString() }).ToList();
            }
            catch
            {
                MessageBox.Show("Тесты не обнаружены", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
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

    }
}

