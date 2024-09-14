namespace Sapphire.App.Services;

public class DropoutStack<T>(int capacity) : Stack<T>
{
    private readonly T[] _items = new T[capacity];
    private int _top;

    public new void Push(T item)
    {
        _items[_top] = item;
        _top = (_top + 1) % _items.Length;
    }
    public new T Pop()
    {
        _top = (_items.Length + _top - 1) % _items.Length;
        return _items[_top];
    }
}