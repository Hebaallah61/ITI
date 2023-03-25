using HotalDAL.DBcontext;
using HotalDAL.Entities;
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
using System.Windows.Shapes;

namespace task1
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : Window
    {
        private readonly Context dbContext = new Context();
       // public Dictionary<string, string>? Data { get; set; }

        
        public FoodMenu()
        {
            InitializeComponent();
            DataContext = this;

            //var selectedReservation = dbContext.Reservations.FirstOrDefault(r => r.Id == (int)selectedId);

            //if (B1.IsChecked == true && int.Parse(q3.Text) > 0) B1.IsChecked = true;
            //    if (L1.IsChecked == true && int.Parse(q1.Text) > 0) L1.IsChecked = true;
            //    if (D1.IsChecked == true && int.Parse(q2.Text) > 0) D1.IsChecked = true;
            //    if(c1.IsChecked==true)c1.IsChecked = true;
            //    if(t1.IsChecked== true)t1.IsChecked = true;
            //    if(c2.IsChecked==true)c2.IsChecked = true;

        }
        private int lunchQ = 0;

        public int LunchQ
        {
            get { return lunchQ; }
            set { lunchQ = value; }
        }
        private int breakfastQ = 0;

        public int BreakfastQ
        {
            get { return breakfastQ; }
            set { breakfastQ = value; }
        }
        private int dinnerQ = 0;

        public int DinnerQ
        {
            get { return dinnerQ; }
            set { dinnerQ = value; }
        }

        private bool cleaning = false;

        public bool Cleaning
        {
            get { return cleaning; }
            set { cleaning = value; }
        }
        private bool towel = false;

        public bool Towel
        {
            get { return towel; }
            set { towel = value; }
        }

        private bool surprise = false;

        public bool Surprise
        {
            get { return surprise; }
            set { surprise = value; }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //var selectedReservation = dbContext.Reservations.FirstOrDefault(r => r.Id ==int.Parse(Data["Id"]));

            //selectedReservation.break_fast = B1.IsChecked == true ? int.Parse(q3.Text) : 0;
            //selectedReservation.lunch = L1.IsChecked == true ? int.Parse(q1.Text) : 0;
            //selectedReservation.dinner = D1.IsChecked == true ? int.Parse(q2.Text) : 0;

            //dbContext.SaveChanges();

            //Close();

            if (B1.IsChecked == true)
            {
                BreakfastQ = Convert.ToInt32(q3.Text) * 7;
            }
            if (L1.IsChecked == true)
            {
                LunchQ = Convert.ToInt32(q1.Text) * 15;
            }
            if (D1.IsChecked == true)
            {
                DinnerQ = Convert.ToInt32(q2.Text) * 15;
            }
            if (c1.IsChecked == true)
            {
                Cleaning = true;
            }
            if (t1.IsChecked == true)
            {
                Towel = true;
            }
            if (c2.IsChecked == true)
            {
                Surprise = true;
            }

            this.Hide();
        }
    }

}
