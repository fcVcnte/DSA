namespace DataStructures.Stack;

public class ArrayStack<T> {
    private const int DefaultCapacity = 10;
    private const string StackEmptyErrorMessage = "The Stack is empty";

    private T[] stack;

    private int top;

    public ArrayStack()
    {
        stack = new T[DefaultCapacity];
        top = -1;
    }
    
    public ArrayStack(T item) : this() => Push(item);

    public ArrayStack(T[] items)
    {
        stack = items;
        top = items.Length - 1;
    }

    public int Top => top;

    public int Capacity
    {
        get => stack.Length;
        set => Array.Resize(ref stack, value);
    }

    public void Clear() {
        top = -1;
        Capacity = DefaultCapacity;
    }

    public bool Contains(T item) => Array.IndexOf(stack, item, 0, top + 1) > -1;
    
    public T Peek()
    {
        if (top == -1)
            throw new InvalidOperationException(StackEmptyErrorMessage);
        return stack[top];
    }

    public T Pop()
    {
        if (top == -1)
            throw new InvalidOperationException(StackEmptyErrorMessage);
        return stack[top--];
    }

    public void Push(T item)
    {
        if (top == Capacity - 1)
            Capacity *= 2;
        stack[++top] = item;
    }
}