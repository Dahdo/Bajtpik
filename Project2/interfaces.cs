using Project2_Iterators;
using Project3_CollectionWrapper;

namespace Project2_Collections {
    public interface BajtpikCollection<T> {
        public bool Remove(T item);
        public void Add(T item);
        public int Size();
        public ForwardIterator<T> GetForwardIterator();
        public ReverseIterator<T> GetReverseIterator();

        //for iterators
        public T? First();
        public T? Last();
        public T? Next(T item);
        public T? Prev(T item);
    }
}

namespace Project2_Iterators {
    public interface BajtpikIterator<T> {
        public T? Current();
        public bool Move();
        public void Reset();
        public bool IsDone();
    }
}
