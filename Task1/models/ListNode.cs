namespace Task1.models
{
    public class ListNode<T>
    {
        public ListNode(T data = default(T), ListNode<T> next = null)
        {
            this.data = data;
            this.next = next;
        }

        public T data
        {
            get; set;
        }

        public ListNode<T> next
        {
            get; set;
        }

        public override string ToString()
        {
            return data.ToString();
        }

    }
}
