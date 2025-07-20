using Orderwise.Calculator.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Orderwise.Calculator
{
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
        /// Handles number and decimal point button clicks.
        /// Builds the number input as a string.
        /// </summary>
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var value = (string)((Button)sender).Content;

                // Start new input after an operator was pressed
                if (_newInput)
                {
                    _input = "";
                    _newInput = false;
                }

                _input += value;
                ResultTextBox.Text = _input;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Error";
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles operator button clicks.
        /// </summary>
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double currentInput = double.Parse(_input);

                if (!string.IsNullOrEmpty(_operator))
                {
                    // Perform previous operation with the current input
                    var operation = OperationFactory.GetOperation(_operator);
                    _firstOperand = operation.Calculate(_firstOperand, currentInput);
                }
                else
                {
                    // First time a number is entered
                    _firstOperand = currentInput;
                }

                // Display intermediate result
                ResultTextBox.Text = _firstOperand.ToString();

                // Store the new operator and prepare for next number input
                _operator = (string)((Button)sender).Content;
                _newInput = true;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Error";
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Executes the last pending operation and shows the final result.
        /// </summary>
        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double secondOperand = double.Parse(_input);

                // Perform final calculation
                var operation = OperationFactory.GetOperation(_operator);
                var result = operation.Calculate(_firstOperand, secondOperand);

                // Show result and prepare for next input
                ResultTextBox.Text = result.ToString();
                _input = result.ToString(); 
                
                // Keep result for further operations
                _firstOperand = result;
                _operator = "";                   

                // Reset operator flag
                _newInput = true;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Error";
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles clear button click.
        /// Resets the calculator state completely.
        /// </summary>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _input = "";
            _firstOperand = 0;
            _operator = "";
            ResultTextBox.Text = "";
            _newInput = false;
        }
    }
}
