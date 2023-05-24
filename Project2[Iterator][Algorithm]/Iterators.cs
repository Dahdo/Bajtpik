using Project2_Collections;
namespace Project2_Iterators {
    public class ForwardIterator<T> : BajtpikIterator<T> {

        private BajtpikCollection<T> collection;
        private T? CurrentItem;

        public ForwardIterator(BajtpikCollection<T> collection) {
            this.collection = collection;
            CurrentItem = collection.First();
        }

        public T? Current() {
            return CurrentItem;
        }

        public bool IsDone() {
            return EqualityComparer<T>.Default.Equals(CurrentItem, collection.Last())
               && CurrentItem.GetHashCode == collection.Last().GetHashCode;
        }

        public bool Move() {
            T? prosedCurrent = collection.Next(CurrentItem);
            if (prosedCurrent == null)
                return false;
            else {
                CurrentItem = prosedCurrent;
                return true;
            }
        }

        public void Reset() {
            CurrentItem = collection.First();
        }
    }


    //reverse iterator
    public class ReverseIterator<T> : BajtpikIterator<T> {

        private BajtpikCollection<T> collection;
        private T? CurrentItem;

        public ReverseIterator(BajtpikCollection<T> collection) {
            this.collection = collection;
            CurrentItem = collection.Last();
        }

        public T? Current() {
            return CurrentItem;
        }

        public bool IsDone() {
            return EqualityComparer<T>.Default.Equals(CurrentItem, collection.First());
        }

        public bool Move() {
            T prosedCurrent = collection.Prev(CurrentItem);
            if (EqualityComparer<T>.Default.Equals(prosedCurrent, default(T)))
                return false;
            else {
                CurrentItem = prosedCurrent;
                return true;
            }
        }

        public void Reset() {
            CurrentItem = collection.First();
        }
    }
}
