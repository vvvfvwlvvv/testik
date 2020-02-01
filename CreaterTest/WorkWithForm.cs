using System;
using System.Collections.Generic;
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
    }
}
