using Project2_Iterators;
namespace Project2_Collections {
    public class Vector<T> : BajtpikCollection<T> {
        private T[] Items;
        private int Count;

        public Vector() {
            Items = new T[0];
            Count = 0;
        }

        public override void Add(T item) {
            Array.Resize(ref Items, ++Count);
            Items[Count - 1] = item;
        }

        public bool RemoveAt(int index) {
            if (index >= Count)
                return false;
            T[] tmpItems = new T[Count];
            Items.CopyTo(tmpItems, 0);
            Array.Resize(ref Items, --Count);

            int j = -1;
            for(int i = 0; i < Count + 1; i++) {
                j++;
                if (i == index) {
                    j--;
                    continue;
                }
                else
                    Items[j] = tmpItems[i];
            }
            return true;
        }

        private int IndexOf(T item) {
            for (int i = 0; i < Count; i++) {
                if (EqualityComparer<T>.Default.Equals(Items[i], item))
                    return i;
            }
            return -1;
        }

        public override bool Remove(T item) {
            int index = IndexOf(item);

            if (index > -1)
                return RemoveAt(index);
            else
                return false;
        }

        public override int Size() {
            return Count;
        }

        //for iterators' sake

        internal override T? First() {
            return Items[0];
        }
        internal override T? Last() {
            return Items[Count - 1];
        }
        internal override T? Prev(T item) {
            int index = IndexOf(item);
            if (index > 0)
                return Items[index - 1];
            else
                return default;
        }

        internal override T? Next(T item) {
            int index = IndexOf(item);
            if (index < Count - 1)
                return Items[index + 1];
            else
                return default;
        }

        public override ForwardIterator<T> GetForwardIterator() {
            return new ForwardIterator<T>(this);
        }

        public override ReverseIterator<T> GetReverseIterator() {
            return new ReverseIterator<T>(this);
        }
    }

    //DoublyLinkedList
    public class DoublelyLinkedList<T> : BajtpikCollection<T> {

        private class Node {
            public T Data { get; set; }
            public Node Prev { get; set; }
            public Node Next { get; set; }

            public Node (T item) {
                Data = item;
            }
        }

        private Node? Head;
        private Node? Tail;
        private int Count;

        public DoublelyLinkedList() {
            Head = Tail = null;
        }
        public override void Add(T item) {
            Node tmpNode = new Node(item);

            if(Head == null)
                Head = Tail = tmpNode;

            else {
                Tail.Next = tmpNode;
                tmpNode.Prev = Tail;
                Tail = tmpNode;
            }
            Count++;
        }

        public override bool Remove(T item) {
            Node currentNode = Head;
            while(currentNode != null) {
                if (EqualityComparer<T>.Default.Equals(currentNode.Data, item)) {
                    if (currentNode.Prev != null) {
                        currentNode.Prev.Next = currentNode.Next;
                    }
                    else {
                        Head = currentNode.Next;
                    }
                    if (currentNode.Next != null) {
                        currentNode.Next.Prev = currentNode.Prev;
                    }
                    else {
                        Tail = currentNode.Prev;
                    }
                    Count--;
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }
        public override int Size() {
            return Count;
        }

        //for iterators's sake

        private Node GetNodeOf(T data) {
            Node currentNode = Head;
            while (currentNode != null) {
                if (EqualityComparer<T>.Default.Equals(currentNode.Data, data)) {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        internal override T First() {
            if (Head == null)
                return default(T);
            return Head.Data;
        }
        internal override T Last() {
            if (Tail == null)
                return default(T);
            return Tail.Data;
        }
        internal override T Prev(T item) {
            Node currNode = GetNodeOf(item);

            if (currNode.Prev == null)
                return default(T);
            return currNode.Prev.Data;
        }

        internal override T Next(T item) {
            Node currNode = GetNodeOf(item);

            if (currNode.Next == null)
                return default(T);
            return currNode.Next.Data;
        }

        public override ForwardIterator<T> GetForwardIterator() {
            return new ForwardIterator<T>(this);
        }

        public override ReverseIterator<T> GetReverseIterator() {
            return new ReverseIterator<T>(this);
        }
    }
}
