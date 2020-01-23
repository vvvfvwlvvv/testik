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
        List<AnswerQuestions> es = new List<AnswerQuestions>();
        List<Question> qlists = new List<Question>();
        List<TestList> testsq = new List<TestList>();
        List<Test> testsqq = new List<Test>();
        public string indexTMP = "";
        int index = 0;
        string js = File.ReadAllText(@"C:\Users\User\Desktop\q\qqq.json");
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
            TestList outjs = JsonConvert.DeserializeObject<TestList>(js);
            tbFormulirovka.Text = indexTMP;
            cbTypeQuestion.ItemsSource = StatusList;
            if (indexTMP != "")
            {
                var gh = outjs.testsq.FirstOrDefault(nameRed => nameRed.name == indexTMP).questions;
                
                dgView.ItemsSource = gh.Select(spisok => new { spisok.quest, spisok.typeQuestion }).ToList();
            }
            else
            {

            }

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
             
            if(cbTypeQuestion.SelectedItem.ToString() == "Последовательность")
            {
                if (tbConstStr1.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr1.Text,
                        value = tblStr1.Text
                    });
                }
                if (tbConstStr2.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr2.Text,
                        value = tblStr2.Text
                    });
                }
                if (tbConstStr3.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr3.Text,
                        value = tblStr3.Text
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr4.Text,
                        value = tblStr4.Text
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr5.Text,
                        value = tblStr5.Text
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr6.Text,
                        value = tblStr6.Text
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Несколько вариантов")
            {
                if (tbConstStr1.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr1.Text,
                        value = chbStr1.IsChecked.ToString()
                    });
                }
                if (tbConstStr1.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr2.Text,
                        value = chbStr2.IsChecked.ToString()
                    });
                }
                if (tbConstStr3.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr3.Text,
                        value = chbStr3.IsChecked.ToString()
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr4.Text,
                        value = chbStr4.IsChecked.ToString()
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr5.Text,
                        value = chbStr5.IsChecked.ToString()
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr6.Text,
                        value = chbStr6.IsChecked.ToString()
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Один вариант")
            {
                if (tbConstStr1.Text != "")
                {
                    
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr1.Text,
                        value = rbStr1.IsChecked.ToString()
                    });
                }
                if (tbConstStr2.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr2.Text,
                        value = rbStr2.IsChecked.ToString()
                    });
                }
                if (tbConstStr3.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr3.Text,
                        value = rbStr3.IsChecked.ToString()
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr4.Text,
                        value = rbStr4.IsChecked.ToString()
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr5.Text,
                        value = rbStr5.IsChecked.ToString()
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr6.Text,
                        value = rbStr6.IsChecked.ToString()
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос")
            {
                if (tbConstStr1.Text != "" && tbStr1.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr1.Text,
                        value = tbStr1.Text
                    });
                }
                if (tbConstStr2.Text != "" && tbStr2.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr2.Text,
                        value = tbStr2.Text
                    });
                }
                if (tbConstStr3.Text != "" && tbStr3.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr3.Text,
                        value = tbStr3.Text
                    });
                }
                if (tbConstStr4.Text != "" && tbStr4.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr4.Text,
                        value = tbStr4.Text
                    });
                }
                if (tbConstStr5.Text != "" && tbStr5.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr5.Text,
                        value = tblStr5.Text
                    });
                }
                if (tbConstStr6.Text != "" && tbStr6.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr6.Text,
                        value = tbStr6.Text
                    });
                }
            }
            else if (cbTypeQuestion.Text == "Соответствие")
            {
                if (tbConstStr1.Text != "" && tbStrSootv1.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr1.Text,
                        value = tbStrSootv1.Text
                    });
                }
                if (tbConstStr2.Text != "" && tbStrSootv2.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr2.Text,
                        value = tbStrSootv2.Text
                    });
                }
                if (tbConstStr3.Text != "" && tbStrSootv3.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr3.Text,
                        value = tbStrSootv3.Text
                    });
                }
                if (tbConstStr4.Text != "" && tbStrSootv4.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr4.Text,
                        value = tbStrSootv4.Text
                    });
                }
                if (tbConstStr5.Text != "" && tbStrSootv5.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr5.Text,
                        value = tbStrSootv5.Text
                    });
                }
                if (tbConstStr6.Text != "" && tbStrSootv6.Text != "")
                {
                    es.Add(new AnswerQuestions()
                    {
                        option = tbConstStr6.Text,
                        value = tbStrSootv6.Text
                    });
                }
            }

            qlists.Add(new Question()
            {
                quest = tbFormulirovka.Text,
                typeQuestion = cbTypeQuestion.Text,
                optionQuestions = es
            });
            index = 0;
            dgView.ItemsSource = qlists.Select(spisokVoprosov =>new {k=index++, spisokVoprosov.quest }).ToList();
            
        }

        private void NotQuestion(object sender, RoutedEventArgs e)
        {
            string timelimits;
            if (cbTimeLimit.IsChecked == true)
                timelimits = cbTimeLimit.IsChecked.ToString();
            else timelimits = null;

            object testinput = new
            {
                testsq = testsqq
            };

            testsqq.Add(new Test()
            {
                name = "QqqqqQ",
                randomOrder = cbRandomQuestion.IsChecked.Value,
                timeLimit = timelimits,
                questions = qlists
            });

            testsq.Add(new TestList(){
                testsq = testsqq 
            });

            using (StreamWriter writer = File.CreateText(@"C:\Users\User\Desktop\q\qqq.json"))
            {
                string outjs = JsonConvert.SerializeObject(testinput);
                writer.Write(outjs);

            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
