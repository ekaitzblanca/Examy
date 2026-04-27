using Examy.Objects;
using Newtonsoft.Json;
using SimulacroOposiciones.Data;
using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

        public bool SaveHistory<Question>(List<Question> questions, string category, string mode)
        {
            try
            {
                string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_{category}_{mode}.json";
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

        public bool UpdateErrors(List<Question> questions, string category, string mode)
        {
            List<Question> question_correct = questions.Where(q => q.response != "" && q.isCorrect).ToList();
            List<Question> question_error = questions.Where(q => q.response != null && !q.isCorrect).ToList();

            List<QuestionErrors> errors_json = new List<QuestionErrors>();
            switch (category)
            {
                case "auxiliar":
                    errors_json = Gen.LoadQuestionErrors(Gen.auxiliar_error_path);
                    break;
                case "laboratorio":
                    errors_json = Gen.LoadQuestionErrors(Gen.laboratorio_error_path);
                    break;
                case "celador":
                    errors_json = Gen.LoadQuestionErrors(Gen.celador_error_path);
                    break;
            }

            foreach (var question in question_correct)
            {
                int index = errors_json.FindIndex(x => x.id == question.id);
                if (index == -1)
                {
                    continue;
                }

                errors_json[index].value--;

                if (errors_json[index].value <= 0)
                {
                    errors_json.RemoveAt(index);
                }
            }

            foreach (var question in question_error)
            {
                int index = errors_json.FindIndex(x => x.id == question.id);
                if (index == -1)
                {
                    QuestionErrors new_qe = new QuestionErrors();
                    new_qe.id = question.id;
                    new_qe.value = 2;
                    errors_json.Add(new_qe);
                    continue;
                }

                errors_json[index].value = 2;
            }

            string json = JsonConvert.SerializeObject(errors_json, Formatting.Indented);
            switch (category)
            {
                case "auxiliar":
                    File.WriteAllText(Gen.auxiliar_error_path, json);
                    break;
                case "laboratorio":
                    File.WriteAllText(Gen.laboratorio_error_path, json);
                    break;
                case "celador":
                    File.WriteAllText(Gen.celador_error_path, json);
                    break;
            }

            return true;
        }
    }
}
