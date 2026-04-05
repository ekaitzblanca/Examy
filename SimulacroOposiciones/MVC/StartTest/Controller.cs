using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            _view.lbl_category.Content = _category;
            _view.lbl_mode.Content = _mode;
            _view.lbl_type.Content = _type;
        }

        public void setListeners()
        {
 
        }
    }
}
