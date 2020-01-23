using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterTest
{
    public class Question
    {
        public int questionList { get; set; }
        public string quest { get; set; }

        public string typeQuestion { get; set; }

        public List<AnswerQuestions> optionQuestions { get; set; }
    }
}
