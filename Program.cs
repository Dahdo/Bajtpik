using System;
using System.Collections.Generic;

namespace Client {
    internal class Program {

        public static IDictionary<int, Object> bookStoreMap;

        public static void Main(string[] args) {

            #region MainRepresentation
            #region instantiation
            //Authors
            MainFormat.Author douglas = new MainFormat.Author("Douglas", "Adams", 1952);
            MainFormat.Author tom = new MainFormat.Author("Tom", "Wolfe", 1930);
            MainFormat.Author elmar = new MainFormat.Author("Elmar", "Eisemann", 1978);
            MainFormat.Author michael1 = new MainFormat.Author("Michael", "Schwarz", 1970);
            MainFormat.Author ulf = new MainFormat.Author("Ulf", "Assarsson", 1975);
            MainFormat.Author michael2 = new MainFormat.Author("Michael", "Wimmer", 1980);
            MainFormat.Author frank = new MainFormat.Author("Frank", "Herbert", 1920);
            MainFormat.Author terry = new MainFormat.Author("Terry", "Pratchett", 1948);
            MainFormat.Author neil = new MainFormat.Author("Neil", "Gaiman", 1960);
            MainFormat.Author jamey = new MainFormat.Author("Jamey", "Stegmaier", 1975);
            MainFormat.Author jakub = new MainFormat.Author("Jakub", "Różalski", 1981, "Mr. Werewolf");
            MainFormat.Author klaus = new MainFormat.Author("Klaus", "Teuber", 1952);
            MainFormat.Author alfred = new MainFormat.Author("Alfred", "Butts", 1899);
            MainFormat.Author james = new MainFormat.Author("James", "Brunot", 1902);
            MainFormat.Author christian = new MainFormat.Author("Christian T.", "Petersen", 1970);

            //BoardGames
            MainFormat.BoardGame scythe = new MainFormat.BoardGame("Scythe", 1, 5, 7, new List<MainFormat.Author>() { jamey, jakub });
            MainFormat.BoardGame catan = new MainFormat.BoardGame("Catan", 3, 4, 6, new List<MainFormat.Author>() { klaus });
            MainFormat.BoardGame scrabble = new MainFormat.BoardGame("Scrabble", 2, 4, 5, new List<MainFormat.Author>() { james, alfred });
            MainFormat.BoardGame twilightImperium = new MainFormat.BoardGame("Twilight Imperium", 3, 8, 9, new List<MainFormat.Author>() { christian });

            //Newspapers
            MainFormat.NewsPaper nwp1 = new MainFormat.NewsPaper("International Journal of Human-Computer Studies", 2023, 300);
            MainFormat.NewsPaper nwp2 = new MainFormat.NewsPaper("Nature", 1869, 200);
            MainFormat.NewsPaper nwp3 = new MainFormat.NewsPaper("National Geographic", 2001, 106);
            MainFormat.NewsPaper nwp4 = new MainFormat.NewsPaper("Pixel.", 2015, 115);

            //Books
            MainFormat.Book book1 = new MainFormat.Book("The Hitchhiker's Guide to the Galaxy", 1987, 320, new List<MainFormat.Author> { douglas });
            MainFormat.Book book2 = new MainFormat.Book("The Right Stuff", 1987, 512, new List<MainFormat.Author> { tom });
            MainFormat.Book book3 = new MainFormat.Book("Real-Time Shadows", 2011, 383, new List<MainFormat.Author> { elmar, michael1, ulf, michael2 });
            MainFormat.Book book4 = new MainFormat.Book("Mesjasz Diuny", 1972, 272, new List<MainFormat.Author> { frank });
            MainFormat.Book book5 = new MainFormat.Book("Dobry Omen", 1990, 416, new List<MainFormat.Author> { terry, neil });
            #endregion

            List<MainFormat.Book> bookList_m = new List<MainFormat.Book> { book1, book2, book3, book4, book5 };
            List<MainFormat.NewsPaper> newsPaperList_m = new List<MainFormat.NewsPaper> { nwp1, nwp2, nwp3, nwp4 };
            List<MainFormat.BoardGame> boardGameList_m = new List<MainFormat.BoardGame> { scythe, catan, scrabble, twilightImperium };

            //printing 
            Console.WriteLine("------------------------Main Representation---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (MainFormat.Book book in  bookList_m) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (MainFormat.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine($" publication year: {book.Year} page count: {book.PageCount}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (MainFormat.NewsPaper newspaper in newsPaperList_m) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (MainFormat.BoardGame bgame in boardGameList_m) {
                Console.Write($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                foreach (MainFormat.Author author in bgame.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine();
            }

            #endregion

            #region Representation1
            //instantiation
            bookStoreMap = new Dictionary<int, Object>()
            {
                {-1, null }, //for all nullable values ex: nickname
                //Authors
                {0, "Douglas"}, {1, "Adams"}, {2, 1952},
                {3, new SecondaryFormat.Author(0, 1, 2) },

                {4, "Tom" }, {5, "Wolfe" }, {6, 1930 },
                {7, new SecondaryFormat.Author(4, 5, 6) },

                {8, "Elmar" }, {9, "Eisemann" }, {10, 1978 },
                {11, new SecondaryFormat.Author(8, 9, 10) },

                {12, "Michael" }, {13, "Schwarz" }, {14, 1970 },
                {15, new SecondaryFormat.Author(12, 13, 14) },

                {16, "Ulf" }, {17, "Assarsson" }, {18, 1975 },
                {19, new SecondaryFormat.Author(16, 17, 18) },

                {20, "Michael" }, {21, "Wimmer" }, {22, 1980 },
                {23, new SecondaryFormat.Author(20, 21, 22) },

                {24, "Frank" }, {25, "Herbert" }, {26, 1920 },
                {27, new SecondaryFormat.Author(24, 25, 26) },

                {28, "Terry" }, {29, "Pratchett" }, {30, 1948 },
                {31, new SecondaryFormat.Author(28, 29, 30) },

                {32, "Neil" }, {33, "Gaiman" }, {34, 1960 },
                {35, new SecondaryFormat.Author(32, 33, 34) },

                {36, "Jamey" }, {37, "Stegmaier" }, {38, 1975 },
                {39, new SecondaryFormat.Author(36, 37, 38) },

                {40, "Jakub" }, {41, "Różalski" }, {42, 1981 }, {43, "Mr. Werewolf" },
                {44, new SecondaryFormat.Author(40, 41, 42, 43) },

                {45, "Klaus" }, {46, "Teuber" }, {47, 1952 },
                {48, new SecondaryFormat.Author(45, 46, 47) },

                {49, "Alfred" }, {50, "Butts" }, {51, 1899 },
                {52, new SecondaryFormat.Author(49, 5, 51) },

                {53, "James" }, {54, "Brunot" }, {55, 1902 },
                {56, new SecondaryFormat.Author(53, 54, 55) },

                {57, "Christian T." } , {58, "Petersen" }, {59, 1970 },
                {60, new SecondaryFormat.Author(57, 58, 59) },

                //BoardGames
                {61, "Scythe" }, {62, 1 } , {63, 5 }, {64, 7 }, {65, new List<int> {39, 44}},
                {66, new SecondaryFormat.BoardGame(61, 62, 63, 64, 65) },

                {67, "Catan" } , {68, 3 }, {69, 4 } , {70, 6 }, {71, new List<int>{48}},
                {72, new SecondaryFormat.BoardGame(67, 68, 69, 70, 71) },

                {73, "Scrabble" }, {74, 2 }, {75, 4 }, {76, 5 }, {77, new List<int>{56, 52}},
                {78, new SecondaryFormat.BoardGame(73, 74, 75, 76, 77) },

                {79, "Twilight Imperium" }, {80, 3 } , {81, 8 }, {82, 9 }, {83, new List<int> {60}},
                {84, new SecondaryFormat.BoardGame(79, 80, 81, 82, 83) },

                //Books
                {85, "The Hitchhiker's Guide to the Galaxy" }, {86, 1987 }, {87, 320 }, {88, new List<int>{3}},
                {89, new SecondaryFormat.Book(85, 86, 87, 88)},

                {90, "The Right Stuff" }, {91, 1987 }, {92, 512 }, {93, new List<int>{7}},
                {94, new SecondaryFormat.Book(90, 91, 92, 93) },

                {95, "Real-Time Shadows" }, {96, 2011 }, {97, 383} , {98, new List<int>{11, 15, 19, 23}},
                {99, new SecondaryFormat.Book(95, 96, 97, 98) },

                {100, "Mesjasz Diuny" }, {101, 1972 }, {102, 272 }, {103, new List<int> {27} },
                {104, new SecondaryFormat.Book(100, 101, 102, 103) },

                {105, "Dobry Omen" }, {106, 1990 }, {107, 416 }, {108, new List<int>{ 31, 35 }},
                {109, new SecondaryFormat.Book(105, 106, 107, 108) },

                //Newspapers
                {110, "International Journal of Human-Computer Studies" }, {111, 2023}, {112, 300 },
                {113, new SecondaryFormat.NewsPaper(110, 111, 112) },

                {114, "Nature" }, {115, 1869 }, {116, 200 },
                {117, new SecondaryFormat.NewsPaper(114, 115, 116) },

                {118, "National Geographic" }, {119, 2001 } , {120, 106 },
                {121, new SecondaryFormat.NewsPaper(118, 119, 120) },

                {122, "Pixel." } , {123, 2015 }, {124, 115 },
                {125, new SecondaryFormat.NewsPaper(122, 123, 124) }
            };

            #region withoutAdapter

            List<int> bookList_1 = new List<int> { 89, 94, 99, 104, 109 };
            List<int> newsPaperList_1 = new List<int> { 113, 117, 121, 125 };
            List<int> boardGameList_1 = new List<int> { 66, 72, 78, 84 };

            //printing 
            Console.WriteLine("\n------------------------SecondaryFormat (without Adapter)---------------------");

            Console.WriteLine("BOOKS:\n");
            foreach (int bookIndex in bookList_1) {
                SecondaryFormat.Book book = (SecondaryFormat.Book)bookStoreMap[bookIndex];
                Console.Write($"{bookStoreMap[book.Title]} by Author(s):");

                int authorListIndex = book.Authors;
                foreach (int authorIndex in (List<int>)bookStoreMap[authorListIndex]) {
                    SecondaryFormat.Author author = (SecondaryFormat.Author)bookStoreMap[authorIndex];
                    Console.Write($" {bookStoreMap[author.Name]} {bookStoreMap[author.Surname]} {bookStoreMap[author.Nickaname]} born in {bookStoreMap[author.BirthYear]}");
                }  
                Console.WriteLine($" publication year: {bookStoreMap[book.Year]} page count: {bookStoreMap[book.PageCount]}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (int newspaperIndex in newsPaperList_1) {
                SecondaryFormat.NewsPaper newspaper = (SecondaryFormat.NewsPaper)bookStoreMap[newspaperIndex];
                Console.WriteLine($"{bookStoreMap[newspaper.Title]} publication year: {bookStoreMap[newspaper.Year]} page count: {bookStoreMap[newspaper.PageCount]}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (int boardGameIndex in boardGameList_1) {
                SecondaryFormat.BoardGame boardGame = (SecondaryFormat.BoardGame)bookStoreMap[boardGameIndex];
                Console.Write($"{bookStoreMap[boardGame.Title]} min players: {bookStoreMap[boardGame.MinPlayer]} max players: {bookStoreMap[boardGame.MaxPlayer]} difficulty: {bookStoreMap[boardGame.Diffuculty]} by Author(s):");

                int authorListIndex = boardGame.Authors;
                foreach (int authorIndex in (List<int>)bookStoreMap[authorListIndex]) {
                    SecondaryFormat.Author author = (SecondaryFormat.Author)bookStoreMap[authorIndex];
                    Console.Write($" {bookStoreMap[author.Name]} {bookStoreMap[author.Surname]} {bookStoreMap[author.Nickaname]} born in {bookStoreMap[author.BirthYear]}");
                }
                Console.WriteLine();
            }
            #endregion

            #region withAdapter

            //Books
            Interface1.Book book1_1a = new Adapter1.BookAdapter(new SecondaryFormat.Book(85, 86, 87, 88));
            Interface1.Book book2_1a = new Adapter1.BookAdapter(new SecondaryFormat.Book(90, 91, 92, 93));
            Interface1.Book book3_1a = new Adapter1.BookAdapter(new SecondaryFormat.Book(95, 96, 97, 98));
            Interface1.Book book4_1a = new Adapter1.BookAdapter(new SecondaryFormat.Book(100, 101, 102, 103));
            Interface1.Book book5_1a = new Adapter1.BookAdapter(new SecondaryFormat.Book(105, 106, 107, 108));

            //Newspapers
            Interface1.NewsPaper newsPaper1_1a = new Adapter1.NewsPaperAdapter(new SecondaryFormat.NewsPaper(110, 111, 112));
            Interface1.NewsPaper newsPaper2_1a = new Adapter1.NewsPaperAdapter(new SecondaryFormat.NewsPaper(114, 115, 116));
            Interface1.NewsPaper newsPaper3_1a = new Adapter1.NewsPaperAdapter(new SecondaryFormat.NewsPaper(118, 119, 120));
            Interface1.NewsPaper newsPaper4_1a = new Adapter1.NewsPaperAdapter(new SecondaryFormat.NewsPaper(122, 123, 124));

            //BoardGames
            Interface1.BoardGame boardGame1_1a = new Adapter1.BoardGameAdapter(new SecondaryFormat.BoardGame(61, 62, 63, 64, 65));
            Interface1.BoardGame boardGame2_1a = new Adapter1.BoardGameAdapter(new SecondaryFormat.BoardGame(67, 68, 69, 70, 71));
            Interface1.BoardGame boardGame3_1a = new Adapter1.BoardGameAdapter(new SecondaryFormat.BoardGame(73, 74, 75, 76, 77));
            Interface1.BoardGame boardGame4_1a = new Adapter1.BoardGameAdapter(new SecondaryFormat.BoardGame(79, 80, 81, 82, 83));

            List<Interface1.Book> bookList_1a = new List<Interface1.Book> { book1_1a, book2_1a, book3_1a, book4_1a, book5 };
            List<Interface1.NewsPaper> newsPaperList_1a = new List<Interface1.NewsPaper> { newsPaper1_1a, newsPaper2_1a, newsPaper3_1a, newsPaper4_1a };
            List<Interface1.BoardGame> boardGameList_1a = new List<Interface1.BoardGame> { boardGame1_1a, boardGame2_1a, boardGame3_1a, boardGame4_1a };


            //printing 
            Console.WriteLine("\n\n------------------------SecondaryFormat (With Adapter) ---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (Interface1.Book book in bookList_1a) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (Interface1.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine($" publication year: {book.Year} page count: {book.PageCount}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (Interface1.NewsPaper newspaper in newsPaperList_1a) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (Interface1.BoardGame bgame in boardGameList_1a) {
                Console.Write($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                foreach (Interface1.Author author in bgame.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine();
            }
            #endregion

            #endregion
        }
    }
}
