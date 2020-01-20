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

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            AddRedTest adred = new AddRedTest();
            adred.Show();
            this.Hide();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("qq");
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("qq");
        }
    }
}
