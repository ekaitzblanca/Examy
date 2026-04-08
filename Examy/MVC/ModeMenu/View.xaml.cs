using SimulacroOposiciones.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimulacroOposiciones.MVC.ModeMenu
{
    /// <summary>
    /// Lógica de interacción para View.xaml
    /// </summary>
    public partial class View : Page
    {
        public View(string category)
        {
            InitializeComponent();

            lbl_version.Text = Gen.version;
            Controller controller = new Controller(this, category);
        }
    }
}
