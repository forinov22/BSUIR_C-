namespace _253505_Forinov_Lab2.Interfaces;

public interface ICustomCollection<T>
{
    T this[int index]{get;set;}
    void Reset();
    bool MoveNext();
    int Count { get;}
    void Add(T item);
    void Remove(T item);
    T RemoveCurrent();
}