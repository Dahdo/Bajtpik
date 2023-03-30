using System;
using System.Collections.Generic;

namespace Client {
    internal class Program {

        public static IDictionary<int, Object> bookStoreMap;

        public static void Main(string[] args) {

            #region MainRepresentation
            #region instantiation
            //Authors
            MainRepresentation.Author douglas = new MainRepresentation.Author("Douglas", "Adams", 1952);
            MainRepresentation.Author tom = new MainRepresentation.Author("Tom", "Wolfe", 1930);
            MainRepresentation.Author elmar = new MainRepresentation.Author("Elmar", "Eisemann", 1978);
            MainRepresentation.Author michael1 = new MainRepresentation.Author("Michael", "Schwarz", 1970);
            MainRepresentation.Author ulf = new MainRepresentation.Author("Ulf", "Assarsson", 1975);
            MainRepresentation.Author michael2 = new MainRepresentation.Author("Michael", "Wimmer", 1980);
            MainRepresentation.Author frank = new MainRepresentation.Author("Frank", "Herbert", 1920);
            MainRepresentation.Author terry = new MainRepresentation.Author("Terry", "Pratchett", 1948);
            MainRepresentation.Author neil = new MainRepresentation.Author("Neil", "Gaiman", 1960);
            MainRepresentation.Author jamey = new MainRepresentation.Author("Jamey", "Stegmaier", 1975);
            MainRepresentation.Author jakub = new MainRepresentation.Author("Jakub", "Różalski", 1981, "Mr. Werewolf");
            MainRepresentation.Author klaus = new MainRepresentation.Author("Klaus", "Teuber", 1952);
            MainRepresentation.Author alfred = new MainRepresentation.Author("Alfred", "Butts", 1899);
            MainRepresentation.Author james = new MainRepresentation.Author("James", "Brunot", 1902);
            MainRepresentation.Author christian = new MainRepresentation.Author("Christian T.", "Petersen", 1970);

            //BoardGames
            MainRepresentation.BoardGame scythe = new MainRepresentation.BoardGame("Scythe", 1, 5, 7, new List<MainRepresentation.Author>() { jamey, jakub });
            MainRepresentation.BoardGame catan = new MainRepresentation.BoardGame("Catan", 3, 4, 6, new List<MainRepresentation.Author>() { klaus });
            MainRepresentation.BoardGame scrabble = new MainRepresentation.BoardGame("Scrabble", 2, 4, 5, new List<MainRepresentation.Author>() { james, alfred });
            MainRepresentation.BoardGame twilightImperium = new MainRepresentation.BoardGame("Twilight Imperium", 3, 8, 9, new List<MainRepresentation.Author>() { christian });

            //Newspapers
            MainRepresentation.NewsPaper nwp1 = new MainRepresentation.NewsPaper("International Journal of Human-Computer Studies", 2023, 300);
            MainRepresentation.NewsPaper nwp2 = new MainRepresentation.NewsPaper("Nature", 1869, 200);
            MainRepresentation.NewsPaper nwp3 = new MainRepresentation.NewsPaper("National Geographic", 2001, 106);
            MainRepresentation.NewsPaper nwp4 = new MainRepresentation.NewsPaper("Pixel.", 2015, 115);

            //Books
            MainRepresentation.Book book1 = new MainRepresentation.Book("The Hitchhiker's Guide to the Galaxy", 1987, 320, new List<MainRepresentation.Author> { douglas });
            MainRepresentation.Book book2 = new MainRepresentation.Book("The Right Stuff", 1987, 512, new List<MainRepresentation.Author> { tom });
            MainRepresentation.Book book3 = new MainRepresentation.Book("Real-Time Shadows", 2011, 383, new List<MainRepresentation.Author> { elmar, michael1, ulf, michael2 });
            MainRepresentation.Book book4 = new MainRepresentation.Book("Mesjasz Diuny", 1972, 272, new List<MainRepresentation.Author> { frank });
            MainRepresentation.Book book5 = new MainRepresentation.Book("Dobry Omen", 1990, 416, new List<MainRepresentation.Author> { terry, neil });
            #endregion

            List<MainRepresentation.Book> bookList_m = new List<MainRepresentation.Book> { book1, book2, book3, book4, book5 };
            List<MainRepresentation.NewsPaper> newsPaperList_m = new List<MainRepresentation.NewsPaper> { nwp1, nwp2, nwp3, nwp4 };
            List<MainRepresentation.BoardGame> boardGameList_m = new List<MainRepresentation.BoardGame> { scythe, catan, scrabble, twilightImperium };

            //printing 
            Console.WriteLine("------------------------Main Representation---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (MainRepresentation.Book book in  bookList_m) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (MainRepresentation.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickaname} born in {author.BirthYear}");
                Console.WriteLine($" publication year: {book.Year} page count: {book.PageCount}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (MainRepresentation.NewsPaper newspaper in newsPaperList_m) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (MainRepresentation.BoardGame bgame in boardGameList_m) {
                Console.Write($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                foreach (MainRepresentation.Author author in bgame.Authors)
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
                {3, new Representation1.Author(0, 1, 2) },

                {4, "Tom" }, {5, "Wolfe" }, {6, 1930 },
                {7, new Representation1.Author(4, 5, 6) },

                {8, "Elmar" }, {9, "Eisemann" }, {10, 1978 },
                {11, new Representation1.Author(8, 9, 10) },

                {12, "Michael" }, {13, "Schwarz" }, {14, 1970 },
                {15, new Representation1.Author(12, 13, 14) },

                {16, "Ulf" }, {17, "Assarsson" }, {18, 1975 },
                {19, new Representation1.Author(16, 17, 18) },

                {20, "Michael" }, {21, "Wimmer" }, {22, 1980 },
                {23, new Representation1.Author(20, 21, 22) },

                {24, "Frank" }, {25, "Herbert" }, {26, 1920 },
                {27, new Representation1.Author(24, 25, 26) },

                {28, "Terry" }, {29, "Pratchett" }, {30, 1948 },
                {31, new Representation1.Author(28, 29, 30) },

                {32, "Neil" }, {33, "Gaiman" }, {34, 1960 },
                {35, new Representation1.Author(32, 33, 34) },

                {36, "Jamey" }, {37, "Stegmaier" }, {38, 1975 },
                {39, new Representation1.Author(36, 37, 38) },

                {40, "Jakub" }, {41, "Różalski" }, {42, 1981 }, {43, "Mr. Werewolf" },
                {44, new Representation1.Author(40, 41, 42, 43) },

                {45, "Klaus" }, {46, "Teuber" }, {47, 1952 },
                {48, new Representation1.Author(45, 46, 47) },

                {49, "Alfred" }, {50, "Butts" }, {51, 1899 },
                {52, new Representation1.Author(49, 5, 51) },

                {53, "James" }, {54, "Brunot" }, {55, 1902 },
                {56, new Representation1.Author(53, 54, 55) },

                {57, "Christian T." } , {58, "Petersen" }, {59, 1970 },
                {60, new Representation1.Author(57, 58, 59) },

                //BoardGames
                {61, "Scythe" }, {62, 1 } , {63, 5 }, {64, 7 }, {65, new List<int> {39, 44}},
                {66, new Representation1.BoardGame(61, 62, 63, 64, 65) },

                {67, "Catan" } , {68, 3 }, {69, 4 } , {70, 6 }, {71, new List<int>{48}},
                {72, new Representation1.BoardGame(67, 68, 69, 70, 71) },

                {73, "Scrabble" }, {74, 2 }, {75, 4 }, {76, 5 }, {77, new List<int>{56, 52}},
                {78, new Representation1.BoardGame(73, 74, 75, 76, 77) },

                {79, "Twilight Imperium" }, {80, 3 } , {81, 8 }, {82, 9 }, {83, new List<int> {60}},
                {84, new Representation1.BoardGame(79, 80, 81, 82, 83) },

                //Books
                {85, "The Hitchhiker's Guide to the Galaxy" }, {86, 1987 }, {87, 320 }, {88, new List<int>{3}},
                {89, new Representation1.Book(85, 86, 87, 88)},

                {90, "The Right Stuff" }, {91, 1987 }, {92, 512 }, {93, new List<int>{7}},
                {94, new Representation1.Book(90, 91, 92, 93) },

                {95, "Real-Time Shadows" }, {96, 2011 }, {97, 383} , {98, new List<int>{11, 15, 19, 23}},
                {99, new Representation1.Book(95, 96, 97, 98) },

                {100, "Mesjasz Diuny" }, {101, 1972 }, {102, 272 }, {103, new List<int> {27} },
                {104, new Representation1.Book(100, 101, 102, 103) },

                {105, "Dobry Omen" }, {106, 1990 }, {107, 416 }, {108, new List<int>{ 31, 35 }},
                {109, new Representation1.Book(105, 106, 107, 108) },

                //Newspapers
                {110, "International Journal of Human-Computer Studies" }, {111, 2023}, {112, 300 },
                {113, new Representation1.NewsPaper(110, 111, 112) },

                {114, "Nature" }, {115, 1869 }, {116, 200 },
                {117, new Representation1.NewsPaper(114, 115, 116) },

                {118, "National Geographic" }, {119, 2001 } , {120, 106 },
                {121, new Representation1.NewsPaper(118, 119, 120) },

                {122, "Pixel." } , {123, 2015 }, {124, 115 },
                {125, new Representation1.NewsPaper(122, 123, 124) }
            };

            #region withoutAdapter

            List<int> bookList_1 = new List<int> { 89, 94, 99, 104, 109 };
            List<int> newsPaperList_1 = new List<int> { 113, 117, 121, 125 };
            List<int> boardGameList_1 = new List<int> { 66, 72, 78, 84 };

            //printing 
            Console.WriteLine("\n------------------------Representation1 (without Adapter)---------------------");

            Console.WriteLine("BOOKS:\n");
            foreach (int bookIndex in bookList_1) {
                Representation1.Book book = (Representation1.Book)bookStoreMap[bookIndex];
                Console.Write($"{bookStoreMap[book.Title]} by Author(s):");

                int authorListIndex = book.Authors;
                foreach (int authorIndex in (List<int>)bookStoreMap[authorListIndex]) {
                    Representation1.Author author = (Representation1.Author)bookStoreMap[authorIndex];
                    Console.Write($" {bookStoreMap[author.Name]} {bookStoreMap[author.Surname]} {bookStoreMap[author.Nickaname]} born in {bookStoreMap[author.BirthYear]}");
                }  
                Console.WriteLine($" publication year: {bookStoreMap[book.Year]} page count: {bookStoreMap[book.PageCount]}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (int newspaperIndex in newsPaperList_1) {
                Representation1.NewsPaper newspaper = (Representation1.NewsPaper)bookStoreMap[newspaperIndex];
                Console.WriteLine($"{bookStoreMap[newspaper.Title]} publication year: {bookStoreMap[newspaper.Year]} page count: {bookStoreMap[newspaper.PageCount]}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (int boardGameIndex in boardGameList_1) {
                Representation1.BoardGame boardGame = (Representation1.BoardGame)bookStoreMap[boardGameIndex];
                Console.Write($"{bookStoreMap[boardGame.Title]} min players: {bookStoreMap[boardGame.MinPlayer]} max players: {bookStoreMap[boardGame.MaxPlayer]} difficulty: {bookStoreMap[boardGame.Diffuculty]} by Author(s):");

                int authorListIndex = boardGame.Authors;
                foreach (int authorIndex in (List<int>)bookStoreMap[authorListIndex]) {
                    Representation1.Author author = (Representation1.Author)bookStoreMap[authorIndex];
                    Console.Write($" {bookStoreMap[author.Name]} {bookStoreMap[author.Surname]} {bookStoreMap[author.Nickaname]} born in {bookStoreMap[author.BirthYear]}");
                }
                Console.WriteLine();
            }
            #endregion

            #region withAdapter

            //Books
            Interface1.Book book1_1a = new Adapter1.BookAdapter(new Representation1.Book(85, 86, 87, 88));
            Interface1.Book book2_1a = new Adapter1.BookAdapter(new Representation1.Book(90, 91, 92, 93));
            Interface1.Book book3_1a = new Adapter1.BookAdapter(new Representation1.Book(95, 96, 97, 98));
            Interface1.Book book4_1a = new Adapter1.BookAdapter(new Representation1.Book(100, 101, 102, 103));
            Interface1.Book book5_1a = new Adapter1.BookAdapter(new Representation1.Book(105, 106, 107, 108));

            //Newspapers
            Interface1.NewsPaper newsPaper1_1a = new Adapter1.NewsPaperAdapter(new Representation1.NewsPaper(110, 111, 112));
            Interface1.NewsPaper newsPaper2_1a = new Adapter1.NewsPaperAdapter(new Representation1.NewsPaper(114, 115, 116));
            Interface1.NewsPaper newsPaper3_1a = new Adapter1.NewsPaperAdapter(new Representation1.NewsPaper(118, 119, 120));
            Interface1.NewsPaper newsPaper4_1a = new Adapter1.NewsPaperAdapter(new Representation1.NewsPaper(122, 123, 124));

            //BoardGames
            Interface1.BoardGame boardGame1_1a = new Adapter1.BoardGameAdapter(new Representation1.BoardGame(61, 62, 63, 64, 65));
            Interface1.BoardGame boardGame2_1a = new Adapter1.BoardGameAdapter(new Representation1.BoardGame(67, 68, 69, 70, 71));
            Interface1.BoardGame boardGame3_1a = new Adapter1.BoardGameAdapter(new Representation1.BoardGame(73, 74, 75, 76, 77));
            Interface1.BoardGame boardGame4_1a = new Adapter1.BoardGameAdapter(new Representation1.BoardGame(79, 80, 81, 82, 83));

            List<Interface1.Book> bookList_1a = new List<Interface1.Book> { book1_1a, book2_1a, book3_1a, book4_1a, book5 };
            List<Interface1.NewsPaper> newsPaperList_1a = new List<Interface1.NewsPaper> { newsPaper1_1a, newsPaper2_1a, newsPaper3_1a, newsPaper4_1a };
            List<Interface1.BoardGame> boardGameList_1a = new List<Interface1.BoardGame> { boardGame1_1a, boardGame2_1a, boardGame3_1a, boardGame4_1a };


            //printing 
            Console.WriteLine("\n\n------------------------Representation1 (With Adapter) ---------------------");
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
