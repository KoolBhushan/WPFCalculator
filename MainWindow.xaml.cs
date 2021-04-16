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

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double result, lastNumber;
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {            
            int selectedValue = int.Parse(((Button)sender).Content.ToString());

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedValue}";
                
            }
            else
            {
                ResultLabel.Content += $"{selectedValue}";
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {                
                ResultLabel.Content = "0";
            }

            if (sender.Equals(PlusButton))
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender.Equals(MinusButton))
            {
                selectedOperator = SelectedOperator.Substraction;
            }
            if (sender.Equals(DivideButton))
            {
                selectedOperator = SelectedOperator.Division;
            }
            if (sender.Equals(MultiplyButton))
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                    ResultLabel.Content = tempNumber;
                }                
            }
        }

        private void PointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains("."))
            {
                ResultLabel.Content += ".";
            } 

        }
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = lastNumber + newNumber;
                        ResultLabel.Content = result;
                        break;
                    case SelectedOperator.Substraction:
                        result = lastNumber - newNumber;
                        ResultLabel.Content = result;
                        break;
                    case SelectedOperator.Multiplication:
                        result = lastNumber * newNumber;
                        ResultLabel.Content = result;
                        break;
                    case SelectedOperator.Division:
                        if (newNumber == 0)
                        {
                            ResultLabel.Content = "Cannot divide by zero";
                        }
                        else
                        {
                            result = lastNumber / newNumber;
                            ResultLabel.Content = result;
                        }                        
                        break;
                    default:
                        break;
                }
               
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber *= -1;
                ResultLabel.Content = lastNumber;
            }
        }        
    }

    public enum SelectedOperator
    {
        Addition,
        Substraction,
        Multiplication,
        Division
    }
}
