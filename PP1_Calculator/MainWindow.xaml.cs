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

namespace PP1_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // stores the first value to be calculated
        private int val1 = 0;
        // stores the second value to be calculated
        private int val2 = 0;
        // optional. This dictates the limit of the number
        private int lenLim = 10;
        // dictates the mathematical operation to be performed
        private char operation = ' ';

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redirects the function of the button depending on the switch case
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenericClick(object sender, RoutedEventArgs e)
        {
            // sender the control that activates the event.
            // in this case the sender is a button.
            // sender is an object which is why we cast it into a button
            // then we can access the Content property
            switch(((Button)sender).Content)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    // this is the optional task of checking how many numbers
                    // are already on the screen
                    if (txtbOutputBox.Text.Length < lenLim)
                        txtbOutputBox.Text += ((Button)sender).Content;
                    break;
                case "+":
                    storeValue('+');
                    break;
                case "-":
                    storeValue('-');
                    break;
                case "/":
                    storeValue('/');
                    break;
                case "*":
                    storeValue('*');
                    break;
                case "=":
                    // this is the only way to store a second value
                    val2 = int.Parse(txtbOutputBox.Text);
                    switch (operation)
                    {
                        case '+':
                            txtbOutputBox.Text = (val1 + val2) + "";
                            break;
                        case '-':
                            txtbOutputBox.Text = (val1 - val2) + "";
                            break;
                        case '/':
                            // this is double so that the answer has decimal places
                            txtbOutputBox.Text = ((double)val1 / (double)val2) + "";
                            break;
                        case '*':
                            txtbOutputBox.Text = (val1 * val2) + "";
                            break;
                    }
                    break;
            }
        }

        // optional method that removes the possiblity of a leading 0
        private void txtbOutputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtbOutputBox.Text.Length > 1)
            {
                if (txtbOutputBox.Text[0] == '0')
                {
                    txtbOutputBox.Text = txtbOutputBox.Text[1] + "";
                }
            }
        }

        /// <summary>
        /// This is the method that stores the first value and resets the content 
        /// of the textbox. Also stores the operation to be used.
        /// </summary>
        /// <param name="ope"></param>
        private void storeValue(char ope)
        {
            val1 = int.Parse(txtbOutputBox.Text);
            txtbOutputBox.Text = "0";
            operation = ope;
            //MessageBox.Show("Value 1 is " + val1);
        }
    }
}
