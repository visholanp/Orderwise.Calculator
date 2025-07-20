using System;

namespace Orderwise.Calculator.Models
{
    /// <summary>
    /// Represents the division operation.
    /// </summary>
    public class Division : Operation
    {
        /// <summary>
        /// Divides the first number by the second number and returns the result.
        /// Throws exception if division by zero is attempted.
        /// </summary>
        public override double Calculate(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return a / b;
        }
    }
}
