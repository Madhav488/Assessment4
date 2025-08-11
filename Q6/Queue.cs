namespace assignment14queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Assignment14
    {
        public class Node
        {
            public int Data;
            public Node Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public class Queue
        {
            private Node front;
            private Node rear;

            public Queue()
            {
                front = rear = null;
            }

           
            public void Insert(int data)
            {
                Node newNode = new Node(data);

                if (rear == null)
                {
                    front = rear = newNode;
                }
                else
                {
                    rear.Next = newNode;
                    rear = newNode;
                }

                Console.WriteLine($"{data} inserted into queue.");
            }

            
            public void Delete()
            {
                if (front == null)
                {
                    Console.WriteLine("Queue Underflow! Nothing to delete.");
                    return;
                }

                Console.WriteLine($"{front.Data} deleted from queue.");

                front = front.Next;

                if (front == null)
                {
                    
                    rear = null;
                }
            }

           
            public void Display()
            {
                if (front == null)
                {
                    Console.WriteLine("Queue is empty.");
                    return;
                }

                Console.WriteLine("Queue elements:");
                Node temp = front;
                while (temp != null)
                {
                    Console.Write(temp.Data + " ");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }

            
            public void ShowFront()
            {
                if (front == null)
                    Console.WriteLine("Queue is empty. No front element.");
                else
                    Console.WriteLine("Front element: " + front.Data);
            }

            public void ShowRear()
            {
                if (rear == null)
                    Console.WriteLine("Queue is empty. No rear element.");
                else
                    Console.WriteLine("Rear element: " + rear.Data);
            }
        }


        internal class queue
        {
            static void Main(string[] args)
            {
                Queue q = new Queue();
                string choice = "y";

                while (choice.ToLower() == "y")
                {
                    Console.WriteLine("\nChoose Operation:");
                    Console.WriteLine("1. Insert (Enqueue)");
                    Console.WriteLine("2. Delete (Dequeue)");
                    Console.WriteLine("3. Display Queue");
                    Console.WriteLine("4. Show Front");
                    Console.WriteLine("5. Show Rear");
                    Console.Write("Enter your choice: ");

                    int ch = int.Parse(Console.ReadLine());

                    switch (ch)
                    {
                        case 1:
                            Console.Write("Enter value to insert: ");
                            int val = int.Parse(Console.ReadLine());
                            q.Insert(val);
                            break;
                        case 2:
                            q.Delete();
                            break;
                        case 3:
                            q.Display();
                            break;
                        case 4:
                            q.ShowFront();
                            break;
                        case 5:
                            q.ShowRear();
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    Console.Write("\nDo you want to continue? (y/n): ");
                    choice = Console.ReadLine();
                }
            }
        }
    }

}
