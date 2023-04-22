namespace MainFormat {
    public class Book : Project1_Interface1.Book {
        public string Title { get; set; }
        public List<Project1_Interface1.Author> Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(string Title, int year, int pageCount, List<Author> authors) {
            this.Title = Title;
            this.Year = year;
            this.PageCount = pageCount;
            this.Authors = new List<Project1_Interface1.Author>(authors);
        }
    }

    public class NewsPaper : Project1_Interface1.NewsPaper {
        public string Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public NewsPaper(string title, int year, int pageCount) {
            this.Title = title;
            this.Year = year;
            this.PageCount = pageCount;
        }
    }
    public class BoardGame : Project1_Interface1.BoardGame {
        public string Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public List<Project1_Interface1.Author> Authors { get; set; }
        public BoardGame(string title, int minplayer, int maxplayer, int difficulty, List<Author> authors) {
            this.Title = title;
            this.MinPlayer = minplayer;
            this.MaxPlayer = maxplayer;
            this.Diffuculty = difficulty;
            this.Authors = new List<Project1_Interface1.Author>(authors);
        }
    }

    public class Author : Project1_Interface1.Author {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Nickname { get; set; }
        public int BirthYear { get; set; }

        public Author(string name, string surname, int birthYear, string nickName = null) {
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
            this.Nickname = nickName;
        }
    }
}
