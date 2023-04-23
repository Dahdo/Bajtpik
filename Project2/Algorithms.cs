using Project2_Collections;
using Project2_Iterators;
namespace Project2_Algorithms {
    public static class Algorithms<T> {
        public static T? Find(BajtpikCollection<T> collection, Func<T, bool> condition, bool begin) {
            if (collection == null || condition == null)
                return default;

            BajtpikIterator<T> it;
            if (begin)
                it = collection.GetForwardIterator();
            else
                it = collection.GetReverseIterator();
            do {
                if (condition(it.Current()))
                    return it.Current();
            } while (it.Move());

            return default;
        }

        public static void Print(BajtpikCollection<T> collection, Func<bool> condition, bool begin) {

        }
    }
}
