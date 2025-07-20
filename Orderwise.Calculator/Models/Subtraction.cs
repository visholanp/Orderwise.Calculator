namespace Orderwise.Calculator.Models
{
    /// <summary>
    /// Represents the subtraction operation.
    /// </summary>
    public class Subtraction : Operation
    {
        /// <summary>
        /// Subtracts the second number from the first and returns the result.
        /// </summary>
        public override double Calculate(double a, double b)
        {
            return a - b;
        }
    }
}
