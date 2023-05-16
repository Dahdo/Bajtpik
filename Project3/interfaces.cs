using Project2_Collections;
using Project1_Adapter;
using Project3_Visitor;

namespace Project3_Visitor {
    public interface Visitor {
        public void Visit(BajtpikCollection<Book> book);
        public void Visit(BajtpikCollection<BoardGame> boardGame);
        public void Visit(BajtpikCollection<NewsPaper> newsPaper);
        public void Visit(BajtpikCollection<Author> collection);
        public Visitor AddRequirements(List<String> requirements);
        public Visitor ClearData();
    }
}

namespace Project3_CollectionWrapper {
    public interface CollectionWrapper {
        public void Accept(Visitor visitor);
    }
}