using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.TypeMenu
{
    public class Controller
    {
        private View _view;
        private Model _model;

        private string _category;
        private string _mode;

        public Controller(View view, string category, string mode) {
            _category = category;
            _mode = mode;

            _model = new Model();
            _view = view;
            setListeners();
        }
        
        private void setListeners()
        {
            _view.btn_Comun.Click += Comun_Click;
            _view.btn_Especifico.Click += Especifico_Click;
            _view.btn_Todo.Click += Todo_Click;

            _view.btn_Back.Click += Back_Click;
        }

        private void Comun_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.StartTest.View(_category, _mode, "comun"));
        }

        private void Especifico_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.StartTest.View(_category, _mode, "especifico"));

        }

        private void Todo_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.StartTest.View(_category, _mode, "todo"));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.ModeMenu.View(_category));
        }
    }
}
