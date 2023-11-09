using System.Collections;
using _253505_Forinov_Lab2.Exception;
using _253505_Forinov_Lab2.Interfaces;

namespace _253505_Forinov_Lab2.Collections;

internal class Node<T>
{
    public Node(T data) => Data = data;
    public T Data { get; set; }
    public Node<T>? Next { get; set; }
}

public class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable<T>, IEnumerator<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private Node<T>? _current;

    public T this[int index]
    {
        get
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();
            var currentNode = _head;
            while (index != 0)
            {
                currentNode = currentNode?.Next;
                index--;
            }

            if (currentNode == null || currentNode.Data == null)
                throw new NullReferenceException("Value is null");
            return currentNode.Data;
        }
        set
        {
            if (index >= Count || index < 0)
                throw new IndexOutOfRangeException();
            var currentNode = _head;
            while (index != 0)
            {
                currentNode = currentNode?.Next;
                index--;
            }
            
            if (currentNode != null)
                currentNode.Data = value;
        }
    }

    public void Reset() => _current = _head;

    T IEnumerator<T>.Current => _current.Data;

    object IEnumerator.Current => _current.Data;

    public bool MoveNext()
    {
        if (_current?.Next != null)
        {
            _current = _current.Next;
            return true;
        }

        return false;
    }

    public int Count { get; private set; }

    public void Add(T item)
    {
        Node<T> newNode = new(item);
        if (_head is null)
        {
            _head = newNode;
            _current = _head;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }

        _tail = newNode;
        Count++;
    }

    public void Remove(T item)
    {
        if (_head is null)
            return;
        
        if (_head.Data != null && _head.Data.Equals(item))
        {
            _head = _head.Next;
            Count--;
            if (_head == _tail)
            {
                _head = _tail = null;
                return;
            }
        }

        var count = Count - 2;
        if (_tail != null && _tail.Data != null && _tail.Data.Equals(item))
        {
            var newTail = _head;
            for (var i = 0; i < count; i++)
                newTail = newTail!.Next;
            _tail = newTail;
            Count--;
            return;
        }


        var currentNode = _head!.Next;
        count = Count;
        while (count >= 0)
        {
            var prevNode = currentNode;
            currentNode = currentNode?.Next;
            if (currentNode != null && currentNode.Data != null && currentNode.Data.Equals(item))
            {
                if (prevNode != null)
                    prevNode.Next = currentNode.Next;
                Count--;
                return;
            }
            count--;
        }

        throw new MyException("No such item in collection");
    }

    public T RemoveCurrent()
    {
        if (_current == null || _current.Data == null)
            throw new NullReferenceException("Current value is null");
        var value = _current.Data;
        Remove(value);
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Dispose()
    {
        _head = null;
        _tail = null;
        _current = null;
    }
}