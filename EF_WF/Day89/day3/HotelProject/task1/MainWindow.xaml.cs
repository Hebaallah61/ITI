using HotalDAL.DBcontext;
using HotalDAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public partial class MainWindow : Window
    {
        private readonly Context dbContext = new Context();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string username = U.Text;
            string password = passwordBox.Password;

            HotalDAL.Entities.Kitchen kitchen = dbContext.Kitchens.FirstOrDefault(u => u.Username == username && u.Password == password);
            HotalDAL.Entities.Frontend frontend = dbContext.Frontends.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (kitchen != null)
            {
                this.Hide();
                Kitchen kitchen_management = new Kitchen();
                kitchen_management.Show();
                kitchen_management.Closed += (sender, e) => Close();

            }
            else if(frontend != null)
            {
                this.Hide();
                Frontend hotel_management = new();
                hotel_management.Update.Visibility = Visibility.Hidden;
                hotel_management.Delete.Visibility = Visibility.Hidden;
                hotel_management.CLi.Visibility = Visibility.Hidden;
                hotel_management.dataGrid.Visibility = Visibility.Hidden;
                hotel_management.Show();

                hotel_management.Closed += (sender, e) => Close();
            }
            else
            {
                MessageBox.Show("User does not exist in database");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Licene L = new();
            L.Show();

            L.Closed += (sender, e) => Close();
        }
    }
}