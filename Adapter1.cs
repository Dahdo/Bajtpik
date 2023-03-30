using Interface1;
namespace Adapter1 {
    public class BookAdapter : Book {
        private readonly SecondaryFormat.Book book;
        string Book.Title {
            get => (string)Client.Program.stringMap[book.Title];
            set => Client.Program.stringMap[book.Title] = value; 
        }
        List<Author> Book.Authors {
            get {
                List<Author> authorList = new List<Author>();
                foreach (SecondaryFormat.Author author in Client.Program.authorListMap[book.Authors]) {
                    authorList.Add(new MainFormat.Author(Client.Program.stringMap[author.Name], 
                    Client.Program.stringMap[author.Surname], Client.Program.intMap[author.BirthYear],
                    Client.Program.stringMap[author.Nickaname]));
                }
                return authorList;
            }
            set {}
            
        }
        int Book.Year {
            get => (int)Client.Program.intMap[book.Year];
            set => Client.Program.intMap[book.Year] = value; 
        }
        int Book.PageCount {
            get => (int)Client.Program.intMap[book.PageCount];
            set => Client.Program.intMap[book.PageCount] = value;
        }

        public BookAdapter(SecondaryFormat.Book book) {
            this.book = book;
        }
    }

    public class NewsPaperAdapter : NewsPaper {
        private readonly SecondaryFormat.NewsPaper newsPaper;
        string NewsPaper.Title {
            get => (string)Client.Program.stringMap[newsPaper.Title];
            set => Client.Program.stringMap[newsPaper.Title] = value;
        }
        int NewsPaper.Year {
            get => (int)Client.Program.intMap[newsPaper.Year];
            set => Client.Program.intMap[newsPaper.Year] = value;
        }
        int NewsPaper.PageCount {
            get => (int)Client.Program.intMap[newsPaper.PageCount];
            set => Client.Program.intMap[newsPaper.PageCount] = value;
        }

        public NewsPaperAdapter(SecondaryFormat.NewsPaper newspaper) {
            this.newsPaper = newspaper;
        }
    }

    public class BoardGameAdapter : BoardGame {
        private readonly SecondaryFormat.BoardGame boardGame;
        string BoardGame.Title {
            get => (string)Client.Program.stringMap[boardGame.Title];
            set => Client.Program.stringMap[boardGame.Title] = value;
        }
        int BoardGame.MinPlayer {
            get => (int)Client.Program.intMap[boardGame.MinPlayer];
            set => Client.Program.intMap[boardGame.MinPlayer] = value;
        }
        int BoardGame.MaxPlayer {
            get => (int)Client.Program.intMap[boardGame.MaxPlayer];
            set => Client.Program.intMap[boardGame.MaxPlayer] = value;
        }
        int BoardGame.Diffuculty {
            get => (int)Client.Program.intMap[boardGame.Diffuculty];
            set => Client.Program.intMap[boardGame.Diffuculty] = value;
        }
        List<Author> BoardGame.Authors {
            get {
                List<Author> authorList = new List<Author>();
                foreach (SecondaryFormat.Author author in Client.Program.authorListMap[boardGame.Authors]) {
                    authorList.Add(new MainFormat.Author(Client.Program.stringMap[author.Name],
                    Client.Program.stringMap[author.Surname], Client.Program.intMap[author.BirthYear],
                    Client.Program.stringMap[author.Nickaname]));
                }
                return authorList;
            }

            set {}
        }

        public BoardGameAdapter(SecondaryFormat.BoardGame boardGame) {
            this.boardGame = boardGame;
        }
    }

    public class AuthorAdapter : Author {
        private readonly SecondaryFormat.Author author;
        string Author.Name {
            get => (string)Client.Program.stringMap[author.Name];
            set => Client.Program.stringMap[author.Name] = value;
        }
        string Author.Surname {
            get => (string)Client.Program.stringMap[author.Surname];
            set => Client.Program.stringMap[author.Surname] = value;
        }
        string? Author.Nickaname {
            get => (string)Client.Program.stringMap[author.Nickaname];
            set => Client.Program.stringMap[author.Nickaname] = value;
        }
        int Author.BirthYear {
            get => (int)Client.Program.intMap[author.BirthYear];
            set => Client.Program.intMap[author.BirthYear] = value;
        }

        public AuthorAdapter(SecondaryFormat.Author author) {
            this.author = author;
        }
    }
}
