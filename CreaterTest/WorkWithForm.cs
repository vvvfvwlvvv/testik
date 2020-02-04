using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CreaterTest
{
    public class WorkWithForm
    {
        int idOption = 0;
        public List<OptionQuestions> es = new List<OptionQuestions>();


        public void checkConstStroka(TextBox text, string valoption)
        {
            if (text.Text != "" && valoption != "")
            {
                es.Add(new OptionQuestions()
                {
                    idOption = idOption++,
                    option = text.Text,
                    value = valoption
                });
            }
        }

        public void RemoveQuestion(int idVoprosa)
        {
            string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
            Test outjs = JsonConvert.DeserializeObject<Test>(js);
            outjs.questions.Remove(outjs.questions.FirstOrDefault(n => n.idQuestion == idVoprosa));
            using (StreamWriter writer = File.CreateText(@"C:\Users\vlado\Desktop\q\qqq.json"))
            {
                string retStrok = JsonConvert.SerializeObject(outjs);
                writer.Write(retStrok);
            }
        }

        public void Obnova(DataGrid data)
        {
            string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
            Test outjs = JsonConvert.DeserializeObject<Test>(js);
            data.ItemsSource = outjs.questions.Select(n => new { n.idQuestion, s = n.quest }).ToList();
            data.Columns[0].Header = "Id";
            data.Columns[1].Header = "Формулировка вопроса";
        }

        public void ZamenaZnach(TextBox text, string valoption, int idAnswer, int idQuestion, string nameTest, string formulirovkaVoprosa, int typeQuestion)
        {
            string js = File.ReadAllText(@"C:\Users\vlado\Desktop\q\qqq.json");
            Test outjs = JsonConvert.DeserializeObject<Test>(js);
            if (text.Text != "" && valoption != "")
            {
                outjs.name = nameTest;
                outjs.questions.FirstOrDefault(n => n.idQuestion == idQuestion).typeQuestion = typeQuestion;
                outjs.questions.FirstOrDefault(n => n.idQuestion == idQuestion).quest = formulirovkaVoprosa;
                outjs.questions.FirstOrDefault(n => n.idQuestion == idQuestion).optionQuestions[idAnswer].option = text.Text;
                outjs.questions.FirstOrDefault(n => n.idQuestion == idQuestion).optionQuestions[idAnswer].value = valoption;
            }
            
            using (StreamWriter writer = File.CreateText(@"C:\Users\vlado\Desktop\q\qqq.json"))
            {
                string retStrok = JsonConvert.SerializeObject(outjs);
                writer.Write(retStrok);
            }
        }
    }
}
