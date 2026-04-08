using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroOposiciones.Data
{
    public static class Gen
    {
        public static List<Question> auxiliar_questions { get; set; }
        public static List<Question> laboratorio_questions { get; set; }
        public static List<Question> celador_questions { get; set; }

        public static string version { get; set; } = "Version: 1.0.0";
    }
}
