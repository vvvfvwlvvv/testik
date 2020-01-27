using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterTest
{
    public class Question
    {
        public int idQuestion { get; set; }
        public string quest { get; set; }

        public int typeQuestion { get; set; }

        public IList<OptionQuestions> optionQuestions { get; set; }
        
    }
}
