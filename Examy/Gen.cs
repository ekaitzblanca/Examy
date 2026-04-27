using Examy.Objects;
using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static string auxiliar_error_path { get; set; }
        public static string laboratorio_error_path { get; set; }
        public static string celador_error_path { get; set; }

        public static string version { get; set; } = "Version: 1.0.4";

        public static List<Question> LoadQuestions(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found.", filePath);

            string json = File.ReadAllText(filePath);

            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return System.Text.Json.JsonSerializer.Deserialize<List<Question>>(json, options) ?? new List<Question>();
        }

        public static List<QuestionErrors> LoadQuestionErrors(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("JSON file not found.", filePath);

            string json = File.ReadAllText(filePath);

            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return System.Text.Json.JsonSerializer.Deserialize<List<QuestionErrors>>(json, options) ?? new List<QuestionErrors>();
        }
    }
}
