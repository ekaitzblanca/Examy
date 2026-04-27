using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroOposiciones.Objects
{
    public class Question
    {
        public int id { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public List<Option> options { get; set; }


        public string response { get; set; }
        public bool isCorrect { get; set; }
    }
}
