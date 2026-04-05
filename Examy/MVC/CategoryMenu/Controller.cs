using SimulacroOposiciones.MVC.ModeMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimulacroOposiciones.MVC.CategoryMenu
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
            _view.btn_auxiliar.Click += Auxiliar_Click;
            _view.btn_laboratorio.Click += Laboratorio_Click;
            _view.btn_celador.Click += Celador_Click;
        }

        private void Auxiliar_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.ModeMenu.View("auxiliar"));
        }

        private void Laboratorio_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.ModeMenu.View("laboratorio"));
        }

        private void Celador_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.ModeMenu.View("celador"));
        }
    }
}
