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

namespace Project3_Builder {
    public interface ResourceBuilder {
        public List<string> GetFields();
        public ResourceBuilder ResetData();
        public Resource GetResource();
    }
    public interface BookBuilder {
        public void AddTitle(string title);
        public void AddYear(int year);
        public void AddPageCount(int pageCount);
    }
    public interface NewsPaperBuilder {
        public void AddTitle(string title);
        public void AddYear(int year);
        public void AddPageCount(int pagecount);
    }
    public interface BoardGameBuilder {
        public void AddTitle(string title); 
        public void AddMinPlayer(int player);
        public void AddMaxPlayer(int player);
        public void AddDifficulty(int difficulty);
    }
    public interface AuthorBuilder {
        public void AddName(string name);
        public void AddSurname(string surname);
        public void AddNickname(string nickname);
        public void AddBirthYear(int year);

    }
}