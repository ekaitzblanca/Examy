using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimulacroOposiciones.MVC.PracticeResume
{
    public class Controller
    {
        private Model _model;
        private View _view;

        private List<Question> _questions;
        private string _from_view;

        public Controller(View view, List<Question> questions, string from_view)
        {
            _questions = questions;
            _from_view = from_view;

            _model = new Model();
            _view = view;  
            setListeners();

            _view.lbl_correctCount.Text = _questions.Where(x => x.isCorrect == true).ToList().Count.ToString();
            _view.lbl_wrongCount.Text = _questions.Where(x => x.isCorrect == false).ToList().Count.ToString();
            _view.lbl_totalCount.Text = _questions.Count.ToString();

            double percentage = ((double) _questions.Where(x => x.isCorrect == true).ToList().Count / (double) _questions.Count) * 100;
            _view.lbl_percentage.Text = percentage.ToString() + "%";
            _view.progress_score.Value = percentage;

            _view.lbl_resultFeedback.Text = _model.GetFeedBack(percentage);
            _view.lbl_resultAnalysis.Text = _model.GetAnalysis(percentage);

            if (from_view == "practica")
            { 
                _model.SaveHistory(_questions, _from_view);
            }
        }

        public void setListeners()
        {
            _view.btn_Review.Click += Review_Click;
            _view.btn_Back.Click += Back_Click;
        }

        

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.PracticeAsk.View(0, _questions, "review"));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _view.NavigationService?.Navigate(new SimulacroOposiciones.MVC.CategoryMenu.View());
        }
    }
}
