using SimulacroOposiciones.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimulacroOposiciones.MVC.PracticeAsk
{
    public class Model
    {
        public void CheckOptionChecked(View _view, int _index, List<Question> _questions) 
        {
            if (_questions[_index].response != null)
            {
                switch (_questions[_index].response)
                {
                    case "a":
                        _view.rb_option1.IsChecked = true;
                        PintarRadioButton(_view.rb_option1, System.Windows.Media.Brushes.Red, System.Windows.Media.Brushes.DarkRed);
                        break;
                    case "b":
                        _view.rb_option2.IsChecked = true;
                        PintarRadioButton(_view.rb_option2, System.Windows.Media.Brushes.Red, System.Windows.Media.Brushes.DarkRed);
                        break;
                    case "c":
                        _view.rb_option3.IsChecked = true;
                        PintarRadioButton(_view.rb_option3, System.Windows.Media.Brushes.Red, System.Windows.Media.Brushes.DarkRed);
                        break;
                    case "d":
                        _view.rb_option4.IsChecked = true;
                        PintarRadioButton(_view.rb_option4, System.Windows.Media.Brushes.Red, System.Windows.Media.Brushes.DarkRed);
                        break;
                }

                switch (_questions[_index].answer)
                {
                    case "a":
                        PintarRadioButton(_view.rb_option1, System.Windows.Media.Brushes.Green, System.Windows.Media.Brushes.DarkGreen);
                        break;
                    case "b":
                        PintarRadioButton(_view.rb_option2, System.Windows.Media.Brushes.Green, System.Windows.Media.Brushes.DarkGreen);
                        break;
                    case "c":
                        PintarRadioButton(_view.rb_option3, System.Windows.Media.Brushes.Green, System.Windows.Media.Brushes.DarkGreen);
                        break;
                    case "d":
                        PintarRadioButton(_view.rb_option4, System.Windows.Media.Brushes.Green, System.Windows.Media.Brushes.DarkGreen);
                        break;
                }

                _view.rb_option1.IsEnabled = false;
                _view.rb_option2.IsEnabled = false;
                _view.rb_option3.IsEnabled = false;
                _view.rb_option4.IsEnabled = false;
            }
        }

        private void PintarRadioButton(RadioButton rb, Brush fondo, Brush borde)
        {
            rb.ApplyTemplate();

            Border border = rb.Template.FindName("border", rb) as Border;
            if (border != null)
            {
                border.Background = fondo;
                border.BorderBrush = borde;
            }
        }
    }
}
