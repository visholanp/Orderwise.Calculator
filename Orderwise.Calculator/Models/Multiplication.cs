namespace Orderwise.Calculator.Models
{
    /// <summary>
    /// Represents the multiplication operation.
    /// </summary>
    public class Multiplication : Operation
    {
        /// <summary>
        /// Multiplies two numbers and returns the result.
        /// </summary>
        public override double Calculate(double a, double b)
        {
            return a * b;
        }
    }
}
