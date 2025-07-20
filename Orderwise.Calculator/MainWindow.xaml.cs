using Orderwise.Calculator.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Orderwise.Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _input = "";         // Stores current numeric input
        private double _firstOperand = 0;   // Stores the first operand
        private string _operator = "";      // Stores selected operator
        private bool _newInput = false;     // Flag to indicate if new input should start

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Appends the number or decimal to the input string.
        /// </summary>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            var value = (string)((Button)sender).Content;

            if (_newInput)
            {
                _input = "";
                _newInput = false;
            }

            _input += value;
            ResultTextBox.Text = _input;
        }

        /// <summary>
        /// Stores the first operand and selected operator.
        /// Prepares for the next number input.
        /// </summary>
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            _firstOperand = double.Parse(_input);
            _operator = (string)((Button)sender).Content;
            _newInput = true;
        }

        /// <summary>
        /// Evaluates the expression and shows the result.
        /// Handles exceptions like divide by zero.
        /// </summary>
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double secondOperand = double.Parse(_input);
                var operation = OperationFactory.GetOperation(_operator);
                var result = operation.Calculate(_firstOperand, secondOperand);
                ResultTextBox.Text = result.ToString();
                _input = result.ToString();
                _newInput = true;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Error";
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Resets the calculator to its initial state.
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _input = "";
            _firstOperand = 0;
            _operator = "";
            ResultTextBox.Text = "";
        }
    }
}
