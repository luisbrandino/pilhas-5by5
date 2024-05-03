namespace Pilhas
{
    internal class Stack
    {
        Node? top = null;

        public void Push(int item)
        {
            Node node = new Node(item);

            if (Empty())
            {
                this.top = node;
                return;
            }

            node.SetNext(this.top);
            this.top = node;
        }

        public int? Pop()
        {
            if (this.top == null)
                return null;

            Node node = this.top;
            this.top = this.top.Next();

            return node.GetData();
        }

        public bool Empty()
        {
            return this.top == null;
        }

        public double Sum()
        {
            if (this.Empty())
                return double.NaN;

            Node? current = this.top;

            int sum = 0;

            while (current != null)
            {
                sum += current.GetData();

                current = current.Next();
            }

            return sum;
        }

        public double Average()
        {
            if (this.Empty())
                return double.NaN;

            return this.Sum() / (double) this.Count();
        }

        public int Count()
        {
            int count = 0;

            Node? current = this.top;

            while (current != null)
            {
                count++;
                current = current.Next();
            }

            return count;
        }

        public int EvenCount()
        {
            int count = 0;

            Node? current = this.top;

            while (current != null)
            {
                if (current.GetData() != 0 && current.GetData() % 2 == 0)
                    count++;

                current = current.Next();
            }

            return count;
        }

        public int OddCount()
        {
            int count = 0;

            Node? current = this.top;

            while (current != null)
            {
                if (current.GetData() != 0 && current.GetData() % 2 != 0)
                    count++;

                current = current.Next();
            }

            return count;
        }

        public int? Max()
        {
            if (this.Empty())
                return null;

            Node? current = this.top?.Next();
            int? max = this.top?.GetData();

            while (current != null)
            {
                if (current?.GetData() > max)
                    max = current?.GetData();

                current = current?.Next();
            }

            return max;
        }

        public int? Min()
        {
            if (this.Empty())
                return null;

            Node? current = this.top?.Next();
            int? min = this.top?.GetData();

            while (current != null)
            {
                if (current?.GetData() < min)
                    min = current?.GetData();

                current = current?.Next();
            }

            return min;
        }

        public Stack Reverse()
        {
            Stack stack = new Stack();

            Node? current = this.top;

            while (current != null)
            {
                stack.Push(current.GetData());
                current = current.Next();
            }

            return stack;
        }

        public Stack Clone()
        {
            Stack reversed = this.Reverse();
            Stack stack = new Stack();

            Node? current = reversed.top;

            while (current != null)
            {
                stack.Push(current.GetData());
                current = current.Next();
            }

            return stack;
        }

        public void Display()
        {
            Node? current = this.top;

            while (current != null)
            {
                Console.Write($"{current.GetData()} ");
                current = current.Next();
            }
        }

        public override bool Equals(object? obj)
        {
            Stack? stack = obj as Stack;

            if (stack == null)
                return false;

            return this.Count() == stack.Count();
        }
    }
}
