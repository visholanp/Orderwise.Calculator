namespace Orderwise.Calculator.Models
{
    /// <summary>
    /// Defines a contract for the Calculate method.
    /// </summary>
    public abstract class Operation
    {
        /// <summary>
        /// Executes the mathematical operation on two operands.
        /// </summary>
        public abstract double Calculate(double a, double b);
    }
}
