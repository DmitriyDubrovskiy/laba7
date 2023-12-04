using System;
using System.Collections.Generic;

public class FunctionCache<TKey, TResult>
{
    private readonly Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    // Делегат для користувацької функції
    public delegate TResult FuncDelegate(TKey key);

    // Внутрішній клас для зберігання результатів та терміну дії
    private class CacheItem
    {
        public TResult Result { get; set; }
        public DateTime ExpirationTime { get; set; }
    }

    // Метод для виклику функції і кешування результату
    public TResult Execute(FuncDelegate function, TKey key, TimeSpan cacheDuration)
    {
        if (cache.TryGetValue(key, out var cachedItem) && DateTime.Now < cachedItem.ExpirationTime)
        {
            // Повертаємо кешований результат, якщо термін дії не минув
            return cachedItem.Result;
        }

        // Викликаємо користувацьку функцію
        TResult result = function(key);

        // Зберігаємо результат в кеші
        cache[key] = new CacheItem
        {
            Result = result,
            ExpirationTime = DateTime.Now.Add(cacheDuration)
        };

        return result;
    }

    // Метод для очищення кешу
    public void ClearCache()
    {
        cache.Clear();
    }
}