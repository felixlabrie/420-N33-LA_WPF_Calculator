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

namespace _420_N33_LA_WPF_Calculator
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber;
        double firstNum;

        enum selOp
        {
            Div,
            Multi,
            Minus,
            Add
        }

        selOp operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void plusOrMinus_Click(object sender, RoutedEventArgs e)
        {
            Double.TryParse(display.Content.ToString(), out firstNum);

            if (firstNum != 0)
            {
                firstNum *= -1;
                display.Content = firstNum.ToString();
            }
            else
            {
                display.Content = firstNum.ToString();
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            display.Content = "0";
            lastNumber = 0;
            firstNum = 0;
        }

        private void handleNum(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (display.Content.ToString().Equals("0"))
            {
                display.Content = button.Content.ToString();
            }
            else if (button.Content.ToString() == ",")
            {
                if (!display.Content.ToString().Contains(","))
                {
                    display.Content += button.Content.ToString();
                }
            }

            else 
            {
                display.Content += button.Content.ToString();
            }
        }

        private void operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Double.TryParse(display.Content.ToString(), out firstNum);

            if (sender == add)
            {
                operation = selOp.Add;
            }
            if (sender == minus)
            {
                operation = selOp.Minus;
            }
            if (sender == multi)
            {
                operation = selOp.Multi;
            }
            if (sender == divise)
            {
                operation = selOp.Div;
            }

            display.Content = "0";

        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            double perc;
            Double.TryParse(display.Content.ToString(), out perc);

            if (perc == 0)
            {
                display.Content = perc.ToString();
            }
            else
            {
                if (firstNum != 0)
                {
                    display.Content = (firstNum * (perc / 100)).ToString();
                }
                else
                {
                    display.Content = (perc / 100).ToString();
                }
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            Double.TryParse(display.Content.ToString(), out lastNumber);

            switch (operation)
            {
                case selOp.Add:
                    display.Content = (firstNum + lastNumber).ToString();
                    break;

                case selOp.Minus:
                    display.Content = (firstNum - lastNumber).ToString();
                    break;

                case selOp.Multi:
                    display.Content = (firstNum * lastNumber).ToString();
                    break;

                case selOp.Div:
                    if (lastNumber == 0)
                    {
                        MessageBox.Show("ERROR : DIVIDE BY 0");
                        
                    }
                    else
                    {
                        display.Content = (firstNum / lastNumber).ToString();
                    }
                    break;
            }
        }

    }
}
