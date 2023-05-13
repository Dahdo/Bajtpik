namespace Project1_Adapter {
    public interface Book : LibraryResource {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public string ToString();
        public Book Clone();
    }

    public interface NewsPaper : LibraryResource {
        public string Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public string ToString();
        public NewsPaper Clone();
    }

    public interface BoardGame : LibraryResource {
        public string Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public List<Author> Authors { get; set; }

        public string ToString();
        public BoardGame Clone();
    }

    public interface Author : LibraryResource {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public int BirthYear { get; set; }

        public string ToString();
        public Author Clone();
    }
    public interface LibraryResource {

    }
}
