using System;

public class Calculator<T>
{
    // Делегати для арифметичних операцій
    public delegate T AddDelegate(T a, T b);
    public delegate T SubtractDelegate(T a, T b);
    public delegate T MultiplyDelegate(T a, T b);
    public delegate T DivideDelegate(T a, T b);

    // Делегати для арифметичних операцій
    public AddDelegate Add { get; set; }
    public SubtractDelegate Subtract { get; set; }
    public MultiplyDelegate Multiply { get; set; }
    public DivideDelegate Divide { get; set; }

    public Calculator()
    {
        // Ініціалізація делегатів за замовчуванням
        Add = (a, b) => Operator<T>.Add(a, b);
        Subtract = (a, b) => Operator<T>.Subtract(a, b);
        Multiply = (a, b) => Operator<T>.Multiply(a, b);
        Divide = (a, b) => Operator<T>.Divide(a, b);
    }

    public T PerformOperation(char operation, T operand1, T operand2)
    {
        switch (operation)
        {
            case '+':
                return Add(operand1, operand2);
            case '-':
                return Subtract(operand1, operand2);
            case '*':
                return Multiply(operand1, operand2);
            case '/':
                return Divide(operand1, operand2);
            default:
                throw new ArgumentException($"Unsupported operation: {operation}");
        }
    }
}