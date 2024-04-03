using System;

namespace Task1.models
{
    public class LinkedList<T> : IList<T>
    {
        private ListNode<T> head { get; set; }
        private ListNode<T> tail { get; set; }

        private int length = 0;

        public LinkedList()
        {
            head = null;
            tail = null;
        }

        public ListNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public ListNode<T> Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void append(T value)
        {

            var newNode = new ListNode<T>(value);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            length++;

        }

        public void clear()
        {
            head = null;
            tail = null;

            length = 0;
        }

        public T get(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            var currentNode = head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index)
                {
                    return currentNode.data;
                }

                currentNode = currentNode.next;
                currentIndex++;
            }

            return default(T);
        }

        public void insert(T value, int index)
        {

            if (index < 0 || index > length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                prepend(value);
            }

            var currentNode = head;
            int currentIndex = 0;

            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    var newNode = new ListNode<T>(value);
                    newNode.next = currentNode.next;
                    currentNode.next = newNode;

                    if (currentNode == tail)
                    {
                        tail = newNode;
                    }

                    length++;
                }

                currentNode = currentNode.next;
                currentIndex++;
            }


        }

        public void prepend(T value)
        {
            var newNode = new ListNode<T>(value);

            if (isEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }

            length++;
        }

        public void remove(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
            }
            else
            {
                var currentNode = head;
                int currentIndex = 0;

                while (currentNode != null && currentIndex < index - 1)
                {
                    currentNode = currentNode.next;
                    currentIndex++;
                }

                var nodeToRemove = currentNode.next;

                currentNode.next = nodeToRemove.next;

                if (nodeToRemove == tail)
                {
                    tail = currentNode;
                }
            }

            length--;
        }
    }
}
