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
using System.Windows.Shapes;

namespace CreaterTest
{
    /// <summary>
    /// Логика взаимодействия для AddRedTest.xaml
    /// </summary>
    public partial class AddRedTest : Window
    {
        public AddRedTest()
        {
            InitializeComponent();
        }
        public List<string> StatusList = new List<string> { "Active", "Inactive" };


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RadioButton_ColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox text = new TextBox();
            TextBox txt = new TextBox();
            txt.Width = 150;
            text.Width = 150;
            panelCloseQuestion.Children.Add(txt);
            panelCloseQuestion.Children.Add(text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTypeQuestion.Text == "Соответствие")
            {
                collapsedallpanel();
                panelSootv.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.Text == "Закрытый вопрос")
            {
                collapsedallpanel();
                panelCloseQuestion.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.Text == "Последовательность")
            {
                collapsedallpanel();
                panelSledovanie.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.Text == "Один вариант")
            {
                collapsedallpanel();
                panelOneVar.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.Text == "Несколько вариантов")
            {
                collapsedallpanel();
                panelLotVar.Visibility = Visibility.Visible;
            }
        }
        private void collapsedallpanel()
        {
            panelCloseQuestion.Visibility = Visibility.Collapsed;
            panelLotVar.Visibility = Visibility.Collapsed;
            panelOneVar.Visibility = Visibility.Collapsed;
            panelSledovanie.Visibility = Visibility.Collapsed;
            panelSootv.Visibility = Visibility.Collapsed;
        }

        private void btnGoHome_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypeQuestion.Text == "Соответствие")
            {
                collapsedallpanel();
                panelSootv.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.Text == "Закрытый вопрос")
            {
                collapsedallpanel();
                panelCloseQuestion.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.Text == "Последовательность")
            {
                collapsedallpanel();
                panelSledovanie.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.Text == "Один вариант")
            {
                collapsedallpanel();
                panelOneVar.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.Text == "Несколько вариантов")
            {
                collapsedallpanel();
                panelLotVar.Visibility = Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
