namespace Orderwise.Calculator.Models
{
    /// <summary>
    /// Represents the addition operation.
    /// </summary>
    public class Addition : Operation
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        public override double Calculate(double a, double b) 
        { 
            return a + b;
        }
    }
}
