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

namespace task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<employee> Employees { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Employees = new List<employee>()
            {
                new employee() { Name = "Heba", Id = 100, Description = ".Net dev" ,img="\\img\\1.1.jpg"},
                new employee() { Name = "Ali", Id = 110, Description = "Python dev" ,img="\\img\\1.jpg"},
                new employee() { Name = "Nour", Id = 120, Description = "C++ dev" ,img="\\img\\e1.jpg" },
                new employee() { Name = "Ahmed", Id = 130, Description = "Devop" ,img="\\img\\e4.jpg" },
                new employee() { Name = "Hany", Id = 140, Description = "R dev" ,img="\\img\\e6.jpg"},
                new employee() { Name = "Hana", Id = 150, Description = "Marketing" ,img="\\img\\e5.jpg" },
            };
            lit.ItemsSource = Employees;
        }
    }
}
