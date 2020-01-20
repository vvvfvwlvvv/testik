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
using System.Windows.Shapes;
using Newtonsoft.Json;

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
        public List<string> StatusList = new List<string> { "Один вариант", "Несколько вариантов", "Соответствие", "Закрытый вопрос", "Последовательность" };

        public object JsonSerializer { get; private set; }

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
            gridCloseQuestion.Children.Add(txt);
            gridCloseQuestion.Children.Add(text);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            tbFormulirovka.Text = "qq";
            if (cbTypeQuestion.SelectedItem.ToString() == "Соответствие")
            {
                collapsedallpanel();
                gridSootv.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос")
            {
                collapsedallpanel();
                gridCloseQuestion.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Последовательность")
            {
                collapsedallpanel();
                gridSledovanie.Visibility = Visibility.Visible;

            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Один вариант")
            {
                collapsedallpanel();
                gridOneVar.Visibility = Visibility.Visible;
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Несколько вариантов")
            {
                collapsedallpanel();
                grLotQuestion.Visibility = Visibility.Visible;
            }
        }
        private void collapsedallpanel()
        {
            gridCloseQuestion.Visibility = Visibility.Collapsed;
            grLotQuestion.Visibility = Visibility.Collapsed;
            gridOneVar.Visibility = Visibility.Collapsed;
            gridSledovanie.Visibility = Visibility.Collapsed;
            gridSootv.Visibility = Visibility.Collapsed;
        }

        private void btnGoHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbTypeQuestion.ItemsSource = StatusList;
           
        }

        private void BtnGoPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnGoSetting_Click(object sender, RoutedEventArgs e)
        {
            gridSetting.Visibility = Visibility.Visible;
        }

        private void BtnClosegrid_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            gridSetting.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //AnswerQuestions anq = new AnswerQuestions();
            //QuestionList qlist = new QuestionList();
            //if(tbquestion1.Text != "")
            //{
            //    anq.formulirovka = tbquestion1.Text;
            //    anq.valueAnswer = tbquestion1.Text;
            //    qlist.AnswerQuestions.Add(anq);
            //}
            //if (tbquestion2.Text != "")
            //{
            //    anq.formulirovka = tbquestion2.Text;
            //    anq.valueAnswer = tbquestion2.Text;
            //    qlist.AnswerQuestions.Add(anq);
            //}
            //if (tbquestion3.Text != "")
            //{
            //    anq.formulirovka = tbquestion3.Text;
            //    anq.valueAnswer = tbquestion3.Text;
            //    qlist.AnswerQuestions.Add(anq);
            //}
            //if (tbquestion4.Text != "")
            //{

            //}
            //if (tbquestion5.Text != "")
            //{

            //}
            //if (tbquestion6.Text != "")
            //{

            //}
            //qlist.formulirovkaQuestion = tbFormulirovka.Text;
            //qlist.typeQuestion = "help";
            //using (StreamWriter writer = File.CreateText(@"C:\Users\vlado\Desktop"))
            //{
            //    string outjs = JsonConvert.SerializeObject(qlist);
            //    writer.Write(outjs);
            //}
        }

        private void NotQuestion(object sender, RoutedEventArgs e)
        {

        }
    }
}
