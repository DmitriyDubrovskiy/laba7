class Program
{
    static void Main()
    {
        // Приклад використання для цілих чисел
        Calculator<int> intCalculator = new Calculator<int>();
        Console.WriteLine($"Result: {intCalculator.PerformOperation('+', 5, 3)}");

        // Приклад використання для чисел з плаваючою точкою
        Calculator<double> doubleCalculator = new Calculator<double>();
        Console.WriteLine($"Result: {doubleCalculator.PerformOperation('-', 8.7, 3.2)}");

        // Приклад використання для чисел типу decimal
        Calculator<decimal> decimalCalculator = new Calculator<decimal>();
        Console.WriteLine($"Result: {decimalCalculator.PerformOperation('*', 2.5m, 4.0m)}");
    }
}
