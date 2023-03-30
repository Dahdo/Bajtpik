﻿using Interface1;
namespace Adapter1 {
    public class BookAdapter : Book {
        private readonly SecondaryFormat.Book book;
        string Book.Title {
            get => (string)Client.Program.bookStoreMap[book.Title];
            set => Client.Program.bookStoreMap[book.Title] = value; 
        }
        List<Author> Book.Authors {
            get {
                List<Author> authorList = new List<Author>();
                foreach (int authorIndex in (List<int>)Client.Program.bookStoreMap[book.Authors]) {
                    SecondaryFormat.Author author = (SecondaryFormat.Author)Client.Program.bookStoreMap[authorIndex];
                    authorList.Add(new MainFormat.Author((string)Client.Program.bookStoreMap[author.Name], 
                    (string)Client.Program.bookStoreMap[author.Surname], (int)Client.Program.bookStoreMap[author.BirthYear],
                    (string)Client.Program.bookStoreMap[author.Nickaname]));
                }
                return authorList;
            }
            set {}
            
        }
        int Book.Year {
            get => (int)Client.Program.bookStoreMap[book.Year];
            set => Client.Program.bookStoreMap[book.Year] = value; 
        }
        int Book.PageCount {
            get => (int)Client.Program.bookStoreMap[book.PageCount];
            set => Client.Program.bookStoreMap[book.PageCount] = value;
        }

        public BookAdapter(SecondaryFormat.Book book) {
            this.book = book;
        }
    }

    public class NewsPaperAdapter : NewsPaper {
        private readonly SecondaryFormat.NewsPaper newsPaper;
        string NewsPaper.Title {
            get => (string)Client.Program.bookStoreMap[newsPaper.Title];
            set => Client.Program.bookStoreMap[newsPaper.Title] = value;
        }
        int NewsPaper.Year {
            get => (int)Client.Program.bookStoreMap[newsPaper.Year];
            set => Client.Program.bookStoreMap[newsPaper.Year] = value;
        }
        int NewsPaper.PageCount {
            get => (int)Client.Program.bookStoreMap[newsPaper.PageCount];
            set => Client.Program.bookStoreMap[newsPaper.PageCount] = value;
        }

        public NewsPaperAdapter(SecondaryFormat.NewsPaper newspaper) {
            this.newsPaper = newspaper;
        }
    }

    public class BoardGameAdapter : BoardGame {
        private readonly SecondaryFormat.BoardGame boardGame;
        string BoardGame.Title {
            get => (string)Client.Program.bookStoreMap[boardGame.Title];
            set => Client.Program.bookStoreMap[boardGame.Title] = value;
        }
        int BoardGame.MinPlayer {
            get => (int)Client.Program.bookStoreMap[boardGame.MinPlayer];
            set => Client.Program.bookStoreMap[boardGame.MinPlayer] = value;
        }
        int BoardGame.MaxPlayer {
            get => (int)Client.Program.bookStoreMap[boardGame.MaxPlayer];
            set => Client.Program.bookStoreMap[boardGame.MaxPlayer] = value;
        }
        int BoardGame.Diffuculty {
            get => (int)Client.Program.bookStoreMap[boardGame.Diffuculty];
            set => Client.Program.bookStoreMap[boardGame.Diffuculty] = value;
        }
        List<Author> BoardGame.Authors {
            get {
                List<Author> authorList = new List<Author>();
                foreach (int authorIndex in (List<int>)Client.Program.bookStoreMap[boardGame.Authors]) {
                    SecondaryFormat.Author author = (SecondaryFormat.Author)Client.Program.bookStoreMap[authorIndex];
                    authorList.Add(new MainFormat.Author((string)Client.Program.bookStoreMap[author.Name], 
                    (string)Client.Program.bookStoreMap[author.Surname], (int)Client.Program.bookStoreMap[author.BirthYear],
                    (string)Client.Program.bookStoreMap[author.Nickaname]));
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
            get => (string)Client.Program.bookStoreMap[author.Name];
            set => Client.Program.bookStoreMap[author.Name] = value;
        }
        string Author.Surname {
            get => (string)Client.Program.bookStoreMap[author.Surname];
            set => Client.Program.bookStoreMap[author.Surname] = value;
        }
        string? Author.Nickaname {
            get => (string)Client.Program.bookStoreMap[author.Nickaname];
            set => Client.Program.bookStoreMap[author.Nickaname] = value;
        }
        int Author.BirthYear {
            get => (int)Client.Program.bookStoreMap[author.BirthYear];
            set => Client.Program.bookStoreMap[author.BirthYear] = value;
        }

        public AuthorAdapter(SecondaryFormat.Author author) {
            this.author = author;
        }
    }
}
