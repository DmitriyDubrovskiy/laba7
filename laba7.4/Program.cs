class Program
{
    static void Main()
    {
        // Приклад використання
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(ExecuteTask);
        scheduler.InputTasksFromConsole();
        scheduler.ExecuteNext();
        scheduler.ExecuteNext();
    }

    static void ExecuteTask(string task)
    {
        Console.WriteLine($"Executing task: {task}");
    }
}
