using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.PracticeResume
{
    public class Model
    {
        public string GetFeedBack(double percentage)
        {
            if (percentage <= 40)
            {
                return "❌ Necesitas reforzar este tema.";
            }
            else if (percentage <= 60)
            {
                return "⚠️ Vas en el camino, pero necesitas mejorar.";
            }
            else if (percentage <= 75)
            {
                return "👍 Buen trabajo, estás cerca de un buen resultado.";
            }
            else if (percentage <= 90)
            {
                return "💪 Muy buen resultado.";
            }
            else
            {
                return "🏆 Excelente trabajo.";
            }
        }

        public string GetAnalysis(double percentage)
        {
            if (percentage <= 40)
            {
                return "Has tenido muchos fallos. Te recomiendo repasar la teoría y practicar con más tests antes de volver a intentarlo.";
            }
            else if (percentage <= 60)
            {
                return "Tienes una base, pero aún cometes bastantes errores. Repasa los conceptos clave y sigue practicando.";
            }
            else if (percentage <= 75)
            {
                return "Has demostrado un conocimiento sólido, pero algunos fallos te han bajado la puntuación. Revisa los errores para mejorar.";
            }
            else if (percentage <= 90)
            {
                return "Dominas la mayoría de los conceptos. Solo necesitas pulir pequeños detalles para alcanzar la excelencia.";
            }
            else
            {
                return "Has obtenido un resultado sobresaliente. Sigue así, estás muy bien preparado.";
            }
        }

        public bool SaveHistory<Question>(List<Question> questions, string from_view)
        {
            try
            {
                string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{from_view}.json";
                string filePath = Path.Combine(AppContext.BaseDirectory, "Data", "History", fileName);

                string json = JsonConvert.SerializeObject(questions, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el JSON: {ex.Message}");
                return false;
            }

            return true;
        }
    }
}
