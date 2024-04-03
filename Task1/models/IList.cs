namespace Task1.models
{
    public interface IList<T>
    {
        T get(int index);

        void append(T value);
        void prepend(T value);

        void insert(T value, int index);

        void remove(int index);

        void clear();
    }
}
