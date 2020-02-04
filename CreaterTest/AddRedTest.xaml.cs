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
        string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
        public object JsonSerializer { get; private set; }
        int typeVopr = 0;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbTypeQuestion.SelectedItem.ToString())
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
                    typeVopr = 5;
                    break;
                case "Закрытый вопрос":
                    typeVopr = 4;
                    break;
            }

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
                dgView.Columns[0].Header = "Id";
                dgView.Columns[1].Header = "Формулировка вопроса";
            }
        }

        private void BtnGoPower_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnGoSetting_Click(object sender, RoutedEventArgs e)
        {
            collapsedallpanel();
            grConstString.Visibility = Visibility.Collapsed;
            gridSetting.Visibility = Visibility.Visible;

        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            gridSetting.Visibility = Visibility.Collapsed;
            grConstString.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ///<summary>
            ///Логика добавления вопросов
            /// </summary>
           
            WorkWithForm wwf = new WorkWithForm();
            if (move == "Редактирование")
            {
                //string result = "";
                //wwf.che();
                int idVoprosa = Convert.ToInt32((dgView.Columns[0].GetCellContent(dgView.SelectedItem) as TextBlock).Text);
                if (cbTypeQuestion.SelectedItem.ToString() == "Последовательность")
                {
                    wwf.ZamenaZnach(tbConstStr1, tblStr1.Text, 0, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr2, tblStr2.Text, 1, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr3, tblStr3.Text, 2, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr4, tblStr4.Text, 3, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr5, tblStr5.Text, 4, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr6, tblStr6.Text, 5, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Несколько вариантов")
                {
                    wwf.ZamenaZnach(tbConstStr1, chbStr1.IsChecked.ToString(), 0, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr2, chbStr2.IsChecked.ToString(), 1, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr3, chbStr3.IsChecked.ToString(), 2, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr4, chbStr4.IsChecked.ToString(), 3, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr5, chbStr5.IsChecked.ToString(), 4, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr6, chbStr6.IsChecked.ToString(), 5, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Один вариант")
                {
                    wwf.ZamenaZnach(tbConstStr1, rbStr1.IsChecked.ToString(), 0, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr2, rbStr2.IsChecked.ToString(), 1, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr3, rbStr3.IsChecked.ToString(), 2, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr4, rbStr4.IsChecked.ToString(), 3, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr5, rbStr5.IsChecked.ToString(), 4, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr6, rbStr6.IsChecked.ToString(), 5, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос" || cbTypeQuestion.SelectedItem.ToString() == "Соответствие")
                {
                    wwf.ZamenaZnach(tbConstStr1, tbStrSootv1.Text, 0, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr2, tbStrSootv2.Text, 1, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr3, tbStrSootv3.Text, 2, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr4, tbStrSootv4.Text, 3, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr5, tbStrSootv5.Text, 4, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                    wwf.ZamenaZnach(tbConstStr6, tbStrSootv6.Text, 5, idVoprosa, tbnameTest.Text, tbFormulirovka.Text, typeVopr);
                }
                wwf.Obnova(dgView);
                
            }
            else
            {
               // WorkWithForm wwf = new WorkWithForm();
                if (cbTypeQuestion.SelectedItem.ToString() == "Последовательность")
                {
                    wwf.checkConstStroka(tbConstStr1, tblStr1.Text);
                    wwf.checkConstStroka(tbConstStr2, tblStr2.Text);
                    wwf.checkConstStroka(tbConstStr3, tblStr3.Text);
                    wwf.checkConstStroka(tbConstStr4, tblStr4.Text);
                    wwf.checkConstStroka(tbConstStr5, tblStr5.Text);
                    wwf.checkConstStroka(tbConstStr6, tblStr6.Text);
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Несколько вариантов")
                {
                    wwf.checkConstStroka(tbConstStr1, chbStr1.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr2, chbStr2.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr3, chbStr3.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr4, chbStr4.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr5, chbStr5.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr6, chbStr6.IsChecked.ToString());
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Один вариант")
                {
                    wwf.checkConstStroka(tbConstStr1, rbStr1.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr2, rbStr2.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr3, rbStr3.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr4, rbStr4.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr5, rbStr5.IsChecked.ToString());
                    wwf.checkConstStroka(tbConstStr6, rbStr6.IsChecked.ToString());
                }
                else if (cbTypeQuestion.SelectedItem.ToString() == "Закрытый вопрос" || cbTypeQuestion.SelectedItem.ToString() == "Соответствие")
                {
                    wwf.checkConstStroka(tbConstStr1, tbStrSootv1.Text);
                    wwf.checkConstStroka(tbConstStr2, tbStrSootv2.Text);
                    wwf.checkConstStroka(tbConstStr3, tbStrSootv3.Text);
                    wwf.checkConstStroka(tbConstStr4, tbStrSootv4.Text);
                    wwf.checkConstStroka(tbConstStr5, tbStrSootv5.Text);
                    wwf.checkConstStroka(tbConstStr6, tbStrSootv6.Text);
                }


                qlists.Add(new Question()
                {
                    idQuestion = idQuestion++,
                    quest = tbFormulirovka.Text,
                    typeQuestion = typeVopr,
                    optionQuestions = wwf.es
                });


                index = 0;
                dgView.ItemsSource = qlists.Select(spisokVoprosov => new { k = index++, spisokVoprosov.quest }).ToList();

                //Подчищаем строки
                tbFormulirovka.Text = "Введите формулировку вопроса";
                tbConstStr1.Clear();
                tbConstStr2.Clear();
                tbConstStr3.Clear();
                tbConstStr4.Clear();
                tbConstStr5.Clear();
                tbConstStr6.Clear();
            }
        }

        

        public void switchwithlist()
        {
            string jss = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
            Test outjs = JsonConvert.DeserializeObject<Test>(jss);
            //tbFormulirovka.Text = outjs.questions[dgView.SelectedIndex].quest;
            try
            {
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
                    case 6:
                        tbConstStr1.Text = listik[0].option;
                        tbConstStr2.Text = listik[1].option;
                        tbConstStr3.Text = listik[2].option;
                        tbConstStr4.Text = listik[3].option;
                        tbConstStr5.Text = listik[4].option;
                        tbConstStr6.Text = listik[5].option;
                        break;
                }
            }
            catch
            {

            }

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switchwithlist();
            collapsedallpanel();
            try
            {
                string jss = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
                Test outjs = JsonConvert.DeserializeObject<Test>(jss);
                tbFormulirovka.Text = outjs.questions[dgView.SelectedIndex].quest;
                var listik = outjs.questions[dgView.SelectedIndex].optionQuestions.ToList();
                int listcount = listik.Count();
                int typeVoprId = outjs.questions[dgView.SelectedIndex].typeQuestion;
                switch (typeVoprId)
                {
                    case 1:
                        cbTypeQuestion.SelectedIndex = typeVoprId - 1;
                        
                        gridOneVar.Visibility = Visibility.Visible;
                        
                        switch (listcount)
                        {
                            case 1: 
                                rbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                break;
                            case 2:
                                rbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                rbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                break;
                            case 3:
                                rbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                rbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                rbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                break;
                            case 4:
                                rbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                rbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                rbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                rbStr4.IsChecked = Convert.ToBoolean(listik[3].value);
                                break;
                            case 5:
                                rbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                rbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                rbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                rbStr4.IsChecked = Convert.ToBoolean(listik[3].value);
                                rbStr5.IsChecked = Convert.ToBoolean(listik[4].value);
                                break;
                        }
                        break;
                    case 2:
                        cbTypeQuestion.SelectedIndex = typeVoprId - 1;
                       
                        grLotQuestion.Visibility = Visibility.Visible;
                        
                        switch (listcount)
                        {
                            case 1:
                                chbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                break;
                            case 2:
                                chbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                chbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                break;
                            case 3:
                                chbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                chbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                chbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                break;
                            case 4:
                                chbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                chbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                chbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                chbStr4.IsChecked = Convert.ToBoolean(listik[3].value);
                                break;
                            case 5:
                                chbStr1.IsChecked = Convert.ToBoolean(listik[0].value);
                                chbStr2.IsChecked = Convert.ToBoolean(listik[1].value);
                                chbStr3.IsChecked = Convert.ToBoolean(listik[2].value);
                                chbStr4.IsChecked = Convert.ToBoolean(listik[3].value);
                                chbStr5.IsChecked = Convert.ToBoolean(listik[4].value);
                                break;
                        }
                        break;
                    case 3:
                        tbstrsootv();
                        break;
                    case 5:
                        
                        cbTypeQuestion.SelectedIndex = typeVoprId - 2;
                        gridSledovanie.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        tbstrsootv();
                        break;
                        
                }
            }
            catch
            {
                MessageBox.Show("Something error", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void tbstrsootv()
        {
            Test outjs = JsonConvert.DeserializeObject<Test>(js);
            var listik = outjs.questions[dgView.SelectedIndex].optionQuestions.ToList();
            int listcount = listik.Count();
            int typeVoprId = outjs.questions[dgView.SelectedIndex].typeQuestion;
            cbTypeQuestion.SelectedIndex = typeVoprId - 1;
            gridSootv.Visibility = Visibility.Visible;
            switch (listcount)
            {
                case 1:
                    tbStrSootv1.Text = listik[0].value.ToString();
                    break;
                case 2:
                    tbStrSootv1.Text = listik[0].value.ToString();
                    tbStrSootv2.Text = listik[1].value.ToString();
                    break;
                case 3:
                    tbStrSootv1.Text = listik[0].value.ToString();
                    tbStrSootv2.Text = listik[1].value.ToString();
                    tbStrSootv3.Text = listik[2].value.ToString();
                    break;
                case 4:
                    tbStrSootv1.Text = listik[0].value.ToString();
                    tbStrSootv2.Text = listik[1].value.ToString();
                    tbStrSootv3.Text = listik[2].value.ToString();
                    tbStrSootv4.Text = listik[3].value.ToString();
                    break;
                case 5:
                    tbStrSootv1.Text = listik[0].value.ToString();
                    tbStrSootv2.Text = listik[1].value.ToString();
                    tbStrSootv3.Text = listik[2].value.ToString();
                    tbStrSootv4.Text = listik[3].value.ToString();
                    tbStrSootv5.Text = listik[4].value.ToString();
                    break;
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

        public void ChangeValList(TextBox text)
        {
            if (text.Text != "") tbFormulirovka.Text = "Work"; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeValList(tbConstStr1);
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            // Добавление в тест + настройки теста
            string timelimits;
            if (cbTimeLimit.IsChecked == true)
                timelimits = cbTimeLimit.IsChecked.ToString();
            else timelimits = "0";

            //object qlistinput = new
            //{
            //    questions = qlists
            //};

            //testsq.Add(new TestList()
            //{
            //    testsq = testsqq
            //});

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

            using (StreamWriter writer = File.CreateText(@"C:\Users\vlado\Desktop\q\qqq.json"))
            {
                string outjs = JsonConvert.SerializeObject(testinput);
                writer.Write(outjs);
            }

            MessageBox.Show("Тест был успешно добавлен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WorkWithForm wwf = new WorkWithForm();
            wwf.RemoveQuestion(Convert.ToInt32((dgView.Columns[0].GetCellContent(dgView.SelectedItem) as TextBlock).Text));
        }
    }
}
