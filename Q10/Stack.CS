using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class Stack
{
    private Node top; // top of the stack

    public Stack()
    {
        top = null;
    }

    // Push operation
    public void Push(int data)
    {
        Node newNode = new Node(data);
        newNode.Next = top;
        top = newNode;
        Console.WriteLine($"{data} pushed to stack");
    }

    // Pop operation
    public void Pop()
    {
        if (top == null)
        {
            Console.WriteLine("Stack underflow (no elements to pop)");
            return;
        }

        Console.WriteLine($"{top.Data} popped from stack");
        top = top.Next;
    }

    // Peek / Top element
    public int Peek()
    {
        if (top == null)
        {
            Console.WriteLine("Stack is empty");
            return -1; // or throw exception
        }
        return top.Data;
    }

    // Display stack contents
    public void Display()
    {
        if (top == null)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Node temp = top;
        Console.Write("Stack elements: ");
        while (temp != null)
        {
            Console.Write(temp.Data + " ");
            temp = temp.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Stack stack = new Stack();

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        stack.Display();

        Console.WriteLine("Top element: " + stack.Peek());

        stack.Pop();
        stack.Display();

        stack.Pop();
        stack.Pop();
        stack.Pop(); // extra pop to test underflow
    }
}
