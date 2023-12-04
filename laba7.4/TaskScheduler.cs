using System;
using System.Collections.Generic;

public class TaskScheduler<TTask, TPriority>
{
    private PriorityQueue<TTask, TPriority> taskQueue = new PriorityQueue<TTask, TPriority>();
    private TaskExecution<TTask> taskExecutionDelegate;

    // Делегат TaskExecution<TTask>
    public delegate void TaskExecution<TTask>(TTask task);

    public TaskScheduler(TaskExecution<TTask> executionDelegate)
    {
        taskExecutionDelegate = executionDelegate;
    }

    // Додавання завдання до черги з пріоритетами
    public void AddTask(TTask task, TPriority priority)
    {
        taskQueue.Enqueue(task, priority);
    }

    // Виконання завдання з найвищим пріоритетом
    public void ExecuteNext()
    {
        if (taskQueue.Count > 0)
        {
            var nextTask = taskQueue.Dequeue();
            taskExecutionDelegate(nextTask);
        }
        else
        {
            Console.WriteLine("No tasks to execute.");
        }
    }

    // Метод для отримання об'єкта з пулу
    public TTask GetFromPool(Func<TTask> initializationDelegate)
    {
        return initializationDelegate();
    }

    // Метод для повернення об'єкта в пул
    public void ReturnToPool(TTask task, Action<TTask> resetDelegate)
    {
        resetDelegate(task);
    }

    // Метод для введення завдань з консолі
    public void InputTasksFromConsole()
    {
        Console.WriteLine("Enter tasks with priorities. To finish, enter an empty line.");

        while (true)
        {
            Console.Write("Enter task: ");
            string inputTask = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputTask))
            {
                break;
            }

            Console.Write("Enter priority: ");
            string inputPriority = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputPriority))
            {
                break;
            }

            if (TryParsePriority(inputPriority, out TPriority priority))
            {
                AddTask((TTask)Convert.ChangeType(inputTask, typeof(TTask)), priority);
            }
            else
            {
                Console.WriteLine("Invalid priority format. Please enter a valid priority.");
            }
        }
    }

    // Допоміжний метод для перевірки правильності введення пріоритету
    private bool TryParsePriority(string input, out TPriority priority)
    {
        try
        {
            priority = (TPriority)Convert.ChangeType(input, typeof(TPriority));
            return true;
        }
        catch (Exception)
        {
            priority = default(TPriority);
            return false;
        }
    }
}