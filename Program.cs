using Representation1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client {
    internal class Program {

        public static void Main(string[] args) {

            #region Representation1
            #region instantiation
            //Authors
            Representation1.Author douglas = new Representation1.Author("Douglas", "Adams", 1952);
            Representation1.Author tom = new Representation1.Author("Tom", "Wolfe", 1930);
            Representation1.Author elmar = new Representation1.Author("Elmar", "Eisemann", 1978);
            Representation1.Author michael1 = new Representation1.Author("Michael", "Schwarz", 1970);
            Representation1.Author ulf = new Representation1.Author("Ulf", "Assarsson", 1975);
            Representation1.Author michael2 = new Representation1.Author("Michael", "Wimmer", 1980);
            Representation1.Author frank = new Representation1.Author("Frank", "Herbert", 1920);
            Representation1.Author terry = new Representation1.Author("Terry", "Pratchett", 1948);
            Representation1.Author neil = new Representation1.Author("Neil", "Gaiman", 1960);
            Representation1.Author jamey = new Representation1.Author("Jamey", "Stegmaier", 1975);
            Representation1.Author jakub = new Representation1.Author("Jakub", "Różalski", 1981, "Mr. Werewolf");
            Representation1.Author klaus = new Representation1.Author("Klaus", "Teuber", 1952);
            Representation1.Author alfred = new Representation1.Author("Alfred", "Butts", 1899);
            Representation1.Author james = new Representation1.Author("James", "Brunot", 1902);
            Representation1.Author christian = new Representation1.Author("Christian T.", "Petersen", 1970);

            //BoardGames
            Representation1.BoardGame scythe = new Representation1.BoardGame("Scythe", 1, 5, 7, new List<Representation1.Author>() { jamey, jakub });
            Representation1.BoardGame catan = new Representation1.BoardGame("Catan", 3, 4, 6, new List<Representation1.Author>() { klaus });
            Representation1.BoardGame scrabble = new Representation1.BoardGame("Scrabble", 2, 4, 5, new List<Representation1.Author>() { james, alfred });
            Representation1.BoardGame twilightImperium = new Representation1.BoardGame("Twilight Imperium", 3, 8, 9, new List<Representation1.Author>() { christian });

            //Newspapers
            Representation1.NewsPaper nwp1 = new Representation1.NewsPaper("International Journal of Human-Computer Studies", 2023, 300);
            Representation1.NewsPaper nwp2 = new Representation1.NewsPaper("Nature", 1869, 200);
            Representation1.NewsPaper nwp3 = new Representation1.NewsPaper("National Geographic", 2001, 106);
            Representation1.NewsPaper nwp4 = new Representation1.NewsPaper("Pixel.", 2015, 115);

            //Books
            Representation1.Book book1 = new Representation1.Book("The Hitchhiker's Guide to the Galaxy", 1987, 320, new List<Representation1.Author> { douglas });
            Representation1.Book book2 = new Representation1.Book("The Right Stuff", 1987, 512, new List<Representation1.Author> { tom });
            Representation1.Book book3 = new Representation1.Book("Real-Time Shadows", 2011, 383, new List<Representation1.Author> { elmar, michael1, ulf, michael2 });
            Representation1.Book book4 = new Representation1.Book("Mesjasz Diuny", 1972, 272, new List<Representation1.Author> { frank });
            Representation1.Book book5 = new Representation1.Book("Dobry Omen", 1990, 416, new List<Representation1.Author> { terry, neil });
            #endregion

            Representation1.BookStore mainBookstore = new Representation1.BookStore(
                new List<Representation1.Book> { book1, book2, book3, book4, book5 },
                new List<Representation1.NewsPaper> { nwp1, nwp2, nwp3, nwp4 },
                new List<Representation1.BoardGame>{ scythe, catan, scrabble, twilightImperium }
                );

            //printing 
            Console.WriteLine("------------------------Main Representation---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (Representation1.Book book in mainBookstore.Books) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (Representation1.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine($" publication year: {book.Year} page count: {book.PageCount}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (Representation1.NewsPaper newspaper in mainBookstore.Newspapers) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (Representation1.BoardGame bgame in mainBookstore.BoardGames) {
                Console.Write($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                foreach (Representation1.Author author in bgame.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine();
            }

            #endregion

            #region Representation2
            //instantiation
            IDictionary<int, Object> libraryMap = new Dictionary<int, Object>()
            {
                {-1, null }, //for all nullable values ex: nickname
                //Authors
                {0, "Douglas"}, {1, "Adams"}, {2, 1952},
                {3, new Representation2.Author(0, 1, 2) },

                {4, "Tom" }, {5, "Wolfe" }, {6, 1930 },
                {7, new Representation2.Author(4, 5, 6) },

                {8, "Elmar" }, {9, "Eisemann" }, {10, 1978 },
                {11, new Representation2.Author(8, 9, 10) },

                {12, "Michael" }, {13, "Schwarz" }, {14, 1970 },
                {15, new Representation2.Author(12, 13, 14) },

                {16, "Ulf" }, {17, "Assarsson" }, {18, 1975 },
                {19, new Representation2.Author(16, 17, 18) },

                {20, "Michael" }, {21, "Wimmer" }, {22, 1980 },
                {23, new Representation2.Author(20, 21, 22) },

                {24, "Frank" }, {25, "Herbert" }, {26, 1920 },
                {27, new Representation2.Author(24, 25, 26) },

                {28, "Terry" }, {29, "Pratchett" }, {30, 1948 },
                {31, new Representation2.Author(28, 29, 30) },

                {32, "Neil" }, {33, "Gaiman" }, {34, 1960 },
                {35, new Representation2.Author(32, 33, 34) },

                {36, "Jamey" }, {37, "Stegmaier" }, {38, 1975 },
                {39, new Representation2.Author(36, 37, 38) },

                {40, "Jakub" }, {41, "Różalski" }, {42, 1981 }, {43, "Mr. Werewolf" },
                {44, new Representation2.Author(40, 41, 42, 43) },

                {45, "Klaus" }, {46, "Teuber" }, {47, 1952 },
                {48, new Representation2.Author(45, 46, 47) },

                {49, "Alfred" }, {50, "Butts" }, {51, 1899 },
                {52, new Representation2.Author(49, 5, 51) },

                {53, "James" }, {54, "Brunot" }, {55, 1902 },
                {56, new Representation2.Author(53, 54, 55) },

                {57, "Christian T." } , {58, "Petersen" }, {59, 1970 },
                {60, new Representation2.Author(57, 58, 59) },

                //BoardGames
                {61, "Scythe" }, {62, 1 } , {63, 5 }, {64, 7 }, {65, new List<int> {39, 44}},
                {66, new Representation2.BoardGame(61, 62, 63, 64, 65) },

                {67, "Catan" } , {68, 3 }, {69, 4 } , {70, 6 }, {71, new List<int>{48}},
                {72, new Representation2.BoardGame(67, 68, 69, 70, 71) },

                {73, "Scrabble" }, {74, 2 }, {75, 4 }, {76, 5 }, {77, new List<int>{56, 52}},
                {78, new Representation2.BoardGame(73, 74, 75, 76, 77) },

                {79, "Twilight Imperium" }, {80, 3 } , {81, 8 }, {82, 9 }, {83, new List<int> {60}},
                {84, new Representation2.BoardGame(79, 80, 81, 82, 83) },

                //Books
                {85, "The Hitchhiker's Guide to the Galaxy" }, {86, 1987 }, {87, 320 }, {88, new List<int>{3}},
                {89, new Representation2.Book(85, 86, 87, 88)},

                {90, "The Right Stuff" }, {91, 1987 }, {92, 512 }, {93, new List<int>{7}},
                {94, new Representation2.Book(90, 91, 92, 93) },

                {95, "Real-Time Shadows" }, {96, 2011 }, {97, 383} , {98, new List<int>{11, 15, 19, 23}},
                {99, new Representation2.Book(95, 96, 97, 98) },

                {100, "Mesjasz Diuny" }, {101, 1972 }, {102, 272 }, {103, new List<int> {27} },
                {104, new Representation2.Book(100, 101, 102, 103) },

                {105, "Dobry Omen" }, {106, 1990 }, {107, 416 }, {108, new List<int>{ 31, 35 }},
                {109, new Representation2.Book(105, 106, 107, 108) },

                //Newspapers
                {110, "International Journal of Human-Computer Studies" }, {111, 2023}, {112, 300 },
                {113, new Representation2.NewsPaper(110, 111, 112) },

                {114, "Nature" }, {115, 1869 }, {116, 200 },
                {117, new Representation2.NewsPaper(114, 115, 116) },

                {118, "National Geographic" }, {119, 2001 } , {120, 106 },
                {121, new Representation2.NewsPaper(118, 119, 120) },

                {122, "Pixel." } , {123, 2015 }, {124, 115 },
                {125, new Representation2.NewsPaper(122, 123, 124) },

                //bookstore
                {126, new List<int> { 89, 94, 99, 104, 109 } },
                {127, new List<int> { 113, 117, 121, 125 } },
                {128, new List<int> { 66, 72, 78, 84 } }
            };

            Representation2.BookStore secondaryBookstore = new Representation2.BookStore(126, 127, 128);

            //printing 
            Console.WriteLine("\n------------------------Secondary Representation---------------------");

            Console.WriteLine("BOOKS:\n");
            int bookListIndex = secondaryBookstore.Books;
            foreach (int bookIndex in (List<int>)libraryMap[bookListIndex]) {
                Representation2.Book book = (Representation2.Book)libraryMap[bookIndex];
                Console.Write($"{libraryMap[book.Title]} by Author(s):");

                int authorListIndex = book.Authors;
                foreach (int authorIndex in (List<int>)libraryMap[authorListIndex]) {
                    Representation2.Author author = (Representation2.Author)libraryMap[authorIndex];
                    Console.Write($" {libraryMap[author.Name]} {libraryMap[author.Surname]} {libraryMap[author.Nickaname]} born in {libraryMap[author.BirthYear]}");
                }  
                Console.WriteLine($" publication year: {libraryMap[book.Year]} page count: {libraryMap[book.PageCount]}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            int newspaperListIndex = secondaryBookstore.Newspapers;
            foreach (int newspaperIndex in (List<int>)libraryMap[newspaperListIndex]) {
                Representation2.NewsPaper newspaper = (Representation2.NewsPaper)libraryMap[newspaperIndex];
                Console.WriteLine($"{libraryMap[newspaper.Title]} publication year: {libraryMap[newspaper.Year]} page count: {libraryMap[newspaper.PageCount]}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            int boardGameListIndex = secondaryBookstore.BoardGames;
            foreach (int boardGameIndex in (List<int>)libraryMap[boardGameListIndex]) {
                Representation2.BoardGame boardGame = (Representation2.BoardGame)libraryMap[boardGameIndex];
                Console.Write($"{libraryMap[boardGame.Title]} min players: {libraryMap[boardGame.MinPlayer]} max players: {libraryMap[boardGame.MaxPlayer]} difficulty: {libraryMap[boardGame.Diffuculty]} by Author(s):");

                int authorListIndex = boardGame.Authors;
                foreach (int authorIndex in (List<int>)libraryMap[authorListIndex]) {
                    Representation2.Author author = (Representation2.Author)libraryMap[authorIndex];
                    Console.Write($" {libraryMap[author.Name]} {libraryMap[author.Surname]} {libraryMap[author.Nickaname]} born in {libraryMap[author.BirthYear]}");
                }
                Console.WriteLine();
            }

            #endregion

        }
    }
}
