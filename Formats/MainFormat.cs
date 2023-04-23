using System.Text;

namespace MainFormat {
    public class Book : Project1_Adapter.Book {
        public string Title { get; set; }
        public List<Project1_Adapter.Author> Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(string Title, int year, int pageCount, List<Author> authors) {
            this.Title = Title;
            this.Year = year;
            this.PageCount = pageCount;
            this.Authors = new List<Project1_Adapter.Author>(authors);
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[BOOK] ");
            stringBuilder.Append($"Title: {this.Title}, Year: {this.Year}, Pages: {this.PageCount}, Author(s):\n");
            foreach (Author author in this.Authors) {
                stringBuilder.Append(author.ToString());
            }

            return stringBuilder.ToString();
        }
    }

    public class NewsPaper : Project1_Adapter.NewsPaper {
        public string Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public NewsPaper(string title, int year, int pageCount) {
            this.Title = title;
            this.Year = year;
            this.PageCount = pageCount;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[News Paper] ");
            stringBuilder.Append($"Title: {this.Title}, Year: {this.Year}, Pages: {this.PageCount}");

            return stringBuilder.ToString();
        }
    }
    public class BoardGame : Project1_Adapter.BoardGame {
        public string Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public List<Project1_Adapter.Author> Authors { get; set; }
        public BoardGame(string title, int minplayer, int maxplayer, int difficulty, List<Author> authors) {
            this.Title = title;
            this.MinPlayer = minplayer;
            this.MaxPlayer = maxplayer;
            this.Diffuculty = difficulty;
            this.Authors = new List<Project1_Adapter.Author>(authors);
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[Board Game] ");
            stringBuilder.Append($"Title: {this.Title}, Min. Players: {this.MinPlayer}, Max. Players: {this.MaxPlayer}, Difficulty: {this.Diffuculty} Author(s):\n");
            foreach (Project1_Adapter.Author author in this.Authors) {
                stringBuilder.Append(author.ToString());
            }
            return stringBuilder.ToString();
        }
    }

    public class Author : Project1_Adapter.Author {
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

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[Author] ");
            stringBuilder.Append($"Names: {this.Name} {this.Surname} {this.Nickname}, Born: {this.BirthYear}");

            return stringBuilder.ToString();
        }
    }
}
