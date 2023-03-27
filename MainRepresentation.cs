using System;
using System.Collections.Generic;

namespace Representation1 {
    public class BookStore {
        public List<Book> Books { get; set; }
        public List<NewsPaper> Newspapers { get; set; }
        public List<BoardGame> BoardGames { get; set; }
        public BookStore(List<Book> books, List<NewsPaper> newspapers, List<BoardGame> boardGames) {
            this.Books = new List<Book>(books);
            this.Newspapers = new List<NewsPaper>(newspapers);
            this.BoardGames = new List<BoardGame>(boardGames);
        }
    }
    public class Book {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(string Title, int year, int pageCount, List<Author> authors) {
            this.Title = Title;
            this.Year = year;
            this.PageCount = pageCount;
            this.Authors = new List<Author>(authors);
        }
    }

    public class NewsPaper {
        public string Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public NewsPaper(string title, int year, int pageCount) {
            this.Title = title;
            this.Year = year;
            this.PageCount = pageCount;
        }
    }
    public class BoardGame {
        public string Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public List<Author> Authors { get; set; }
        public BoardGame(string title, int minplayer, int maxplayer, int difficulty, List<Author> authors) {
            this.Title = title;
            this.MinPlayer = minplayer;
            this.MaxPlayer = maxplayer;
            this.Diffuculty = difficulty;
            this.Authors = new List<Author>(authors);
        }
    }

    public class Author {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Nickaname { get; set; }
        public int BirthYear { get; set; }

        public Author(string name, string surname, int birthYear, string nickName = null) {
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
            this.Nickaname = nickName;
        }
    }
}
