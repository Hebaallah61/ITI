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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double firstNumber;
        private double secondNumber;
        private double resultNumber;
        private bool calcDone = false;
        private Operations operation = Operations.None;
        private string separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        private bool IsInputEmpty => result.Equals("0");
        public MainWindow()
        {
            InitializeComponent();         
            dec.Content = separator;
        }

        // operations
        private enum Operations
        {
            None,
            Division,
            Multiplication,
            Subtraction,
            Sum
        }

       
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (calcDone) //calcDone flag=1
            {
                result.Content = button.Content;
                calcDone = false;
            }
            else //calcDone flag=0
            {
                if (!IsInputEmpty)
                {
                    result.Content = button.Content;
                }
                else
                {
                    //related to . dot
                    result.Content = $"{result.Content}{button.Content}";
                }
            }

        }

        //calc
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            
            switch (button.Content.ToString())
            {
               
                case "÷":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Division;
                    result.Content = "0";
                    break;
                case "×":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Multiplication;
                    result.Content = "0";
                    break;
                case "-":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Subtraction;
                    result.Content = "0";
                    break;
                case "+":
                    firstNumber = Convert.ToDouble(result.Content);
                    operation = Operations.Sum;
                    result.Content = "0";
                    break;
                case "=":
                    switch (operation)
                    {
                        case Operations.Division:
                            if (calcDone)
                            {
                                if (!(result.Content.ToString() == "ERROR"))
                                {
                                    result.Content = Convert.ToDouble(result.Content) / secondNumber;
                                }
                            }
                            else
                            {
                                // if division by 0
                                if (result.Content.ToString() == "0")
                                {
                                    result.Content = "ERROR";
                                    calcDone = true;
                                }
                                else
                                {
                                    secondNumber = Convert.ToDouble(result.Content);
                                    resultNumber = firstNumber / secondNumber;
                                    result.Content = resultNumber;
                                    calcDone = true;
                                }
                            }
                            break;
                        case Operations.Multiplication:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) * secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber * secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Subtraction:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) - secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber - secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                        case Operations.Sum:
                            if (calcDone)
                            {
                                result.Content = Convert.ToDouble(result.Content) + secondNumber;
                            }
                            else
                            {
                                secondNumber = Convert.ToDouble(result.Content);
                                resultNumber = firstNumber + secondNumber;
                                result.Content = resultNumber;
                                calcDone = true;
                            }
                            break;
                    }
                    break;

                default:
                    if (!result.Content.ToString().Contains(separator))
                    {
                        result.Content = $"{result.Content}{button.Content}";
                    }
                    break;
            }
        }
    }
}

