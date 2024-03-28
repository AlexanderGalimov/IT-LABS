namespace Task1.models
{
    public class ListNode
    {
        public string Data { get; set; }
        public ListNode Next { get; set; }

        public ListNode(string data = "", ListNode next = null)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
