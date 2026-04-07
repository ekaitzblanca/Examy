using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.PracticeAsk
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
            _questions = questions;

            _model = new Model();
            _view = view;
            setListeners();

            _view.lbl_question.Text = _index+1 + ". (" + _questions[_index].number.Replace(".", "") + ") " + _questions[_index].question;
            _view.lbl_r1.Text = _questions[_index].options[0].letter + ") " + _questions[_index].options[0].option;
            _view.lbl_r2.Text = _questions[_index].options[1].letter + ") " + _questions[_index].options[1].option;
            _view.lbl_r3.Text = _questions[_index].options[2].letter + ") " + _questions[_index].options[2].option;
            _view.lbl_r4.Text = _questions[_index].options[3].letter + ") " + _questions[_index].options[3].option;

            _model.CheckOptionChecked(_view, _index, _questions);
        }

        private void setListeners()
        {
            _view.rb_option1.Checked += option1_Checked;
            _view.rb_option2.Checked += option2_Checked;
            _view.rb_option3.Checked += option3_Checked;
            _view.rb_option4.Checked += option4_Checked;

            _view.btn_Previous.Click += Previous_Click;
            _view.btn_Next.Click += Next_Click;
            _view.btn_Fin.Click += Fin_Click;
        }

        private void option1_Checked(object sender, RoutedEventArgs e)
        {
            _questions[_index].response = "a";
            if (_questions[_index].response == _questions[_index].answer)
            {
                _questions[_index].isCorrect = true;
            }

            _model.CheckOptionChecked(_view, _index, _questions);
        }

        private void option2_Checked(object sender, RoutedEventArgs e)
        {
            _questions[_index].response = "b";
            if (_questions[_index].response == _questions[_index].answer)
            {
                _questions[_index].isCorrect = true;
            }

            _model.CheckOptionChecked(_view, _index, _questions);
        }

        private void option3_Checked(object sender, RoutedEventArgs e)
        {
            _questions[_index].response = "c";
            if (_questions[_index].response == _questions[_index].answer)
            {
                _questions[_index].isCorrect = true;
            }

            _model.CheckOptionChecked(_view, _index, _questions);
        }

        private void option4_Checked(object sender, RoutedEventArgs e)
        {
            _questions[_index].response = "d";
            if (_questions[_index].response == _questions[_index].answer)
            {
                _questions[_index].isCorrect = true;
            }

            _model.CheckOptionChecked(_view, _index, _questions);
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (_index == 0)
            { 
                MessageBox.Show("No hay preguntas anteriores");
                return;
            }

            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(_index-1, _questions));
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_index == 49)
            {
                MessageBox.Show("No hay preguntas siguientes");
                return;
            }

            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(_index+1, _questions));
        }

        private void Fin_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeResume.View(_questions));
        }
    }
}
