using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
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
using static System.Net.Mime.MediaTypeNames;

namespace task3
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

        private void Settext(object sender, RoutedEventArgs e)
        {
            bt.Document.Blocks.Clear();
            bt.AppendText("Replace default text with initial text value");
        }
        private void Selectall(object sender, RoutedEventArgs e)
        {

            bt.Focus();
            bt.SelectAll();
            
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            bt.Document.Blocks.Clear();
        }
        private void Prpend(object sender, RoutedEventArgs e)
        {
            //Paragraph p = new Paragraph();
            //p.Inlines.Add("*** inserted text *** "); 
            //bt.Document.Blocks.InsertBefore(bt.Document.Blocks.FirstBlock, p);

            TextRange textRange = new TextRange(bt.Document.ContentStart,bt.Document.ContentStart);
            textRange.Text = "*** Prepended text ***";
        }
        private void Insert(object sender, RoutedEventArgs e)
        {
            
            bt.CaretPosition.InsertTextInRun("***inserted text ***");
        }
        private void Append(object sender, RoutedEventArgs e)
        {
            bt.AppendText("*** appended text ***");
        }
        private void Cut(object sender, RoutedEventArgs e)
        {
            if (bt.Selection.Text.Equals("")) 
            { MessageBox.Show($"select first to cut"); }
            else
            {
                bt.Cut();
                MessageBox.Show($"Cut:{Clipboard.GetText()}");
                
            }
            
        }
        private void Paste_(object sender, RoutedEventArgs e)
        {
            
            bt.Paste();
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            bt.Undo();
        }

        private void Change_acc(object sender, RoutedEventArgs e)
        {
            
            if (sender is RadioButton btn)
                switch (btn.Name)
                {
                case "Editable":

                        bt.IsEnabled = true;
                        bt.IsReadOnly = false;
                        break;

                case "Readonly":
                        bt.IsReadOnly = true;    
                        break;
            }
        }
        private void Change_dir(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton btn)
            switch (btn.Name)
            {
                case "Left":

                    bt.Document.TextAlignment = TextAlignment.Left;

                    break;

                case "Center":

                    bt.Document.TextAlignment = TextAlignment.Center;

                    break;

                case "Right":

                    bt.Document.TextAlignment = TextAlignment.Right;

                    break;
            }
        }
       
    }
}
