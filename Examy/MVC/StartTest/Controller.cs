using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.StartTest
{
    public class Controller
    {
        private View _view;
        private Model _model;

        private string _category;
        private string _mode;
        private string _type;

        public Controller(View view, string category, string mode, string type) { 
            _category = category;
            _mode = mode;
            _type = type;

            _model = new Model();
            _view = view;
            setListeners();

            _view.lbl_category.Content = _model.getCategoryDisplay(_category);
            _view.lbl_mode.Content = _model.getModeDisplay(_mode);
            _view.lbl_type.Content = _model.getTypeDisplay(_type);
        }

        public void setListeners()
        {
            _view.btn_StartTest.Click += StartTest_Click;
            _view.btn_Back.Click += Back_Click;
        }

        private void StartTest_Click(object sender, RoutedEventArgs e)
        {
            switch (_mode)
            {
                case "practica":
                    List<Question> questions = _model.GenerateQuestionaryPractica(_category, _type);
                    if (questions.Count == 0)
                    {
                        MessageBox.Show("No hay preguntas disponibles para esta combinación de categoría y tipo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(0, questions, _category, _mode));
                    break;
                case "errores":
                    List<Question> errorQuestions = _model.GenerateQuestionaryErrores(_category, _type);
                    if (errorQuestions.Count == 0)
                    {
                        MessageBox.Show("No hay preguntas disponibles para esta combinación de categoría y tipo.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(0, errorQuestions, _category, _mode));
                    break;
                case "examen":
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.TypeMenu.View(_category, _mode));
        }

    }
}
