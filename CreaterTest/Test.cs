using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreaterTest
{
    public class Test
    {
        public int idTest { get; set; }

        public string name { get; set; }

        public bool randomOrderTest { get; set; }

        public bool randomOrderQuest { get; set; }

        public string timeLimit { get; set; }

        public IList<Question> questions { get; set; }
    }
}
