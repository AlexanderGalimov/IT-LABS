namespace Task1.models
{
    public interface IList
    {
        string Get(int index);

        void Append(string value);
        void Prepend(string value);

        void Insert(string value, int index);

        void Remove(int index);

        void Clear();
    }
}
