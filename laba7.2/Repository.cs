using System;
using System.Collections.Generic;

public class Repository<T>
{
    private List<T> items = new List<T>();

    // Делегат Criteria<T>
    public delegate bool Criteria<T>(T item);

    // Метод для додавання елементів в репозиторій
    public void Add(T item)
    {
        items.Add(item);
    }

    // Метод для пошуку елементів за заданим критерієм
    public List<T> Find(Criteria<T> criteria)
    {
        List<T> result = new List<T>();
        foreach (var item in items)
        {
            if (criteria(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}
