class Program
{
    static void Main()
    {
        // Приклад використання
        Repository<int> intRepository = new Repository<int>();
        for (int i = 1; i <= 10; i++)
        {
            intRepository.Add(i);
        }

        // Знаходимо парні числа
        List<int> evenNumbers = intRepository.Find(x => x % 2 == 0);

        Console.WriteLine("Even numbers:");
        foreach (var number in evenNumbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();

        Repository<string> stringRepository = new Repository<string>();
        stringRepository.Add("apple");
        stringRepository.Add("banana");
        stringRepository.Add("orange");
        stringRepository.Add("grape");

        // Знаходимо слова, які починаються з 'a'
        List<string> aWords = stringRepository.Find(word => word.StartsWith("a", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Words starting with 'a':");
        foreach (var word in aWords)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}
