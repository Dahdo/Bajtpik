using Project2_Interface1;
using System.Threading;

namespace Project2_Collections {
    public class Vector<T> : BajtpikCollection<T> {
        private T[] Items;
        private int Count;

        public Vector() {
            Items = new T[0];
            Count = 0;
        }

        public void Add(T item) {
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

        public bool Remove(T item) {
            for(int i = 0; i < Count; i++) {
                if( EqualityComparer<T>.Default.Equals(Items[i], item))
                       return RemoveAt(i);
            }
            return false;
        }

        public int Size() {
            return Count;
        }
    }


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
        public void Add(T item) {
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

        public bool Remove(T item) {
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
        public int Size() {
            return Count;
        }
    }
}
