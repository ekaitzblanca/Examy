using SimulacroOposiciones.MVC.Auxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimulacroOposiciones.MVC.StartMenu
{
    public class Controller
    {
        private Model _model; 
        private View _view;

        public Controller(View view)
        {
            _model = new Model();
            _view = view;
            setListeners();
        }

        private void setListeners()
        {
            _view.btn_auxiliar.Click += Auxiliar;
            _view.btn_laboratorio.Click += Laboratorio;
            _view.btn_celador.Click += Celador;
        }

        private void Auxiliar(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.Auxiliar.View());
        }

        private void Laboratorio(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.Auxiliar.View());
        }

        private void Celador(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.Auxiliar.View());
        }
    }
}
