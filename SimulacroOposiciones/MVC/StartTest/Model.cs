using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
