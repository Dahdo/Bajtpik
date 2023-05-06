using Project2_Collections;
using Project2_Iterators;
using System.Runtime.CompilerServices;

namespace Project2_Algorithms {
    public static class Algorithms<T> {
        public static T? Find(BajtpikIterator<T> it, Func<T, bool> condition) {
            if (it == null)
                return default;

            do {
                if (condition(it.Current()))
                    return it.Current();
            } while (it.Move());

            return default;
        }

        public static int CountIf(BajtpikIterator<T> it, Func<T, bool> condition) {
            if (it == null)
                return default;
            int count = 0;

            do {
                if (condition(it.Current()))
                    count++;
            } while (it.Move());

            return count;
        }

        public static void ForEach(BajtpikIterator<T> it, Action<T> action) {
            if (it == null)
                return;

            do {
                T? currentItem;
                if (typeof(T) == typeof(Project1_Adapter.Book))
                    currentItem = (T)((Project1_Adapter.Book)it.Current()!)?.Clone()!;

                else if (typeof(T) == typeof(Project1_Adapter.Author))
                    currentItem = (T)((Project1_Adapter.Author)it.Current()!)?.Clone()!;

                else if (typeof(T) == typeof(Project1_Adapter.NewsPaper))
                    currentItem = (T)((Project1_Adapter.NewsPaper)it.Current()!)?.Clone()!;

                else if (typeof(T) == typeof(Project1_Adapter.BoardGame))
                    currentItem = (T)((Project1_Adapter.BoardGame)it.Current()!)?.Clone()!;

                else
                    return;

                action(currentItem);
            } while (it.Move());
        }

        public static void Print(BajtpikCollection<T> collection, Func<T, bool> condition, bool begin) {
            if (collection == null || condition == null)
                return;

            BajtpikIterator<T> it;
            if (begin)
                it = collection.GetForwardIterator();
            else
                it = collection.GetReverseIterator();
            do {
                if (condition(it.Current()))
                    print(it.Current());
            } while (it.Move());
        }


        private static void print(T item) {
            if(typeof(T) == typeof(Project1_Adapter.Book)) {
                Project1_Adapter.Book? book = item as Project1_Adapter.Book;
                Console.WriteLine(book?.ToString());
            }
            else if (typeof(T) == typeof(Project1_Adapter.Author)) {
                Project1_Adapter.Author? author = item as Project1_Adapter.Author;
                Console.WriteLine(author?.ToString());
            }
            else if (typeof(T) == typeof(Project1_Adapter.NewsPaper)) {
                Project1_Adapter.NewsPaper? newsPaper = item as Project1_Adapter.NewsPaper;
                Console.WriteLine(newsPaper?.ToString());
            }
            else if (typeof(T) == typeof(Project1_Adapter.BoardGame)) {

                Project1_Adapter.BoardGame? boardGame = item as Project1_Adapter.BoardGame;
                Console.WriteLine(boardGame?.ToString());
            }
            else {
                Console.WriteLine("Have no idea what you want me to print!");
            }
        }
    }
}
