using SimulacroOposiciones.Data;
using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
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

        public List<Question> GenerateQuestionary(string category, string mode, string type)
        {
            List<Question> temporal = new List<Question>();
            List<Question> questionary = new List<Question>();

            switch (category)
            {
                case "auxiliar":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.auxiliar_questions)
);
                    break;
                case "laboratorio":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.laboratorio_questions));
                    break;
                case "celador":
                    temporal = JsonSerializer.Deserialize<List<Question>>(JsonSerializer.Serialize(Gen.celador_questions));
                    break;
            }

            switch (mode)
            {
                case "practica":
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
                    break;
                case "errores":
                    break;
                case "examen":
                    questionary = temporal.OrderBy(x => Guid.NewGuid()).Take(100).ToList();
                    break;
            }

            return questionary;
        }
    }
}
