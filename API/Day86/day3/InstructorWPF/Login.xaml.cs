using InstructorWPF.Models;
using Newtonsoft.Json;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (email.Text.Length > 0 && password.Password.Length > 0)
            {
                HttpClient client = new HttpClient();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters["email"] = email.Text;
                parameters["password"] = password.Password;
                var responce = client.PostAsync("https://localhost:7109/api/User/Login",
                    new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(parameters),
                    Encoding.UTF8, "application/json")).Result;

                if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var instructors = new MainWindow(responce.Content.ReadAsStringAsync().Result);
                    instructors.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Wrong info");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var Reg = new Register();
            Reg.ShowDialog();
        }
    }
}
