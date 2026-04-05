using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacroOposiciones.MVC.Ask
{
    public class Controller
    {
        private Model _model;
        private View _view;

        private int _index;
        private List<Question> _questions;
        public Controller(View view, int index, List<Question> questions)
        {
            _index = index;
            questions = _questions;

            _model = new Model();
            _view = view;
            setListeners();

            _view.lbl_question.Content = _questions[_index].question;
            _view.lbl_r1.Text = _questions[_index].options[0].option;
            _view.lbl_r2.Text = _questions[_index].options[1].option;
            _view.lbl_r3.Text = _questions[_index].options[2].option;
            _view.lbl_r4.Text = _questions[_index].options[3].option;

        }

        private void setListeners()
        {
        }


    }
}
