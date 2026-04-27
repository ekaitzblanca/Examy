using Examy.Objects;
using SimulacroOposiciones.Data;
using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimulacroOposiciones.MVC.StartTest
{
    public class Model
    {
        public string getCategoryDisplay(string category)
        {
            string displayCategory = "";
            switch (category)
            {
                case "auxiliar":
                    displayCategory = "Auxiliar de Enfermeria";
                    break;
                case "laboratorio":
                    displayCategory = "Tecnico/Especialista en Laboratorio";
                    break;
                case "celador":
                    displayCategory = "Celador";
                    break;
            }

            return displayCategory;
        }

        public string getModeDisplay(string mode)
        {
            string displayMode = "";
            switch (mode)
            {
                case "practica":
                    displayMode = "Test de Practica";
                    break;
                case "errores":
                    displayMode = "Test de Errores";
                    break;
                case "examen":
                    displayMode = "Test Examen";
                    break;
            }

            return displayMode;
        }

        public string getTypeDisplay(string type)
        {
            string displaytype = "";
            switch (type)
            {
                case "comun":
                    displaytype = "Preguntas Comunes";
                    break;
                case "especifico":
                    displaytype = "Preguntas Especificas";
                    break;
                case "todo":
                    displaytype = "Preguntas de Todo";
                    break;
            }

            return displaytype;
        }

        public List<Question> GenerateQuestionaryPractica(string category, string type)
        {
            List<Question> temporal = new List<Question>();
            List<Question> questionary = new List<Question>();

            switch (category)
            {
                case "auxiliar":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.auxiliar_questions));
                    break;
                case "laboratorio":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.laboratorio_questions));
                    break;
                case "celador":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.celador_questions));
                    break;
            }

            switch (type)
            {
                case "comun":
                    temporal = temporal.Where(q => q.type == "comun").ToList();
                    break;
                case "especifico":
                    temporal = temporal.Where(q => q.type == "especifico").ToList();
                    break;
                case "todo":
                    break;
            }

            questionary = temporal.OrderBy(x => Guid.NewGuid()).Take(50).ToList();
                   
            return questionary;
        }

        public List<Question> GenerateQuestionaryErrores(string category, string type)
        {
            string auxiliar_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "auxiliar_errors.json");
            string laboratorio_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "laboratorio_errors.json");
            string celador_error_path = Path.Combine(AppContext.BaseDirectory, "Data", "celador_errors.json");

            List<QuestionErrors> auxiliar_errors = Gen.LoadQuestionErrors(auxiliar_error_path);
            List<QuestionErrors> laboratorio_errors = Gen.LoadQuestionErrors(laboratorio_error_path);
            List<QuestionErrors> celador_errors = Gen.LoadQuestionErrors(celador_error_path);

            List<Question> temporal = new List<Question>();
            List<Question> questionary = new List<Question>();

            switch (category)
            {
                case "auxiliar":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.auxiliar_questions));
                    temporal = temporal.Where(q => auxiliar_errors.Exists(e => e.id == q.id)).ToList();
                    break;
                case "laboratorio":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.laboratorio_questions));
                    temporal = temporal.Where(q => laboratorio_errors.Exists(e => e.id == q.id)).ToList();
                    break;
                case "celador":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.celador_questions));
                    temporal = temporal.Where(q => celador_errors.Exists(e => e.id == q.id)).ToList();
                    break;
            }

            switch (type)
            {
                case "comun":
                    temporal = temporal.Where(q => q.type == "comun").ToList();
                    break;
                case "especifico":
                    temporal = temporal.Where(q => q.type == "especifico").ToList();
                    break;
                case "todo":
                    break;
            }

            questionary = temporal.OrderBy(x => Guid.NewGuid()).Take(50).ToList();

            return questionary;
        }
    }
}
