class Program
{
    static void Main()
    {
        // Приклад використання
        FunctionCache<string, int> cache = new FunctionCache<string, int>();

        // Визначення користувацької функції
        FunctionCache<string, int>.FuncDelegate customFunction = key =>
        {
            Console.WriteLine($"Executing function for key: {key}");
            return key.Length;
        };

        // Виклик функції та кешування результату
        int result1 = cache.Execute(customFunction, "apple", TimeSpan.FromSeconds(5));
        Console.WriteLine($"Result 1: {result1}");

        // Виклик тієї ж самої функції з тим же ключем
        int result2 = cache.Execute(customFunction, "apple", TimeSpan.FromSeconds(5));
        Console.WriteLine($"Result 2: {result2}");

        // Очищення кешу
        cache.ClearCache();

        // Виклик функції після очищення кешу
        int result3 = cache.Execute(customFunction, "apple", TimeSpan.FromSeconds(5));
        Console.WriteLine($"Result 3: {result3}");
    }
}
