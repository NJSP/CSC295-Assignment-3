namespace MyStack
{
    internal class MyStackTest
    {
        static void Main(string[] args)
        {
            // create an instance
            MyStack stack = new MyStack();
            // check if stack is empty
            Console.WriteLine("Is stack empty? " + stack.IsEmpty());
            // push elements onto the stack
            stack.Push(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(5);
            stack.Push(0);
            Console.WriteLine("Stack after pushing elements: " + stack);
            // peek at the top element
            Console.WriteLine("Peek at top element: " + stack.Peek());
            // pop elements from the stack
            Console.WriteLine("Pop element: " + stack.Pop());
            Console.WriteLine("Stack after popping an element: " + stack);
            // check if stack contains an element
            Console.WriteLine("Does stack contain 3? " + stack.Contains(3));
            // clear the stack
            stack.Clear();
            Console.WriteLine("Stack after clearing: " + stack);
        }
    }

    internal class MyStack
    {
        private int[] values; // Stack data are stored in an array called values
        private int count; // Number of elements in the stack

        public MyStack(int capacity = 4) // constructor with default capacity of 4
        {
            values = new int[capacity]; // allocate the array
            count = 0; // initially, count is set to 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return values.Length; }
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < count; i++)
            {
                if (values[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int Peek()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");
            return values[count - 1];
        }

        public int Pop()
        {
            if (count == 0)
                throw new InvalidOperationException("Stack is empty.");
            int top = values[count - 1];
            count--;
            return top;
        }

        public void Push(int item)
        {
            if (count == Capacity)
            {
                Resize();
            }
            values[count] = item;
            count++;
        }

        private void Resize()
        {
            // create a new array of double capacity
            int[] tmp = new int[2 * Capacity];
            // copy over the old values
            for (int pos = 0; pos < Capacity; pos++)
            {
                tmp[pos] = values[pos];
            }
            // reference values array to the new tmp array
            values = tmp;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
                return "Empty stack!";
            else
            {
                string result = "";
                for (int i = 0; i < count; i++)
                {
                    result += values[i] + " ";
                }
                return result.Trim();
            }
        }
    }
}