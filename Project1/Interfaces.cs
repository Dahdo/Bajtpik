using System.Runtime.CompilerServices;

namespace Project1_Adapter {
    public interface Book {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }
        public string ToString();
    }

    public interface NewsPaper {
        public string Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public string ToString();
    }

    public interface BoardGame {
        public string Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public List<Author> Authors { get; set; }

        public string ToString();
    }

    public interface Author {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public int BirthYear { get; set; }

        public string ToString();
    }
}
