

using Project1_Adapter;
using Project2_Algorithms;
using Project2_Collections;
using Project2_Iterators;
using Project3_CollectionWrapper;

namespace Project3_Visitor {
    public class ListVisitor : Visitor {
        public ListVisitor() { }
        public void Visit<Book>(Vector<Book> book) {
            ForwardIterator<Book > fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            ForwardIterator<Author> fid = author.GetForwardIterator();
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }
    }

    public class FindVisitor : Visitor {
        public void Visit<Book>(Vector<Book> book) {
            ForwardIterator<Book> fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            ForwardIterator<Author> fid = author.GetForwardIterator();
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }
    }

    public class AddVisitor : Visitor {
        public void Visit<Book>(Vector<Book> book) {
            ForwardIterator<Book> fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            ForwardIterator<Author> fid = author.GetForwardIterator();
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }
    }

}
