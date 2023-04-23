namespace Project1_Adapter {
    public class BookAdapter : Book {
        private readonly SecondaryFormat.Book book;
        private readonly int numRepr;
        string Book.Title {
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
        List<Author> Book.Authors {
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
        int Book.Year {
            get => (int)Client.Program.intMap[book.Year];
            set => Client.Program.intMap[book.Year] = value; 
        }
        int Book.PageCount {
            get => (int)Client.Program.intMap[book.PageCount];
            set => Client.Program.intMap[book.PageCount] = value;
        }

        public BookAdapter(SecondaryFormat.Book book, int numRepr) {
            this.book = book;
            this.numRepr = numRepr;
        }
    }

    public class NewsPaperAdapter : NewsPaper {
        private readonly SecondaryFormat.NewsPaper newsPaper;
        private readonly int numRepr;
        string NewsPaper.Title {
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
        int NewsPaper.Year {
            get => (int)Client.Program.intMap[newsPaper.Year];
            set => Client.Program.intMap[newsPaper.Year] = value;
        }
        int NewsPaper.PageCount {
            get => (int)Client.Program.intMap[newsPaper.PageCount];
            set => Client.Program.intMap[newsPaper.PageCount] = value;
        }

        public NewsPaperAdapter(SecondaryFormat.NewsPaper newspaper, int numRepr) {
            this.newsPaper = newspaper;
            this.numRepr = numRepr;
        }
    }

    public class BoardGameAdapter : BoardGame {
        private readonly SecondaryFormat.BoardGame boardGame;
        private readonly int numRepr;
        string BoardGame.Title {
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
    }

    public class AuthorAdapter : Author {
        private readonly SecondaryFormat.Author author;
        private readonly int numRepr;
        string Author.Name {
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
        string Author.Surname {
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
        string? Author.Nickname {
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
        int Author.BirthYear {
            get => (int)Client.Program.intMap[author.BirthYear];
            set => Client.Program.intMap[author.BirthYear] = value;
        }

        public AuthorAdapter(SecondaryFormat.Author author, int numRepr) {
            this.author = author;
            this.numRepr = numRepr;
        }
    }
}
