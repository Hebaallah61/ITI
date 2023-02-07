using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Dictionary<string,string>info= new Dictionary<string,string>();
        private void playinfo(object sender, RoutedEventArgs e)
        {
            info.Add("fname", fname.Text);
            info.Add("lname", lname.Text);
            info.Add("gender", gender.Text);
            info.Add("address", address.Text);
            info.Add("phone", phone.Text);
            info.Add("mobile", mobile.Text);
            info.Add("email", email.Text);
            info.Add("jobtitle", jobtitle.Text);
            StringBuilder b = new();
            foreach (KeyValuePair<string, string> item in info) 
            { b.AppendFormat("{0} : {1}{2}",item.Key,item.Value,Environment.NewLine); }
            string r=b.ToString().TrimEnd();
            MessageBoxResult result;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBoxButton button = MessageBoxButton.OKCancel;
            button = MessageBoxButton.OK;
            result = MessageBox.Show(r, "Info", MessageBoxButton.OKCancel,icon);
            if (result == MessageBoxResult.Cancel)
            {
                fname.Clear();
                lname.Clear();
                gender.Clear();
                address.Clear();
                phone.Clear();
                mobile.Clear();
                email.Clear();
                jobtitle.Clear();
                info.Clear();

            }
            else if (result == MessageBoxResult.OK)
            {
                
                icon = MessageBoxImage.None;
                MessageBox.Show("Data saved successfully", "Saving", button, icon, MessageBoxResult.OK);
                info.Clear();
            }


        }
        private void clearinfo(object sender, RoutedEventArgs e)
        {
            fname.Clear();
            lname.Clear();
            gender.Clear();
            address.Clear();
            phone.Clear();
            mobile.Clear();
            email.Clear();
            jobtitle.Clear();
            info.Clear();

        }

        }
            


    
}
