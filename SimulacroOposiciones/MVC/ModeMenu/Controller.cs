using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.ModeMenu
{
    public class Controller
    {
        private Model _model;
        private View _view;

        private string _category;

        public Controller(View view, string category) {
            _category = category;

            _model = new Model();
            _view = view;
            setListeners();
        }

        public void setListeners()
        {
            _view.btn_Practica.Click += Practica_Click;
            _view.btn_Errores.Click += Errores_Click;
            _view.btn_Examen.Click += Examen_Click;
        }

        private void Practica_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.TypeMenu.View(_category, "practica"));
        }

        private void Errores_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.StartTest.View(_category, "errores", ""));
        }

        private void Examen_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.StartTest.View(_category, "examen", ""));
        }
    }
}
