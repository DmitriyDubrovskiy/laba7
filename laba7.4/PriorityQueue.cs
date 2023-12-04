// Допоміжний клас для черги з пріоритетами
public class PriorityQueue<TItem, TPriority> where TPriority : IComparable<TPriority>
{
    private readonly SortedDictionary<TPriority, Queue<TItem>> priorityQueue;

    public int Count
    {
        get
        {
            return priorityQueue.Values.Sum(queue => queue.Count);
        }
    }

    public PriorityQueue()
    {
        priorityQueue = new SortedDictionary<TPriority, Queue<TItem>>();
    }

    public void Enqueue(TItem item, TPriority priority)
    {
        if (!priorityQueue.TryGetValue(priority, out var queue))
        {
            queue = new Queue<TItem>();
            priorityQueue[priority] = queue;
        }

        queue.Enqueue(item);
    }

    public TItem Dequeue()
    {
        if (priorityQueue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var firstPriority = priorityQueue.Keys.First();
        var itemQueue = priorityQueue[firstPriority];

        var item = itemQueue.Dequeue();

        if (itemQueue.Count == 0)
        {
            priorityQueue.Remove(firstPriority);
        }

        return item;
    }
}