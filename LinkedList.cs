/*************************************************************
* Circular Singly Linked List - Version 1.0 Non-Generic Implementation
* November 2024
*************************************************************/

using System;

namespace CircularLinkedList
{
    public class Node
    {
        public Node Next;
        public object Value;
        public Node(object obj)
        {
            Value = obj;
            Next = null;
        }
    }

    public class CircularSinglyLinkedList
    {
        public Node head;
        public Node tail;
        public Node current; // This will have latest node
        public int Count;
        public CircularSinglyLinkedList()
        {
            // Empty list does not have node, all pointers are set to null
            head = tail = current = null;
            Count = 0;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddStart(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode; // Point to itself
            }
            else
            {
                newNode.Next = head;
                head = current = newNode;
                tail.Next = head; // Maintain circular reference
            }
            Count++;
        }

        public void RemoveStart()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head == tail) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                head = current = head.Next;
                tail.Next = head; // Maintain circular reference
            }
            Count--;
        }

        public void AddLast(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode; // Point to itself
            }
            else
            {
                tail.Next = newNode;
                tail = current = newNode;
                tail.Next = head; // Maintain circular reference
            }
            Count++;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't remove a node from an empty list!");
            }
            else if (head == tail) // Only one node in the list
            {
                head = tail = current = null;
            }
            else
            {
                Node temp = head;
                while (temp.Next != tail)
                {
                    temp = temp.Next;
                }
                tail = current = temp;
                tail.Next = head; // Maintain circular reference
            }
            Count--;
        }

        // A new node is inserted after the 'current' node
        public void InsertNode(object data)
        {
            Node newNode = new Node(data);
            if (IsEmpty())
            {
                head = tail = current = newNode;
                newNode.Next = newNode; // Point to itself
                Count++;
            }
            else if (current == tail)
            { // If the 'current' node is the last one
                AddLast(data);
            }
            else
            {
                newNode.Next = current.Next;
                current.Next = newNode;
                current = newNode;
                Count++;
            }
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
                do
                {
                    if (curr == current)
                    { // Mark the 'current' node with <= =>
                        Console.Write(" <=");
                        Console.Write(curr.Value);
                        Console.Write("=> ");
                    }
                    else
                    {
                        Console.Write(" <-");
                        Console.Write(curr.Value);
                        Console.Write("-> ");
                    }
                    curr = curr.Next;
                } while (curr != head);
                Console.WriteLine("Tail ---");
            }
        }
    } // END of class CircularSinglyLinkedList

    public class CircularSinglyLinkedListTest
    {
        static void Main(string[] args)
        {
            CircularSinglyLinkedList testList = new CircularSinglyLinkedList();
            Console.WriteLine("Display the contents of a newly created list: ");
            testList.PrintList();

            Console.WriteLine($"Append {789} to the list");
            testList.AddLast(789);

            Console.WriteLine($"Append 'Bob' to the list");
            testList.AddLast("Bob");

            Console.WriteLine($"Append 'John' to the list");
            testList.AddLast("John");
            Console.WriteLine("Display the whole list:");
            testList.PrintList();

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            testList.PrintList();

            Console.WriteLine($"Remove the first node: {testList.head.Value}");
            testList.RemoveStart();
            testList.PrintList();

            testList.AddStart("Abby");
            Console.WriteLine($"Add {testList.current.Value} to the front of list");
            testList.PrintList();

            Console.WriteLine($"Remove the last node: {testList.tail.Value}");
            testList.RemoveLast();
            testList.PrintList();

            Console.WriteLine("Insert 5, 6, 7 to the list:");
            testList.InsertNode(5);
            testList.InsertNode(6);
            testList.InsertNode(7);
            testList.PrintList();
            Console.WriteLine("head node is " + testList.head.Value);
            Console.WriteLine("tail node is " + testList.tail.Value);
            Console.WriteLine("curr node is " + testList.current.Value);
            Console.WriteLine("Final count of nodes is " + testList.Count);
        }
    } // END of class CircularSinglyLinkedListTest
}