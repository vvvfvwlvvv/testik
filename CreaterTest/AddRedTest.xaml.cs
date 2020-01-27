using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Windows.Media;

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
       
        public List<string> StatusList = new List<string> { "Один вариант", "Несколько вариантов", "Соответствие", "Последовательность", "Закрытый вопрос"  };
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
        string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\CreaterTest\qqq.json");
        public object JsonSerializer { get; private set; }

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
                gridSootv.Visibility = Visibility.Visible;
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
            grLotQuestion.Visibility = Visibility.Collapsed;
            gridOneVar.Visibility = Visibility.Collapsed;
            gridSledovanie.Visibility = Visibility.Collapsed;
            gridSootv.Visibility = Visibility.Collapsed;
            gridSetting.Visibility = Visibility.Collapsed;
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
            if (move == "Редактирование")
            { 
                Test outjs = JsonConvert.DeserializeObject<Test>(js);
                dgView.ItemsSource = outjs.questions.Select(n => new { n.idQuestion, s = n.quest }).ToList();
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
            else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос" || cbTypeQuestion.SelectedItem.ToString() == "Соответствие")
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
                        value = tblStr5.Text
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

            int typeVopr = 0;
            switch(cbTypeQuestion.SelectedItem.ToString())
            {
                case "Один вариант":
                    typeVopr = 1;
                    break;
                case "Несколько вариантов":
                    typeVopr = 2;
                    break;
                case "Соответствие":
                    typeVopr = 3;
                    break;
                case "Последовательность":
                    typeVopr = 4;
                    break;
                case "Закрытый вопрос":
                    typeVopr = 5;
                    break;
            }

            qlists.Add(new Question()
            {
                idQuestion = idQuestion++,
                quest = tbFormulirovka.Text,
                typeQuestion = typeVopr,
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

            using (StreamWriter writer = File.CreateText(@"C:\Users\vlado\Desktop\q\CreaterTest\qqq.json"))
            {
                string outjs = JsonConvert.SerializeObject(testinput);
                writer.Write(outjs);
            }
            
            MessageBox.Show("Тест был успешно добавлен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
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

                cbTypeQuestion.SelectedIndex = outjs.questions[dgView.SelectedIndex].typeQuestion - 1;            }
            catch
            {
                MessageBox.Show("Ошибка, данный вопрос не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void tbnameTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbnameTest_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void tbnameTest_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbnameTest.Text == "Введите наименование теста")
            {
                tbnameTest.Foreground = new SolidColorBrush(Colors.Black);
                tbnameTest.Text = "";
            }
        }

        private void tbnameTest_LostFocus(object sender, RoutedEventArgs e)
        {
            if(tbnameTest.Text == "")
            {
                tbnameTest.Foreground = new SolidColorBrush(Colors.Gray);
                tbnameTest.Text = "Введите наименование теста";
            }
        }

        private void tbFormulirovka_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbFormulirovka.Text == "Введите формулировку вопроса")
            {
                tbFormulirovka.Foreground = new SolidColorBrush(Colors.Black);
                tbFormulirovka.Text = "";
            }
        }

        private void tbFormulirovka_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbFormulirovka.Text == "")
            {
                tbFormulirovka.Foreground = new SolidColorBrush(Colors.Gray);
                tbFormulirovka.Text = "Введите формулировку вопроса";
            }
        }

        private void cbTimeLimit_Checked(object sender, RoutedEventArgs e)
        {
                tbTimeLimit.Visibility = Visibility.Visible;   
        }

        private void tbTimeLimit_GotFocus(object sender, RoutedEventArgs e)
        {
            if(tbTimeLimit.Text == "Введите кол-во минут")
            {
                tbTimeLimit.Foreground = new SolidColorBrush(Colors.Black);
                tbTimeLimit.Text = "";
            }
        }

        private void tbTimeLimit_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbTimeLimit.Text == "")
            {
                tbTimeLimit.Foreground = new SolidColorBrush(Colors.Gray);
                tbTimeLimit.Text = "Введите кол-во минут";
            }
        }

        private void tbTimeLimit_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbTimeLimit_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
            if(tbTimeLimit.Text.Length > 2)
            {
                e.Handled = true;
            }
        }

        private void cbTimeLimit_Unchecked(object sender, RoutedEventArgs e)
        {
            tbTimeLimit.Visibility = Visibility.Hidden;
        }
    }
}
