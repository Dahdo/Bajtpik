using System;
using System.Collections.Generic;

namespace Representation2 {
    public class BookStore {
        public int Books { get; set; }
        public int Newspapers { get; set; }
        public int BoardGames { get; set; }
        public BookStore(int books, int newspapers, int boardGames) {
            this.Books = books;
            this.Newspapers =newspapers;
            this.BoardGames = boardGames;
        }
    }
    public class Book {
        public int Title { get; set; }
        public int Authors { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(int Title, int year, int pageCount, int authors) {
            this.Title = Title;
            this.Year = year;
            this.PageCount = pageCount;
            this.Authors = authors;
        }
    }

    public class NewsPaper {
        public int Title { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public NewsPaper(int title, int year, int pageCount) {
            this.Title = title;
            this.Year = year;
            this.PageCount = pageCount;
        }
    }
    public class BoardGame {
        public int Title { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public int Diffuculty { get; set; }
        public int Authors { get; set; }

        public BoardGame(int title, int minplayer, int maxplayer, int difficulty, int authors) {
            this.Title = title;
            this.MinPlayer = minplayer;
            this.MaxPlayer = maxplayer;
            this.Diffuculty = difficulty;
            this.Authors = authors;
        }
    }

    public class Author {
        public int Name { get; set; }
        public int Surname { get; set; }
        public int Nickaname { get; set; }
        public int BirthYear { get; set; }

        public Author(int name, int surname, int birthYear, int nickName = -1) {
            this.Name = name;
            this.Surname = surname;
            this.BirthYear = birthYear;
            this.Nickaname = nickName;
        }
    }
}
