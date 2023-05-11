using Project2_Collections;
using Project1_Adapter;
using Project3_Visitor;

namespace Project3_Visitor {
    public interface Visitor {
        public void Visit<Book>(Vector<Book> book);
        public void Visit<BoardGame>(Heap<BoardGame> boardGame);
        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper);
        public void Visit<Author>(BajtpikCollection<Author> collection);
    }
}

namespace Project3_CollectionWrapper {
    public interface CollectionWrapper {
        public void Accept(Visitor visitor);
    }
}