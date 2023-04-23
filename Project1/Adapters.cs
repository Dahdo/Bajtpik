using System.Text;

namespace Project1_Adapter {
    public class BookAdapter : Book {
        private readonly SecondaryFormat.Book book;
        private readonly int numRepr;
        public string Title {
            get {
                if (numRepr == 1)
                   return Client.Program.stringMap[book.Title];
                else
                    return Client.Program.stringHashMap[book.Title];
            }
            set {
                if(numRepr == 1)
                    Client.Program.stringMap[book.Title] = value;
                else
                    Client.Program.stringHashMap[book.Title] = value;
            }
        }
        public List<Author> Authors {
            get {
                if(numRepr == 1) {
                    List<Author> authorList = new List<Author>();
                    foreach (SecondaryFormat.Author author in Client.Program.authorListMap[book.Authors]) {
                        authorList.Add(new MainFormat.Author(Client.Program.stringMap[author.Name],
                        Client.Program.stringMap[author.Surname], Client.Program.intMap[author.BirthYear],
                        Client.Program.stringMap[author.Nickname]));
                    }
                    return authorList;
                }
                else {
                    List<Author> authorList = new List<Author>();
                    foreach (SecondaryFormat.Author author in Client.Program.authorListHashMap[book.Authors]) {
                        authorList.Add(new MainFormat.Author(Client.Program.stringHashMap[author.Name],
                        Client.Program.stringHashMap[author.Surname], Client.Program.intMap[author.BirthYear],
                        Client.Program.stringHashMap[author.Nickname]));
                    }
                    return authorList;
                }
            }
            set {}
            
        }
        public int Year {
            get => (int)Client.Program.intMap[book.Year];
            set => Client.Program.intMap[book.Year] = value; 
        }
        public int PageCount {
            get => (int)Client.Program.intMap[book.PageCount];
            set => Client.Program.intMap[book.PageCount] = value;
        }

        public BookAdapter(SecondaryFormat.Book book, int numRepr) {
            this.book = book;
            this.numRepr = numRepr;
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

    public class NewsPaperAdapter : NewsPaper {
        private readonly SecondaryFormat.NewsPaper newsPaper;
        private readonly int numRepr;
        public string Title {
            get {
                if(numRepr == 1)
                    return Client.Program.stringMap[newsPaper.Title];
                else
                    return Client.Program.stringHashMap[newsPaper.Title];
            }
            set {
                if(numRepr == 1)
                    Client.Program.stringMap[newsPaper.Title] = value;
                else
                    Client.Program.stringHashMap[newsPaper.Title] = value;
            }
        }
        public int Year {
            get => (int)Client.Program.intMap[newsPaper.Year];
            set => Client.Program.intMap[newsPaper.Year] = value;
        }
        public int PageCount {
            get => (int)Client.Program.intMap[newsPaper.PageCount];
            set => Client.Program.intMap[newsPaper.PageCount] = value;
        }

        public NewsPaperAdapter(SecondaryFormat.NewsPaper newspaper, int numRepr) {
            this.newsPaper = newspaper;
            this.numRepr = numRepr;
        }

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[News Paper] ");
            stringBuilder.Append($"Title: {this.Title}, Year: {this.Year}, Pages: {this.PageCount}");

            return stringBuilder.ToString();
        }
    }

    public class BoardGameAdapter : BoardGame {
        private readonly SecondaryFormat.BoardGame boardGame;
        private readonly int numRepr;
        public string Title {
            get {
                if(numRepr == 1)
                    return Client.Program.stringMap[boardGame.Title];
                else 
                    return Client.Program.stringHashMap[boardGame.Title];
            }
            set {
                if (numRepr == 1)
                    Client.Program.stringMap[boardGame.Title] = value;
                else
                    Client.Program.stringHashMap[boardGame.Title] = value;
            }
        }
        public int MinPlayer {
            get => (int)Client.Program.intMap[boardGame.MinPlayer];
            set => Client.Program.intMap[boardGame.MinPlayer] = value;
        }
        public int MaxPlayer {
            get => (int)Client.Program.intMap[boardGame.MaxPlayer];
            set => Client.Program.intMap[boardGame.MaxPlayer] = value;
        }
        public int Diffuculty {
            get => (int)Client.Program.intMap[boardGame.Diffuculty];
            set => Client.Program.intMap[boardGame.Diffuculty] = value;
        }
        public List<Author> Authors {
            get {
                if(numRepr == 1) {
                    List<Author> authorList = new List<Author>();
                    foreach (SecondaryFormat.Author author in Client.Program.authorListMap[boardGame.Authors]) {
                        authorList.Add(new MainFormat.Author(Client.Program.stringMap[author.Name],
                        Client.Program.stringMap[author.Surname], Client.Program.intMap[author.BirthYear],
                        Client.Program.stringMap[author.Nickname]));
                    }
                    return authorList;
                }
                else {
                    List<Author> authorList = new List<Author>();
                    foreach (SecondaryFormat.Author author in Client.Program.authorListHashMap[boardGame.Authors]) {
                        authorList.Add(new MainFormat.Author(Client.Program.stringHashMap[author.Name],
                        Client.Program.stringHashMap[author.Surname], Client.Program.intMap[author.BirthYear],
                        Client.Program.stringHashMap[author.Nickname]));
                    }
                    return authorList;
                }
            }

            set {}
        }

        public BoardGameAdapter(SecondaryFormat.BoardGame boardGame, int numRepr) {
            this.boardGame = boardGame;
            this.numRepr = numRepr;
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

    public class AuthorAdapter : Author {
        private readonly SecondaryFormat.Author author;
        private readonly int numRepr;
        public string Name {
            get {
                if(numRepr == 1)
                    return Client.Program.stringMap[author.Name];
                else
                    return Client.Program.stringHashMap[author.Name];
            }
            set {
                if (numRepr == 1)
                    Client.Program.stringMap[author.Name] = value;
                else
                    Client.Program.stringHashMap[author.Name] = value;
            }
        }
        public string Surname {
            get {
                if (numRepr == 1)
                    return Client.Program.stringMap[author.Surname];
                else
                    return Client.Program.stringHashMap[author.Surname];
            }
            set {
                if (numRepr == 1)
                    Client.Program.stringMap[author.Surname] = value;
                else
                    Client.Program.stringHashMap[author.Surname] = value;
            }
        }
        public string? Nickname {
            get {
                if (numRepr == 1)
                    return Client.Program.stringMap[author.Nickname];
                else
                    return Client.Program.stringHashMap[author.Nickname];
            }
            set {
                if (numRepr == 1)
                    Client.Program.stringMap[author.Nickname] = value;
                else
                    Client.Program.stringHashMap[author.Nickname] = value;
            }
        }
        public int BirthYear {
            get => (int)Client.Program.intMap[author.BirthYear];
            set => Client.Program.intMap[author.BirthYear] = value;
        }

        public AuthorAdapter(SecondaryFormat.Author author, int numRepr) {
            this.author = author;
            this.numRepr = numRepr;
        }

        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("[Author] ");
            stringBuilder.Append($"Names: {this.Name} {this.Surname} {this.Nickname}, Born: {this.BirthYear}");

            return stringBuilder.ToString();
        }
    }
}
