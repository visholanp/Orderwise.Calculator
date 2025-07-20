using Orderwise.Calculator.Models;
using System;

namespace Orderwise.Calculator.Services
{
    /// <summary>
    /// Factory class responsible for creating Operation instances
    /// based on the operator symbol.
    /// </summary>
    public static class OperationFactory
    {
        /// <summary>
        /// Returns the corresponding Operation object based on the operator symbol.
        /// </summary>
        /// <param name="symbol">Operator symbol like +, -, *, /</param>
        /// <returns>Instance of Operation subclass</returns>
        public static Operation GetOperation(string symbol)
        {
            switch (symbol)
            {
                case "+": return new Addition();
                case "-": return new Subtraction();
                case "*": return new Multiplication();
                case "/": return new Division();
                default: throw new InvalidOperationException("Unknown operation");
            }
        }
    }
}
