using HotalDAL.DBcontext;
using HotalDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Frontend.xaml
    /// </summary>
    public partial class Frontend : Window
    {
        FoodMenu menu;
        FinalizePayment payment;
        private readonly Context dbContext = new Context();
        public Frontend()
        {
            InitializeComponent();
            menu = new FoodMenu();
            payment = new FinalizePayment();
            comboBox.ItemsSource = _monthNames;
            comboBox1.ItemsSource = _day;
            comboBox3.ItemsSource = _gender;
            comboBox2.ItemsSource = _state;
            comboBox4.ItemsSource = _guests;
            comboBox6.ItemsSource = _roomTypes;
            comboBox5.ItemsSource = _floor;
            comboBox7.ItemsSource = _floorNumber;
            var resvList = (from r in dbContext.Reservations select r.Id + "-" + r.first_name + r.last_name).ToList();
            CLi.ItemsSource = resvList;
            dbContext.Reservations.Load();
            var occupied = (from p in dbContext.Reservations.Where(p => p.check_in == true) select  p.room_number +" "+ p.room_type + " " + p.Id + " " + p.first_name + " " + p.last_name + " " + p.phone_number ).ToList();
            listBox1.ItemsSource = occupied;
            var Reserved = (from p in dbContext.Reservations.Where(p => p.check_in == false) select  p.room_number + " " + p.room_type + " " + p.Id + " " + p.first_name + " " + p.last_name + " " + p.phone_number + " " + p.arrival_time + " " + p.leaving_time ).ToList();
            listBox2.ItemsSource = Reserved;
            var R = (from p in dbContext.Reservations select p).ToList();
            dataGrid1.ItemsSource = R;
            button2.Visibility = Visibility.Hidden;
        }
        public string towelS, cleaningS, surpriseS;

        public int foodBill;
        public int CurrentBill;
        public int Tax = 20;

        public string food_menu = "";
        public int totalAmount = 0;
        public int checkin = 0;
        public int foodStatus = 0;
        public Int32 primartyID = 0;
        public bool taskFinder = false;
        public bool editClicked = false;
        public string FPayment, FCnumber, FcardExpOne, FcardExpTwo, FCardCVC;
        private double finalizedTotalAmount = 0.0;
        private string paymentType;
        private string paymentCardNumber;
        private string MM_YY_Of_Card;
        private string CVC_Of_Card;
        private string CardType;

        private int lunch = 0; private int breakfast = 0; private int dinner = 0;
        private string cleaning; private string towel;
        private string surprise;

        private string[] _monthNames = new string[]
       {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
       };
        private string[] _day = new string[]
        {
            "1", "2", "3", "4", "5", "6",
            "7", "8", "9", "10", "11", "12","13","14","15","16","17","18","19","20","21","22"
            ,"23","24","25","26","27","28","29","30","31"
        };
        private string[] _gender = new string[]
        {
            "Male","Female","Other"
        };

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Label_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                label1.Visibility = Visibility.Hidden;
            }
            else
            {
                label1.Visibility = Visibility.Hidden;
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
            var occupied = (from p in dbContext.Reservations.Where(p => p.check_in == false) select new { p.room_number, p.room_type, p.Id, p.first_name, p.last_name, p.phone_number }).ToList();
            listBox1.ItemsSource = occupied;
            
        }

        private void listBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            dataGrid.Visibility = Visibility.Visible;

            var reservations = dbContext.Reservations.ToList();
            string searchText = Search.Text;
            List<HotalDAL.Entities.Reservation> searchedReservation = new List<HotalDAL.Entities.Reservation>();
            var list = dbContext.Reservations.Where(p => (p.first_name + p.last_name + p.Id + p.email_address + p.city + p.card_cvc + p.arrival_time + p.food_bill + p.state + p.zip_code + p.total_bill + p.card_number).Contains(searchText)).ToList();
            dataGrid.ItemsSource = list;


        }

        private void CLi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CLi.SelectedItem != null)
            {

                var R = CLi.SelectedItem.ToString().Split("-");
                var resv = dbContext.Reservations.Find(int.Parse(R[0]));
                textBox.Text = resv.first_name;
                textBox1.Text = resv.last_name;

                string[] birthday = resv.birth_day.Split('-');
                string year, month, day;
                month = birthday[0];
                
                day = birthday[1];
                year = birthday[2];

                comboBox.SelectedItem = birthday[0].Trim().ToString();
                            
                comboBox1.SelectedValue = day;
                textBox2.Text = year;
                comboBox3.SelectedValue = resv.gender.Trim().ToString();
                textBox3.Text = resv.phone_number;
                textBox4.Text = resv.email_address;
                textBox5.Text = resv.street_address;
                textBox6.Text = resv.apt_suite;
                textBox7.Text = resv.city;
                comboBox2.SelectedItem = resv.state.Trim().ToString();
                textBox8.Text = resv.zip_code;
                comboBox4.SelectedItem = resv.number_guest.ToString();
                comboBox5.SelectedItem = resv.room_floor.Trim().ToString();
                comboBox7.SelectedItem = resv.room_number.Trim().ToString();
                comboBox6.SelectedItem = resv.room_type.Trim().ToString();

                datePicker.Text = resv.arrival_time.ToString();
                datePicker1.Text = resv.leaving_time.ToString();
                checkBox.IsChecked = resv.check_in;
                checkBox2.IsChecked = resv.supply_status;
                
            }
            else
            {
                CLi.SelectedItem = "";
            }
        }

        private string[] _state = new string[]
        {
            "Alabama","Alaska","Arkansas","California","Colorado","Connecticut","Delaware","Florida","Georgia","Hawaii",
            "Idaho","Illinois","Indiana","lowa","Kansas","Kentucky","Louisiana","Moine","Maryland","Massachusetts",
            "Michigan","Minnesota","Mississippi",
            "Missouri","Montana Nebraska","Nevada","New Hampshire","New Jersey","New Mexico","New York","North Carolina","North Dakota",
            "Ohio","Oklahoma","Oregon","Pennsylvania Rhode","South Dakota",
            "Tennessee","Texas","Utah","Vermont","Virginia","Washington","West Virginia","Wisconsin","Wyoming"
        };

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var R = CLi.SelectedValue.ToString().Split("-");
            var id = int.Parse(R[0]);
            var obj = dbContext.Reservations.Find(id);
            taskFinder = true;
            obj.first_name = textBox.Text;
            obj.last_name = textBox1.Text;

            obj.birth_day = (Array.IndexOf(_monthNames, comboBox.SelectedValue.ToString()) + 1) + "-" +
                comboBox1.SelectedValue.ToString() + "-" + comboBox2.Text;

            obj.gender = comboBox3.SelectedValue.ToString();

            obj.phone_number = textBox3.Text;

            obj.email_address  = textBox4.Text;

            obj.number_guest = int.Parse(comboBox4.SelectedValue.ToString());
            obj.street_address = textBox5.Text;
            obj.apt_suite = textBox6.Text;
            obj.city = textBox7.Text;

            obj.state = comboBox2.SelectedValue.ToString();
            obj.zip_code = textBox8.Text;
            obj.room_floor = comboBox5.SelectedValue.ToString();
            obj.room_number = comboBox7.SelectedValue.ToString();
            obj.room_type = comboBox6.SelectedValue.ToString();

            obj.arrival_time = DateTime.Parse(datePicker.Text);
            obj.leaving_time = DateTime.Parse(datePicker1.Text);
            obj.check_in = (bool)checkBox.IsChecked;
            obj.supply_status = (bool)checkBox2.IsChecked;

            obj.card_exp = payment.MM_YY_Of_Card1;
            obj.total_bill = (float)payment.FinalTotalFinalized;
            obj.payment_type = payment.paymentType1;
            obj.card_type = payment.CardType1;
            obj.card_number = payment.PaymentCardNumber;
            obj.towel = menu.Towel;
            obj.cleaning= menu.Cleaning;
            obj.s_surprise = menu.Surprise;
            obj.food_bill = payment.foodBill;
            obj.card_cvc = payment.CVC_Of_Card1;
            obj.break_fast = menu.BreakfastQ;
            obj.dinner = menu.DinnerQ;
            obj.lunch = menu.LunchQ;

            try
            {
                int num = dbContext.SaveChanges(); if (num > 0) { MessageBox.Show("reservation has been Updated successfully"); }
            }
            catch
            {
                MessageBox.Show("Sorry the date is not complete");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var R = CLi.SelectedValue.ToString().Split("-");
            var id = int.Parse(R[0]);
            var obj = dbContext.Reservations.Find(id);
            dbContext.Reservations.Remove(obj);

            int num = dbContext.SaveChanges();
            if (num > 0) { MessageBox.Show("reservation has been Deleted successfully"); }

            var resvList = (from p in dbContext.Reservations select p.Id + "-" + p.first_name + p.last_name).ToList();
            CLi.ItemsSource = resvList;

            CLi.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (breakfast == 0 && lunch == 0 && dinner == 0 && cleaning == "0" && towel == "0" && surprise == "0")
            {
                checkBox2.IsChecked = true;
            }
            Update.IsEnabled = true;

            finalizedTotalAmount = payment.FinalTotalFinalized;
            paymentType = payment.paymentType1;
            paymentCardNumber = payment.PaymentCardNumber;
            MM_YY_Of_Card = payment.MM_YY_Of_Card1;
            CVC_Of_Card = payment.CVC_Of_Card1;
            CardType = payment.CardType1;

            if (!editClicked)
            {
                button2.Visibility = Visibility.Visible;
            }
            if (menu.B1.IsChecked == true)
            {
                foodBill += menu.BreakfastQ;

            }
            if (menu.D1.IsChecked == true)
            {
                foodBill += menu.DinnerQ;
            }
            if (menu.L1.IsChecked == true)
            {
                foodBill += menu.LunchQ;
            }
            if (comboBox6.SelectedValue == "Single")
            { CurrentBill = 20; }
            else if (comboBox6.SelectedValue == "Double")
            { CurrentBill = 30; }
            else if (comboBox6.SelectedValue == "Twin")
            { CurrentBill = 40; }
            else if (comboBox6.SelectedValue == "Doublex")
            { CurrentBill = 50; }
            else if (comboBox6.SelectedValue == "Suite")
            { CurrentBill = 60; }
            totalAmount = CurrentBill + foodBill + Tax;
            payment.totalAmountFromFrontend = totalAmount;
            payment.foodBill = foodBill;

            if (taskFinder)
            {
                payment.comboBox0.SelectedItem = FPayment.Replace(" ", string.Empty);
                payment.textBox_Copy.Text = FCnumber;
                payment.comboBox1.SelectedItem = FcardExpOne;
                payment.comboBox2.SelectedItem = FcardExpTwo;
                payment.textBox.Text = FCardCVC;
            }


            payment.ShowDialog();
            
            button2.Visibility = Visibility.Visible;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reservation resv = new Reservation();
            resv.first_name = textBox.Text;
            resv.last_name = textBox1.Text;

            resv.birth_day = (Array.IndexOf(_monthNames, comboBox.SelectedValue.ToString()) + 1) + "-" +
                comboBox1.SelectedValue.ToString() + "-" + comboBox2.Text;

            resv.gender = comboBox3.SelectedValue.ToString();

            resv.phone_number = textBox3.Text;

            resv.email_address = textBox4.Text;

            resv.number_guest = int.Parse(comboBox4.SelectedValue.ToString());
            resv.street_address = textBox5.Text;
            resv.apt_suite = textBox6.Text;
            resv.city = textBox7.Text;

            resv.state = comboBox2.SelectedValue.ToString();
            resv.zip_code = textBox8.Text;
            resv.room_floor = comboBox5.SelectedValue.ToString();
            resv.room_number = comboBox7.SelectedValue.ToString();
            resv.room_type = comboBox6.SelectedValue.ToString();

            resv.arrival_time = DateTime.Parse(datePicker.Text);
            resv.leaving_time = DateTime.Parse(datePicker1.Text);
            resv.check_in = (bool)checkBox.IsChecked;
            resv.supply_status = (bool)checkBox2.IsChecked;

            resv.card_exp = payment.MM_YY_Of_Card1;
            resv.total_bill = (float)payment.FinalTotalFinalized;
            resv.payment_type = payment.paymentType1;
            resv.card_type = payment.CardType1;
            resv.card_number = payment.PaymentCardNumber;
            resv.towel = menu.Towel;
            resv.cleaning = menu.Cleaning;
            resv.s_surprise = menu.Surprise;
            resv.food_bill = payment.foodBill;
            resv.card_cvc = payment.CVC_Of_Card1;
            resv.break_fast = menu.BreakfastQ;
            resv.dinner = menu.DinnerQ;
            resv.lunch = menu.LunchQ;

            dbContext.Reservations.Add(resv);
            int num = dbContext.SaveChanges();
            if (num > 0)

                MessageBox.Show("the reservation has been entered successfully");

            var resvList = (from p in dbContext.Reservations select p.Id + "-" + p.first_name + p.last_name).ToList();
            CLi.ItemsSource = resvList;

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "First";
            textBox1.Text = "Last";
            comboBox.ItemsSource = _monthNames;
            comboBox.SelectedIndex = -1;
            comboBox1.ItemsSource = _day;
            comboBox1.SelectedIndex = -1;
            comboBox3.ItemsSource = _gender;
            comboBox3.SelectedIndex = -1;
            comboBox2.ItemsSource = _state;
            comboBox2.SelectedIndex = -1;
            comboBox4.ItemsSource = _guests;
            comboBox4.SelectedIndex = -1;
            comboBox6.ItemsSource = _roomTypes;
            comboBox6.SelectedIndex = -1;
            comboBox5.ItemsSource = _floor;
            comboBox5.SelectedIndex = -1;
            comboBox7.ItemsSource = _floorNumber;
            comboBox7.SelectedIndex = -1;
            textBox3.Text = "000 000 000";
            textBox4.Text = "heba@g.com";
            textBox5.Text = "Street Address";
            textBox6.Text = "APT./Suite";
            textBox7.Text = "City";
            textBox8.Text = "Zip Code";
            var resvList = (from r in dbContext.Reservations select r.Id + "-" + r.first_name + r.last_name).ToList();
            CLi.ItemsSource = resvList;
            dbContext.Reservations.Load();
            var occupied = (from p in dbContext.Reservations.Where(p => p.check_in == true) select p.room_number + " " + p.room_type + " " + p.Id + " " + p.first_name + " " + p.last_name + " " + p.phone_number).ToList();
            listBox1.ItemsSource = occupied;
            var Reserved = (from p in dbContext.Reservations.Where(p => p.check_in == false) select p.room_number + " " + p.room_type + " " + p.Id + " " + p.first_name + " " + p.last_name + " " + p.phone_number + " " + p.arrival_time + " " + p.leaving_time).ToList();
            listBox2.ItemsSource = Reserved;
            var R = (from p in dbContext.Reservations select p).ToList();
            dataGrid1.ItemsSource = R;
            button2.Visibility = Visibility.Hidden;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (taskFinder)
            {
                if (breakfast > 0)
                {
                    menu.B1.IsChecked = true;
                    menu.q1.Text = Convert.ToString(breakfast);
                }
                if (lunch > 0)
                {
                    menu.L1.IsChecked = true;

                    menu.q2.Text = Convert.ToString(lunch);
                }
                if (dinner > 0)
                {
                    menu.D1.IsChecked = true;
                    menu.q3.Text = Convert.ToString(dinner);
                }
                if (cleaning == "1")
                {
                    menu.c1.IsChecked = true;
                }
                if (towel == "1")
                {
                    menu.t1.IsChecked = true;
                }
                if (surprise == "1")
                {
                    menu.c2.IsChecked = true;
                }
            }
            menu.ShowDialog();

            breakfast = menu.BreakfastQ;
            lunch = menu.LunchQ;
            dinner = menu.DinnerQ;

            cleaning = menu.c1.ToString();
            towel = menu.t1.ToString();

            surprise = menu.c2.ToString();

            if (breakfast > 0 || lunch > 0 || dinner > 0)
            {
                int bfast = 7 * breakfast;
                int Lnch = 15 * lunch;
                int di_ner = 15 * dinner;
                foodBill = bfast + Lnch + di_ner;
            }
            //menu.ShowDialog();
        }

        private string[] _guests = new string[]
        {
            "1" , "2" , "3" , "4" , "5" , "6"
        };

        private string[] _roomTypes = new string[]
        {
            "Single", "Double", "Twin", "Douplex", "Suite"
        };

        private string[] _floor = new string[]
        {
           "1" , "2" , "3" , "4" , "5"
        };

        private string[] _floorNumber = new string[]
        {
            "203" , "204" , "205" , "206" , "207" , "208" ,"209" , "300" ,
            "301" , "302" , "303" , "304" , "305" ,"400" , "401" , "402" ,
            "403" , "404" , "405" , "500" , "501" , "502" , "503" ,"504" ,
            "505" , "506" , "507" , "508" , "509" , "700"
        };
        private DateTime temp;

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Update.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Visible;
            CLi.Visibility = Visibility.Visible;
        }
    }
}
