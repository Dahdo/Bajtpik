using Project2_Interfaces;
namespace project2_iterators {
    public class ForwardIterator<T> : BajtpikIterator<T> {

        private BajtpikCollection<T> collection;
        private T? CurrentItem;

        public ForwardIterator(BajtpikCollection<T> collection) {
            this.collection = collection;
            CurrentItem = collection.First();
        }

        public override T? Current() {
            return CurrentItem;
        }

        public override bool IsDone() {
            return EqualityComparer<T>.Default.Equals(CurrentItem, collection.Last());
        }

        public override bool Move() {
            T? prosedCurrent = collection.Next(CurrentItem);
            if (prosedCurrent == null)
                return false;
            else {
                CurrentItem = prosedCurrent;
                return true;
            }
        }

        public override void Reset() {
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

        public override T? Current() {
            return CurrentItem;
        }

        public override bool IsDone() {
            return EqualityComparer<T>.Default.Equals(CurrentItem, collection.First());
        }

        public override bool Move() {
            T prosedCurrent = collection.Prev(CurrentItem);
            if (EqualityComparer<T>.Default.Equals(prosedCurrent, default(T)))
                return false;
            else {
                CurrentItem = prosedCurrent;
                return true;
            }
        }

        public override void Reset() {
            CurrentItem = collection.First();
        }
    }
}
