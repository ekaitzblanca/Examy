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
            List<Question> questions = _model.GenerateQuestionary(_category, _mode, _type);

            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(0, questions, "practica"));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.TypeMenu.View(_category, _mode));
        }

    }
}
