using System;

namespace Task1.models
{
    public class LinkedList : IList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        public string First => IsEmpty ? "" : Head.Data;

        public string Last => IsEmpty ? "" : Tail.Data;

        public bool IsEmpty => Head == null;

        private int length = 0;
        public int Length => length;

        public void Append(string value)
        {

            var newNode = new ListNode(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            length++;

        }

        public void Clear()
        {
            Head = null;
            Tail = null;

            length = 0;
        }

        public string Get(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = Head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    return currentNode.Data;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }

            return "";
        }

        public void Insert(string value, int index)
        {

            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Prepend(value);
            }

            var currentNode = Head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    var newNode = new ListNode(value);
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;

                    if (currentNode == Tail)
                    {
                        Tail = newNode;
                    }

                    length++;
                }

                currentNode = currentNode.Next;
                currentIndex++;
            }


        }

        public void Prepend(string value)
        {
            var newNode = new ListNode(value);

            if (IsEmpty)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }

            length++;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
            }
            else
            {
                var currentNode = Head;
                int currentIndex = 0;

                while (currentNode != null && currentIndex < index - 1)
                {
                    currentNode = currentNode.Next;
                    currentIndex++;
                }

                var nodeToRemove = currentNode.Next;

                currentNode.Next = nodeToRemove.Next;

                if (nodeToRemove == Tail)
                {
                    Tail = currentNode;
                }
            }

            length--;
        }

        public override string ToString()
        {
            string result = "[";

            for (var currentNode = Head; currentNode != null; currentNode = currentNode.Next)
            {
                result += currentNode.ToString();
                if (currentNode != Tail)
                {
                    result += ", ";
                }

            }
            result += "]";

            return result;

        }

    }
}
