using SimulacroOposiciones.Data;
using SimulacroOposiciones.MVC.StartMenu;
using SimulacroOposiciones.Objects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string auxiliar_path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\auxiliar_questions.json"));

            Gen.questions_200 = LoadQuestions(auxiliar_path);

            MVC.App app = new MVC.App();
            app.Show();
        }

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
    }
}