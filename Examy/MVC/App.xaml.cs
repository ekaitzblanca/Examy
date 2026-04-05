using SimulacroOposiciones.MVC.CategoryMenu;
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

namespace SimulacroOposiciones.MVC
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Window
    {
        public App()
        {
            InitializeComponent();
            Pages.Navigate(new MVC.CategoryMenu.View());
        }
    }
}
