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
using System.Net.Sockets;
using System.Net;

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
        public string move; // Определяем с каким действием вошел пользователь
        
        List<Question> qlists = new List<Question>();
        List<TestList> testsq = new List<TestList>();
        List<Test> testsqq = new List<Test>();

        public int idTestik = 0;
        public int idQuestion = 0;
        public int idOption = 0;
        public int indexTMP;
        int index = 0;
        public List<OptionQuestions> anwsers = new List<OptionQuestions>();
        string js = File.ReadAllText(@"C:\Users\User\Desktop\q\qqq.json");
        public object JsonSerializer { get; private set; }

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
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbTypeQuestion.ItemsSource = StatusList;
            try
            {
                Test outjs = JsonConvert.DeserializeObject<Test>(js);
                dgView.ItemsSource = outjs.questions.Select(n =>new {n.idQuestion, s = n.quest }).ToList();
            }
            catch
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK);
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

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            gridSetting.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ///<summary>
            ///Логика добавления вопросов
            /// </summary>
             
            List<OptionQuestions> es = new List<OptionQuestions>();// Каждый раз создается экземпляр ответов, чтобы для каждого вопроса не повторялись ответы
            if (cbTypeQuestion.SelectedItem.ToString() == "Последовательность")
            {
                if (tbConstStr1.Text != "")
                {

                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr1.Text,
                        value = tblStr1.Text
                    });
                }
                if (tbConstStr2.Text != "")
                {

                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr2.Text,
                        value = tblStr2.Text
                    });
                }
                if (tbConstStr3.Text != "")
                {

                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr3.Text,
                        value = tblStr3.Text
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr4.Text,
                        value = tblStr4.Text
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr5.Text,
                        value = tblStr5.Text
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr6.Text,
                        value = tblStr6.Text
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Несколько вариантов")
            {
                if (tbConstStr1.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr1.Text,
                        value = chbStr1.IsChecked.ToString()
                    });
                }
                if (tbConstStr1.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr2.Text,
                        value = chbStr2.IsChecked.ToString()
                    });
                }
                if (tbConstStr3.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr3.Text,
                        value = chbStr3.IsChecked.ToString()
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr4.Text,
                        value = chbStr4.IsChecked.ToString()
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr5.Text,
                        value = chbStr5.IsChecked.ToString()
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr6.Text,
                        value = chbStr6.IsChecked.ToString()
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Один вариант")
            {
                if (tbConstStr1.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr1.Text,
                        value = rbStr1.IsChecked.ToString()
                    });
                }
                if (tbConstStr2.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr2.Text,
                        value = rbStr2.IsChecked.ToString()
                    });
                }
                if (tbConstStr3.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr3.Text,
                        value = rbStr3.IsChecked.ToString()
                    });
                }
                if (tbConstStr4.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr4.Text,
                        value = rbStr4.IsChecked.ToString()
                    });
                }
                if (tbConstStr5.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr5.Text,
                        value = rbStr5.IsChecked.ToString()
                    });
                }
                if (tbConstStr6.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr6.Text,
                        value = rbStr6.IsChecked.ToString()
                    });
                }
            }
            else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос")
            {
                if (tbConstStr1.Text != "" && tbStr1.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr1.Text,
                        value = tbStr1.Text
                    });
                }
                if (tbConstStr2.Text != "" && tbStr2.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr2.Text,
                        value = tbStr2.Text
                    });
                }
                if (tbConstStr3.Text != "" && tbStr3.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr3.Text,
                        value = tbStr3.Text
                    });
                }
                if (tbConstStr4.Text != "" && tbStr4.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr4.Text,
                        value = tbStr4.Text
                    });
                }
                if (tbConstStr5.Text != "" && tbStr5.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr5.Text,
                        value = tblStr5.Text
                    });
                }
                if (tbConstStr6.Text != "" && tbStr6.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr6.Text,
                        value = tbStr6.Text
                    });
                }
            }
            else if (cbTypeQuestion.Text == "Соответствие")
            {
                if (tbConstStr1.Text != "" && tbStrSootv1.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr1.Text,
                        value = tbStrSootv1.Text
                    });
                }
                if (tbConstStr2.Text != "" && tbStrSootv2.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr2.Text,
                        value = tbStrSootv2.Text
                    });
                }
                if (tbConstStr3.Text != "" && tbStrSootv3.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr3.Text,
                        value = tbStrSootv3.Text
                    });
                }
                if (tbConstStr4.Text != "" && tbStrSootv4.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr4.Text,
                        value = tbStrSootv4.Text
                    });
                }
                if (tbConstStr5.Text != "" && tbStrSootv5.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr5.Text,
                        value = tbStrSootv5.Text
                    });
                }
                if (tbConstStr6.Text != "" && tbStrSootv6.Text != "")
                {
                    es.Add(new OptionQuestions()
                    {
                        idOption = idOption++,
                        option = tbConstStr6.Text,
                        value = tbStrSootv6.Text
                    });
                }
            }
            qlists.Add(new Question()
            {
                idQuestion = idQuestion++,
                quest = tbFormulirovka.Text,
                typeQuestion = cbTypeQuestion.SelectedIndex,
                optionQuestions = es
            });

            index = 0;
            dgView.ItemsSource = qlists.Select(spisokVoprosov =>new {k=index++, spisokVoprosov.quest }).ToList();

            //Подчищаем строки
            tbFormulirovka.Clear();
            tbConstStr1.Clear();
            tbConstStr2.Clear();
            tbConstStr3.Clear();
            tbConstStr4.Clear();
            tbConstStr5.Clear();
            tbConstStr6.Clear();
        }

        private void NotQuestion(object sender, RoutedEventArgs e)
        {
            // Добавление в тест + настройки теста
            string timelimits;
            if (cbTimeLimit.IsChecked == true)
                timelimits = cbTimeLimit.IsChecked.ToString();
            else timelimits = "0";

            object qlistinput = new
            {
                questions = qlists
            };

            testsq.Add(new TestList()
            {
                testsq = testsqq
            });

            object testinput = new
            {
                idTest = idTestik++,
                name = tbnameTest.Text,
                randomOrderTest = cbRandomQuestion.IsChecked.Value,
                randomOrderQuest = cbRandomQuestion.IsChecked.Value,
                timeLimit = timelimits,
                questions = qlists
            };
            

            ///<summary>
            ///Логика подключения и передачи данных на сокет
            /// </summary>

            //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //socket.Connect("95.182.122.115", 25565);
            //string writeInstruction = "writeToNewTest";
            //byte [] sockWrite = Encoding.UTF8.GetBytes(ss);
            //byte[] jsString = Encoding.UTF8.GetBytes(outjs);
            //socket.Send(b);
            //socket.Send(q);
            //socket.Close();


            ///<summary>
            ///Временная логика записи строки в Json
            /// </summary>

            using (StreamWriter writer = File.CreateText(@"C:\Users\User\Desktop\q\qqq.json"))
            {
                string outjs = JsonConvert.SerializeObject(testinput);
                writer.Write(outjs);
            }
            
            MessageBox.Show("Тест был успешно добавлен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Test outjs = JsonConvert.DeserializeObject<Test>(js);
            tbFormulirovka.Text = outjs.questions[dgView.SelectedIndex].quest;
            var listik = outjs.questions[dgView.SelectedIndex].optionQuestions.ToList();
            int listcount = listik.Count();

            switch (listcount)
            {
                case 1:
                    tbConstStr1.Text = listik[0].option;
                    break;
                case 2:
                    tbConstStr1.Text = listik[0].option;
                    tbConstStr2.Text = listik[1].option;
                    break;
                case 3:
                    tbConstStr1.Text = listik[0].option;
                    tbConstStr2.Text = listik[1].option;
                    tbConstStr3.Text = listik[2].option;
                    break;
                case 4:
                    tbConstStr1.Text = listik[0].option;
                    tbConstStr2.Text = listik[1].option;
                    tbConstStr3.Text = listik[2].option;
                    tbConstStr4.Text = listik[3].option;
                    break;
                case 5:
                    tbConstStr1.Text = listik[0].option;
                    tbConstStr2.Text = listik[1].option;
                    tbConstStr3.Text = listik[2].option;
                    tbConstStr4.Text = listik[3].option;
                    tbConstStr5.Text = listik[4].option;
                    break;
            }

        }

       
    }
}
