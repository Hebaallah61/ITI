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
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Window
    {
        private readonly Context dbContext = new Context();
        Reservation SelectedReservation { get; set; }
        FoodMenu foodMenu;
        public Kitchen()
        {
            InitializeComponent();
            foodMenu = new FoodMenu();
            dbContext.Reservations.Load();
            this.dataGrid.ItemsSource = dbContext.Reservations.Local.ToBindingList();

            var reservations = dbContext.Reservations
    .Where(r => r.check_in && !r.supply_status)
    .Select(r => new
    {
        r.Id,
        r.first_name,
        r.last_name,
        r.phone_number,
        r.room_type,
        r.room_floor,
        r.room_number,
        r.break_fast,
        r.lunch,
        r.dinner,
        r.cleaning,
        r.towel,
        r.s_surprise,
        r.state,
        r.food_bill
    })
    .ToList();
            dataGrid.ItemsSource = reservations;


        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
       
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedReservation = listBox.SelectedItem as Reservation;
            if (selectedReservation != null)
            {
                F.Text = selectedReservation.first_name;
                L.Text = selectedReservation.last_name;
                P.Text = selectedReservation.phone_number;
                RT.Text = selectedReservation.room_type;
                RF.Text = selectedReservation.room_floor;
                R.Text = selectedReservation.room_number;
                BF.Text =selectedReservation.break_fast.ToString();
                LU.Text = selectedReservation.lunch.ToString();
                DI.Text = selectedReservation.dinner.ToString();
                CL.IsChecked = selectedReservation.cleaning;
                TO.IsChecked = selectedReservation.towel;
                TT.IsChecked = selectedReservation.s_surprise;
                FOOD.IsChecked = selectedReservation.supply_status;
            }
        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            var reservations =(from r in dbContext.Reservations where
            r.check_in && !r.supply_status select
               r.Id+ "-"+ r.first_name + " " + r.last_name +"-"+ r.phone_number
       
           )
           .ToList();
           listBox.ItemsSource = reservations;

            listBox.SelectionChanged += (s, ev) =>
            {
               
                //var selectedId = (s as ListBox).SelectedItem?.GetType().GetProperty("Id")?.GetValue((s as ListBox).SelectedItem);
                //if (selectedId != null)
                if(listBox.SelectedItem!=null)
                {
                    var LSplit = listBox.SelectedItem.ToString().Split("-");
                    var resv = dbContext.Reservations.Find(int.Parse(LSplit[0]));
                    //var selectedReservation = dbContext.Reservations.FirstOrDefault(r => r.Id == (int)selectedId);
                    //if (selectedReservation != null)
                    //{
                       //SelectedReservation = selectedReservation;
                        F.Text = resv.first_name;
                        L.Text = resv.last_name;
                        P.Text = resv.phone_number;
                        RT.Text = resv.room_type;
                        RF.Text = resv.room_floor;
                        R.Text = resv.room_number;
                        BF.Text = resv.break_fast.ToString();
                        LU.Text = resv.lunch.ToString();
                        DI.Text = resv.dinner.ToString();
                        CL.IsChecked = resv.cleaning;
                        TO.IsChecked = resv.towel;
                        TT.IsChecked= resv.s_surprise;
                        FOOD.IsChecked = resv.supply_status;
                    //}
                    
                }
                 
            };


        }

        private void FOOD_Checked(object sender, RoutedEventArgs e)
        {

        }
        int dinner;
        int lunch;
        int breakfast;
        private void button_Click(object sender, RoutedEventArgs e)
        {
            foodMenu.label.Visibility =Visibility.Hidden;
            foodMenu.c1.Visibility =Visibility.Hidden;
            foodMenu.c2.Visibility =Visibility.Hidden;
            foodMenu.t1.Visibility =Visibility.Hidden;

            foodMenu.ShowDialog();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            breakfast =foodMenu.BreakfastQ / 7;
            BF.Text = breakfast.ToString();

            lunch = foodMenu.LunchQ / 15;
            LU.Text = lunch.ToString();

            dinner = foodMenu.DinnerQ / 15;
            DI.Text = dinner.ToString();

            var LSplit = listBox.SelectedValue.ToString().Split("-");
            var id = int.Parse(LSplit[0]);
            var obj = dbContext.Reservations.Find(id);

            obj.lunch = lunch;
            obj.break_fast = breakfast;
            obj.dinner = dinner;

            obj.food_bill = foodMenu.BreakfastQ + foodMenu.LunchQ + foodMenu.DinnerQ;

            obj.cleaning = (bool)CL.IsChecked;
            obj.s_surprise = (bool)TT.IsChecked;
            obj.towel = (bool)TO.IsChecked;
            obj.supply_status = (bool)FOOD.IsChecked;

            dbContext.SaveChanges();
            MessageBox.Show("Done");
            var resvList = (from p in dbContext.Reservations where p.supply_status == false select p.Id + "-" + p.first_name + " " + p.last_name).ToList();
            listBox.ItemsSource = resvList;
            var reservations = dbContext.Reservations
   .Where(r => r.check_in && !r.supply_status)
   .Select(r => new
   {
       r.Id,
       r.first_name,
       r.last_name,
       r.phone_number,
       r.room_type,
       r.room_floor,
       r.room_number,
       r.break_fast,
       r.lunch,
       r.dinner,
       r.cleaning,
       r.towel,
       r.s_surprise,
       r.state,
       r.food_bill
   })
   .ToList();
            dataGrid.ItemsSource = reservations;

        }
    }
}
