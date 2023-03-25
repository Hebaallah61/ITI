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
    /// Interaction logic for FinalizePayment.xaml
    /// </summary>
    public partial class FinalizePayment : Window
    {
        public FinalizePayment()
        {
            InitializeComponent();
          
            comboBox1.ItemsSource = _monthNumbers;
            comboBox2.ItemsSource = _YearNumbers;
            comboBox2_Copy.ItemsSource = _CardType;
            comboBox0.ItemsSource = _paymentType;
        }

        public string[] _paymentType =  { "Credit", "Debit" };
        private string[] _monthNumbers = new string[]
       {
            "1", "2","3","4","5","6","7","8","9","10","11","12"
       };
        private string[] _YearNumbers = new string[]
      {
            "14", "15","16","17","18","19","20","21","22","23","24","25"
      };
        private string[] _CardType = new string[]
        {
            "Paybal", "Visa", "MasterCard","Miza"
        };

        public int totalAmountFromFrontend = 0;
        public int foodBill = 0;
        private double finalTotalFinalized = 0.0;
        public double FinalTotalFinalized
        {
            get { return finalTotalFinalized; }
            set { finalTotalFinalized = value; }
        }
        private string paymentCardNumber;
        public string PaymentCardNumber
        {
            get { return paymentCardNumber; }
            set { paymentCardNumber = value; }
        }
        private string MM_YY_Of_Card;

        public string MM_YY_Of_Card1
        {
            get { return MM_YY_Of_Card; }
            set { MM_YY_Of_Card = value; }
        }
        private string CVC_Of_Card;

        public string CVC_Of_Card1
        {
            get { return CVC_Of_Card; }
            set { CVC_Of_Card = value; }
        }
        private string CardType;

        public string CardType1
        {
            get { return CardType; }
            set { CardType = value; }
        }

        private string paymentType;

        public string paymentType1
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

       

        private void textBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                paymentCardNumber = textBox_Copy.Text;
                MM_YY_Of_Card = comboBox1.Text + "/" + comboBox2.Text;
                CVC_Of_Card1 = textBox.Text;
                CardType1 = comboBox2_Copy.Text;
                paymentType1 = comboBox0.Text;
                this.Hide();
            }
            catch {
                MessageBox.Show("Error Closing the window");
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
             
                double totalWithTax = Convert.ToDouble(totalAmountFromFrontend) * 0.07;
                double FinalTotal = Convert.ToDouble(totalAmountFromFrontend) + totalWithTax + foodBill;
                label_Copy3.Content = "$" + Convert.ToString(totalAmountFromFrontend) + "USD";
                label_Copy9.Content = "$" + Convert.ToString(foodBill) + "USD";
                label_Copy4.Content = "$" + Convert.ToString(totalWithTax) + "USD";
                label_Copy7.Content = "$" + Convert.ToString(FinalTotal) + "USD";
                
                FinalTotalFinalized = FinalTotal;
               


        }
    }
}
