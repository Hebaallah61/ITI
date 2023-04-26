using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InstructorWPF
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (em.Text.Length > 0 && pa.Text.Length > 0 && p.Text.Length > 0 && n.Text.Length > 0 && po.Text.Length > 0)
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["email"] = em.Text;
                parameters["pass"] = pa.Text;
                parameters["phone"] = p.Text;
                parameters["position"] = po.Text;
                parameters["name"] = n.Text;
                parameters["secret"] = "instructor";
  

                var responce = client.PostAsync("https://localhost:7109/api/User/Register",
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(parameters),
                    Encoding.UTF8, "application/json")).Result;

                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var instructors = new MainWindow(responce.Content.ReadAsStringAsync().Result);
                    instructors.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Canot Regiset");
                }
            }
        }
    }
}
