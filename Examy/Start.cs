using SimulacroOposiciones.Data;
using SimulacroOposiciones.MVC.CategoryMenu;
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

            string auxiliar_path = Path.Combine(AppContext.BaseDirectory, "Data", "auxiliar_questions.json");
            string laboratorio_path = Path.Combine(AppContext.BaseDirectory, "Data", "laboratorio_questions.json");
            string celador_path = Path.Combine(AppContext.BaseDirectory, "Data", "celador_questions.json");

            Gen.auxiliar_questions = Gen.LoadQuestions(auxiliar_path);
            Gen.laboratorio_questions = Gen.LoadQuestions(laboratorio_path);
            Gen.celador_questions = Gen.LoadQuestions(celador_path);

            Gen.auxiliar_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "auxiliar_errors.json");
            Gen.laboratorio_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "laboratorio_errors.json");
            Gen.celador_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "celador_errors.json");


        MVC.App app = new MVC.App();
            app.Show();
        }
    }
}