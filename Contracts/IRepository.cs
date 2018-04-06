using System.Collections.Generic;

public interface IRepository<T>
{
    IReadOnlyDictionary<string, T> Elements { get; }

    void Add(T element);
    T GetByName(string name);
}

