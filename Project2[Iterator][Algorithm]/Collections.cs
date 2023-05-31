using Project1_Adapter;
using Project2_Iterators;
using Project3_CollectionWrapper;
using Project3_Visitor;
using Project5_Memento;

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

        private int IndexOf(T item) {
            for (int i = 0; i < Count; i++) {
                if (EqualityComparer<T>.Default.Equals(Items[i], item))
                    return i;
            }
            return -1;
        }

        public  bool Remove(T item) {
            int index = IndexOf(item);

            if (index > -1)
                return RemoveAt(index);
            else
                return false;
        }

        public  int Size() {
            return Count;
        }

        //for iterators' sake

        public  T? First() {
            return Items[0];
        }
        public  T? Last() {
            return Items[Count - 1];
        }
        public  T? Prev(T item) {
            int index = IndexOf(item);
            if (index > 0)
                return Items[index - 1];
            else
                return default;
        }

        public  T? Next(T item) {
            int index = IndexOf(item);
            if (index < Count - 1)
                return Items[index + 1];
            else
                return default;
        }

        public  ForwardIterator<T> GetForwardIterator() {
            return new ForwardIterator<T>(this);
        }

        public  ReverseIterator<T> GetReverseIterator() {
            return new ReverseIterator<T>(this);
        }

        //For memento

        public IMemento Save() {
            List<object> list = new List<object>();
            foreach (var item in Items) {
                list.Add(item);
            }

            return new Memento(list);

        }

        public void Restore(IMemento memento) {
            var state = memento.GetState();
            Items = state.Cast<T>().ToArray();
            Count = Items.Length;
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
        public  void Add(T item) {
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

        public  bool Remove(T item) {
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
        public  int Size() {
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

        public  T First() {
            if (Head == null)
                return default(T);
            return Head.Data;
        }
        public  T Last() {
            if (Tail == null)
                return default(T);
            return Tail.Data;
        }
        public  T Prev(T item) {
            Node currNode = GetNodeOf(item);

            if (currNode.Prev == null)
                return default(T);
            return currNode.Prev.Data;
        }

        public  T Next(T item) {
            Node currNode = GetNodeOf(item);

            if (currNode.Next == null)
                return default(T);
            return currNode.Next.Data;
        }

        public  ForwardIterator<T> GetForwardIterator() {
            return new ForwardIterator<T>(this);
        }

        public  ReverseIterator<T> GetReverseIterator() {
            return new ReverseIterator<T>(this);
        }

        // For mementor
        public IMemento Save() {
            List<object> state = new List<object>();
            T current = Head.Data;
            state.Add(current);
            while (!EqualityComparer<T>.Default.Equals(current, Last())) {
                current = Next(current);
                state.Add(current);
            }
            return new Memento(state);
        }

        public void Restore(IMemento memento) {
            List<object> state = memento.GetState();
            Node current = Head;
            int count = 0;
            while(!EqualityComparer<T>.Default.Equals(current.Data, Last())) {
                current.Data = (T)state[count++];
            }
            if(state.Count > count) {
                this.Add((T)state[count++]);
            }
        }
    }


    //Project2 part2
    public class Heap<T> : BajtpikCollection<T> {
        private readonly Func<T, T, bool> Comparator;
        private List<T> HeapList;

        public Heap(Func<T, T, bool> comparator) {
            this.Comparator = comparator;
            HeapList = new List<T>();
        }

        public  ForwardIterator<T> GetForwardIterator() {
            return new ForwardIterator<T>(this);
        }

        public  ReverseIterator<T> GetReverseIterator() {
            return new ReverseIterator<T>(this);
        }


        public  void Add(T item) {
            HeapList.Add(item);
            int current = HeapList.Count - 1;

            while(current > 0) {
                int parent = (current - 1) / 2;
                if (Comparator(HeapList[current], HeapList[parent])) {
                    T tmpItem = HeapList[current];
                    HeapList[current] = HeapList[parent];
                    HeapList[parent] = tmpItem;
                    current = parent;
                }
                else
                    break;
            }
        }
        public T Remove() {
            if (this.HeapList.Count == 0)
                return default;

            T returnItem = HeapList[0];
            HeapList[0] = HeapList[HeapList.Count - 1];
            HeapList.RemoveAt(HeapList.Count - 1);
            int current = 0;

            while(current * 2 + 1 < HeapList.Count) {
                int left = current * 2 + 1;
                int right = current * 2 + 2;
                int smallest = left;

                if (right < HeapList.Count && Comparator(HeapList[right], HeapList[left]))
                    smallest = right;

                if (Comparator(HeapList[smallest], HeapList[current])) {
                    T tmpItem = HeapList[current];
                    HeapList[current] = HeapList[smallest];
                    HeapList[smallest] = tmpItem;
                    current = smallest;
                }
                else
                    break;
            }
            return returnItem;
        }

        public  int Size() {
            return HeapList.Count;
        }
        //this method is obsolete in case of a heap
        public  bool Remove(T item) {
            throw new NotImplementedException();
        }

        //for iterators's sake
        //iterators just iterates throught the list. no regards to it being a heap

        public  T? First() {
            if (HeapList.Count == 0)
                return default;
            else
                return HeapList[0];
        }

        public  T? Last() {
            if (HeapList.Count == 0)
                return default;
            else
                return HeapList[HeapList.Count - 1];
        }

        public T? Next(T item) {
            int nextIndex = HeapList.IndexOf(item) + 1;
            if (nextIndex < HeapList.Count)
                return HeapList[nextIndex];
            else
                return default;
        }

        public T? Prev(T item) {
            int prevIndex = HeapList.IndexOf(item) - 1;
            if (prevIndex > -1)
                return HeapList[prevIndex];
            else
                return default;
        }

        //For memento
        public IMemento Save() {
            List<object> list = new List<object>();
            foreach (var item in HeapList) {
                list.Add(item);
            }
            return new Memento(list);
        }

        public void Restore(IMemento memento) {
            HeapList.Clear();
            List<object> list = memento.GetState();
            foreach(var item in list) {
                HeapList.Add((T)item);
            }
        }
    }

}
