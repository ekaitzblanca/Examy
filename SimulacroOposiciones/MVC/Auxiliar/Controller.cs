using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroOposiciones.MVC.Auxiliar
{
    public class Controller
    {
        private Model _model;
        private View _view;

        public Controller(View view) {
            _model = new Model();

            _view = view;
            setListeners();
        }

        public void setListeners()
        { 
        }
    }
}
