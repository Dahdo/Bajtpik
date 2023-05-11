using Project2_Iterators;
using Project3_CollectionWrapper;
using Project3_Visitor;


namespace Project2_Collections {
    public abstract class BajtpikCollection<T> : CollectionWrapper {
        public abstract bool Remove(T item);
        public abstract void Add(T item);
        public abstract int Size();
        public abstract ForwardIterator<T> GetForwardIterator();
        public abstract ReverseIterator<T> GetReverseIterator();

        //for iterators' sake
        internal abstract T? First();
        internal abstract T? Last();
        internal abstract T? Next(T item);
        internal abstract T? Prev(T item);

         //for project3
        public void Accept(Visitor visitor) {
            visitor.Visit(this);
        }
    }
}

namespace Project2_Iterators {
    public abstract class BajtpikIterator<T> {
        public abstract T? Current();
        public abstract bool Move();
        public abstract void Reset();
        public abstract bool IsDone();
    }
}
