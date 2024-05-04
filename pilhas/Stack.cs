namespace Pilhas
{
    internal class Stack : OperationalDataStructure
    {
        public void Push(int item)
        {
            Node node = new Node(item);

            if (this.Empty())
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
    }
}
