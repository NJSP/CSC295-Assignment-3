/*************************************************************
* Sorted Doubly Linked List - Version 1.0 Non-Generic Implementation
* November 2024
*************************************************************/

using System;

namespace SortedLinkedList
{
    public class Node
    {
        public Node Next;
        public Node Prev;
        public object Value;
        public Node(object obj)
        {
            Value = obj;
            Next = null;
            Prev = null;
        }
    }

    public class SortedDoublyLinkedList
    {
        public Node head;
        public Node tail;
        public Node current; // This will have latest node
        public int Count;
        public SortedDoublyLinkedList()
        {
            // Empty list does not have node, all pointers are set to null
            head = tail = current = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
            }
            else
            {
                Node temp = head;
                while (temp != null && Comparer(data, temp.Value) > 0)
                {
                    temp = temp.Next;
                }

                if (temp == head)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else if (temp == null)
                {
                    tail.Next = newNode;
                    newNode.Prev = tail;
                    tail = newNode;
                }
                else
                {
                    newNode.Next = temp;
                    newNode.Prev = temp.Prev;
                    temp.Prev.Next = newNode;
                    temp.Prev = newNode;
                }
            }
            current = newNode;
            Count++;
        }

        public void Remove(object data)
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }

            Node temp = head;
            while (temp != null && !temp.Value.Equals(data))
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new Exception("Node not found!");
            }

            if (temp == head)
            {
                head = head.Next;
                if (head != null)
                {
                    head.Prev = null;
                }
            }
            else if (temp == tail)
            {
                tail = tail.Prev;
                if (tail != null)
                {
                    tail.Next = null;
                }
            }
            else
            {
                temp.Prev.Next = temp.Next;
                temp.Next.Prev = temp.Prev;
            }

            if (head == null)
            {
                tail = null;
            }

            current = head;
            Count--;
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty list!");
            }
            else
            {
                Console.Write("--- Head");
                Node curr = head;
                while (curr != null) // Advance the pointer
                {
                    if (curr == current)
                    { // Mark the 'current' node with <= =>
                        Console.Write(" <=");
                        Console.Write(curr.Value);
                        Console.Write("=> ");
                        curr = curr.Next;
                    }
                    else
                    {
                        Console.Write(" <-");
                        Console.Write(curr.Value);
                        Console.Write("-> ");
                        curr = curr.Next;
                    }
                }
                Console.WriteLine("Tail ---");
            }
        }

        private int Comparer(object a, object b)
        {
            return ((IComparable)a).CompareTo(b);
        }
    } // END of class SortedDoublyLinkedList

    public class SortedDoublyLinkedListTest
    {
        static void Main(string[] args)
        {
            SortedDoublyLinkedList testList = new SortedDoublyLinkedList();
            Console.WriteLine("Display the contents of a newly created list: ");
            testList.PrintList();

            Console.WriteLine($"Add {789} to the list");
            testList.Add(789);

            Console.WriteLine($"Add 'Bob' to the list");
            testList.Add("Bob");

            Console.WriteLine($"Add 'John' to the list");
            testList.Add("John");
            Console.WriteLine("Display the whole list:");
            testList.PrintList();

            Console.WriteLine($"Remove 'Bob' from the list");
            testList.Remove("Bob");
            testList.PrintList();

            Console.WriteLine($"Remove {789} from the list");
            testList.Remove(789);
            testList.PrintList();

            Console.WriteLine($"Add 'Abby' to the list");
            testList.Add("Abby");
            testList.PrintList();

            Console.WriteLine("Insert 5, 6, 7 to the list:");
            testList.Add(5);
            testList.Add(6);
            testList.Add(7);
            testList.PrintList();
            Console.WriteLine("head node is " + testList.head.Value);
            Console.WriteLine("tail node is " + testList.tail.Value);
            Console.WriteLine("curr node is " + testList.current.Value);
            Console.WriteLine("Final count of nodes is " + testList.Count);
        }
    } // END of class SortedDoublyLinkedListTest
}