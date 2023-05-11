//#define PRINTMAIN
//#define PRINTREP1
//#define PRINTREP4
//#define PRINTPROJ2
#define PRINTPROJ3

using Project1_Adapter;
using Project2_Collections;
using Project3_CollectionWrapper;
using Project3_Visitor;
using SecondaryFormat;
using System.Reflection;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace Client {
    internal class Program {
        //for secondary format + representation1
        public static Dictionary<int, string> stringMap;
        public static Dictionary<int, int> intMap;
        public static Dictionary<int, List<SecondaryFormat.Author>> authorListMap;


        //representation4
        public static Dictionary<int, string> stringHashMap;
        public static Dictionary<int, List<SecondaryFormat.Author>> authorListHashMap;

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

    #if PRINTMAIN
            //printing 
            Console.WriteLine("------------------------Main Representation---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (MainFormat.Book book in  bookList_m) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (MainFormat.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
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
                    Console.Write($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
                Console.WriteLine();
            }
    #endif

#endregion

#region Representation1
    #region instantiation
            stringMap = new Dictionary<int, string>() {
                //authors names & surnames
                {-1, "" }, //for all nullable values i.e nickname
                {0, "Douglas"}, {1, "Adams"}, {2, "Tom" }, {3, "Wolfe" }, {4, "Elmar" }, {5, "Eisemann" },
                {6, "Michael" }, {7, "Schwarz" }, {8, "Ulf" }, {9, "Assarsson" },  {10, "Michael" }, {11, "Wimmer" },
                {12, "Frank" }, {13, "Herbert" },  {14, "Terry" }, {15, "Pratchett" }, {16, "Neil" }, {17, "Gaiman" },
                {18, "Jamey" }, {19, "Stegmaier" }, {20, "Jakub" }, {21, "Różalski" }, {22, "Mr. Werewolf" },
                {23, "Klaus" }, {24, "Teuber" }, {25, "Alfred" }, {26, "Butts" },  {27, "James" }, {28, "Brunot" }, {29, "Christian T." } , {30, "Petersen" },

                //board games titles
                {31, "Scythe" }, {32, "Catan" }, {33, "Scrabble" }, {34, "Twilight Imperium" },

                //books titles
                {35, "The Hitchhiker's Guide to the Galaxy" }, {36, "The Right Stuff" }, {37, "Real-Time Shadows" },
                {38, "Mesjasz Diuny" }, {39, "Dobry Omen" },

                //news pager titles
                {40, "International Journal of Human-Computer Studies" }, {41, "Nature" },
                {42, "National Geographic" }, {43, "Pixel." }
            };

            intMap = new Dictionary<int, int>() {
                //authors birthdates
                {0, 1952}, {1, 1930 }, {2, 1978 }, {3, 1970 }, {4, 1975 }, {5, 1980 }, {6, 1920 },
                {7, 1948 }, {8, 1960 }, {9, 1975 }, {10, 1981 }, {11, 1952 }, {12, 1899 }, {13, 1902 }, {14, 1970 },

                //Board games paramets
                {15, 1 } , {16, 5 }, {17, 7 }, {18, 3 }, {19, 4 } , {20, 6 }, {21, 2 }, {22, 4 }, {23, 5 },
                {24, 3 } , {25, 8 }, {26, 9 }, 

                //books years and page counts
                {27, 1987 }, {28, 320 }, {29, 1987 }, {30, 512 }, {31, 2011 }, {32, 383}, 
                {33, 1972 }, {34, 272 }, {35, 1990 }, {36, 416 }, 

                //news papers' year and page count
                 {37, 2023}, {38, 300 }, {39, 1869 }, {40, 200 },  {41, 2001 } , {42, 106 }, 
                 {43, 2015 }, {44, 115 }
            };

            //Authors
            SecondaryFormat.Author douglas_s = new SecondaryFormat.Author(0, 1, 0);
            SecondaryFormat.Author tom_s = new SecondaryFormat.Author(2, 3, 1);
            SecondaryFormat.Author elmar_s = new SecondaryFormat.Author(4, 5, 2);
            SecondaryFormat.Author michael1_s = new SecondaryFormat.Author(6, 7, 3);
            SecondaryFormat.Author ulf_s = new SecondaryFormat.Author(8, 9, 4);
            SecondaryFormat.Author michael2_s = new SecondaryFormat.Author(10, 11, 5);
            SecondaryFormat.Author frank_s = new SecondaryFormat.Author(12, 13, 6);
            SecondaryFormat.Author terry_s = new SecondaryFormat.Author(14, 15, 7);
            SecondaryFormat.Author neil_s = new SecondaryFormat.Author(16, 17, 8);
            SecondaryFormat.Author jamey_s = new SecondaryFormat.Author(18, 19, 9);
            SecondaryFormat.Author jakub_s = new SecondaryFormat.Author(20, 21, 10, 22);
            SecondaryFormat.Author klaus_s = new SecondaryFormat.Author(23, 24, 11);
            SecondaryFormat.Author alfred_s = new SecondaryFormat.Author(25, 26, 12);
            SecondaryFormat.Author james_s = new SecondaryFormat.Author(27, 28, 13);
            SecondaryFormat.Author christian_s = new SecondaryFormat.Author(29, 30, 14);

            authorListMap = new Dictionary<int, List<SecondaryFormat.Author>>() {
                //Board game authors lists
                {0, new List<SecondaryFormat.Author>(){jamey_s, jakub_s} }, {1, new List<SecondaryFormat.Author>(){klaus_s} },
                {2, new List<SecondaryFormat.Author>(){james_s, alfred_s} }, {3, new List<SecondaryFormat.Author>(){christian_s} },
                //books author list
                {4, new List<SecondaryFormat.Author>(){douglas_s} }, {5, new List<SecondaryFormat.Author>(){tom_s} },
                {6, new List<SecondaryFormat.Author>(){elmar_s, michael1_s, ulf_s, michael2_s} },
                {7, new List<SecondaryFormat.Author>(){frank_s} }, {8, new List<SecondaryFormat.Author>(){terry_s, neil_s} }

            };

            //Books
            SecondaryFormat.Book book1_s = new SecondaryFormat.Book(35, 27, 28, 4);
            SecondaryFormat.Book book2_s = new SecondaryFormat.Book(36, 29, 30, 5);
            SecondaryFormat.Book book3_s = new SecondaryFormat.Book(37, 31, 32, 6);
            SecondaryFormat.Book book4_s = new SecondaryFormat.Book(38, 33, 34, 7);
            SecondaryFormat.Book book5_s = new SecondaryFormat.Book(39, 35, 36, 8);

            //BoardGames
            SecondaryFormat.BoardGame boardGame1_s = new SecondaryFormat.BoardGame(31, 15, 16, 17, 0);
            SecondaryFormat.BoardGame boardGame2_s = new SecondaryFormat.BoardGame(32, 18, 19, 20, 1);
            SecondaryFormat.BoardGame boardGame3_s = new SecondaryFormat.BoardGame(33, 21, 22, 23, 2);
            SecondaryFormat.BoardGame boardGame4_s = new SecondaryFormat.BoardGame(34, 24, 25, 26, 3);

            //Newspapers
            SecondaryFormat.NewsPaper nwp1_s = new SecondaryFormat.NewsPaper(40, 37, 38);
            SecondaryFormat.NewsPaper nwp2_s = new SecondaryFormat.NewsPaper(41, 39, 40);
            SecondaryFormat.NewsPaper nwp3_s = new SecondaryFormat.NewsPaper(42, 41, 42);
            SecondaryFormat.NewsPaper nwp4_s = new SecondaryFormat.NewsPaper(43, 43, 44);
    #endregion
    #region withoutAdapter

            List<SecondaryFormat.Book> bookList_1 = new List<SecondaryFormat.Book> { book1_s, book2_s, book3_s, book4_s, book5_s};
            List<SecondaryFormat.NewsPaper> newsPaperList_1 = new List<SecondaryFormat.NewsPaper> { nwp1_s, nwp2_s, nwp3_s, nwp4_s };
            List<SecondaryFormat.BoardGame> boardGameList_1 = new List<SecondaryFormat.BoardGame> {boardGame1_s, boardGame2_s, boardGame3_s, boardGame4_s };

    #if PRINTREP1
            //printing 
            Console.WriteLine("\n------------------------Representation 1 (without Adapter)---------------------");

            Console.WriteLine("BOOKS:\n");
            foreach (SecondaryFormat.Book book in bookList_1) {
                Console.Write($"{stringMap[book.Title]} by Author(s):");

                foreach (SecondaryFormat.Author author in authorListMap[book.Authors]) {
                    Console.Write($" {stringMap[author.Name]} {stringMap[author.Surname]} {stringMap[author.Nickname]} born in {intMap[author.BirthYear]}");
                }
                Console.WriteLine($" publication year: {intMap[book.Year]} page count: {intMap[book.PageCount]}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (SecondaryFormat.NewsPaper newsPaper in newsPaperList_1) {
                Console.WriteLine($"{stringMap[newsPaper.Title]} publication year: {intMap[newsPaper.Year]} page count: {intMap[newsPaper.PageCount]}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (SecondaryFormat.BoardGame boardGame in boardGameList_1) {
                Console.Write($"{stringMap[boardGame.Title]} min players: {intMap[boardGame.MinPlayer]} max players: {intMap[boardGame.MaxPlayer]} difficulty: {intMap[boardGame.Diffuculty]} by Author(s):");

                foreach (SecondaryFormat.Author author in authorListMap[boardGame.Authors]) {
                    Console.Write($" {stringMap[author.Name]} {stringMap[author.Surname]} {stringMap[author.Nickname]} born in {intMap[author.BirthYear]}");
                }
                Console.WriteLine();
            }
    #endif
    #endregion

    #region withAdapter

            //Books
            Project1_Adapter.Book book1_1a = new Project1_Adapter.BookAdapter(book1_s, 1);
            Project1_Adapter.Book book2_1a = new Project1_Adapter.BookAdapter(book2_s, 1);
            Project1_Adapter.Book book3_1a = new Project1_Adapter.BookAdapter(book3_s, 1);
            Project1_Adapter.Book book4_1a = new Project1_Adapter.BookAdapter(book4_s, 1);
            Project1_Adapter.Book book5_1a = new Project1_Adapter.BookAdapter(book5_s, 1);

            //Newspapers
            Project1_Adapter.NewsPaper nwp1_1a = new Project1_Adapter.NewsPaperAdapter(nwp1_s, 1);
            Project1_Adapter.NewsPaper nwp2_1a = new Project1_Adapter.NewsPaperAdapter(nwp2_s, 1);
            Project1_Adapter.NewsPaper nwp3_1a = new Project1_Adapter.NewsPaperAdapter(nwp3_s, 1);
            Project1_Adapter.NewsPaper nwp4_1a = new Project1_Adapter.NewsPaperAdapter(nwp4_s, 1);

            //BoardGames
            Project1_Adapter.BoardGame boardGame1_1a = new Project1_Adapter.BoardGameAdapter(boardGame1_s, 1);
            Project1_Adapter.BoardGame boardGame2_1a = new Project1_Adapter.BoardGameAdapter(boardGame2_s, 1);
            Project1_Adapter.BoardGame boardGame3_1a = new Project1_Adapter.BoardGameAdapter(boardGame3_s, 1);
            Project1_Adapter.BoardGame boardGame4_1a = new Project1_Adapter.BoardGameAdapter(boardGame4_s, 1);

            List<Project1_Adapter.Book> bookList_1a = new List<Project1_Adapter.Book> { book1_1a, book2_1a, book3_1a, book4_1a, book5_1a };
            List<Project1_Adapter.NewsPaper> newsPaperList_1a = new List<Project1_Adapter.NewsPaper> { nwp1_1a, nwp2_1a, nwp3_1a, nwp4_1a };
            List<Project1_Adapter.BoardGame> boardGameList_1a = new List<Project1_Adapter.BoardGame> { boardGame1_1a, boardGame2_1a, boardGame3_1a, boardGame4_1a };

    #if PRINTREP1
            //printing 
            Console.WriteLine("\n\n------------------------Representation 1 (With Adapter) ---------------------");
            Console.WriteLine("BOOKS:\n");
            foreach (Project1_Adapter.Book book in bookList_1a) {
                Console.Write($"{book.Title} by Author(s):");
                foreach (Project1_Adapter.Author author in book.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
                Console.WriteLine($" publication year: {book.Year} page count: {book.PageCount}");
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (Project1_Adapter.NewsPaper newspaper in newsPaperList_1a) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES:\n");
            foreach (Project1_Adapter.BoardGame bgame in boardGameList_1a) {
                Console.Write($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                foreach (Project1_Adapter.Author author in bgame.Authors)
                    Console.Write($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
                Console.WriteLine();
            }
    #endif
    #endregion

#endregion

#region Representation4
            Dictionary<int, int> keys = new Dictionary<int, int>();
            stringHashMap = new Dictionary<int, string>();
            for(int i = 0; i < stringMap.Count - 1; i++) {
                int generatedHash = generatedHash = stringMap[i].GetHashCode();

                if (stringHashMap.ContainsKey(generatedHash)) {
                    while (stringHashMap.ContainsKey(generatedHash)) {
                        Random rnd = new Random();
                        int num = rnd.Next();

                        string str = stringMap[i] + num;
                        generatedHash = generatedHash = str.GetHashCode();
                    }
                } 
                stringHashMap.Add(generatedHash, stringMap[i]);
                keys.Add(i, generatedHash);
            }
            stringHashMap.Add(-1, stringMap[-1]);
            keys.Add(-1, -1);

            //Authors
            SecondaryFormat.Author douglas_s4 = new SecondaryFormat.Author(keys[0], keys[1], 0);
            SecondaryFormat.Author tom_s4 = new SecondaryFormat.Author(keys[2], keys[3], 1);
            SecondaryFormat.Author elmar_s4 = new SecondaryFormat.Author(keys[4], keys[5], 2);
            SecondaryFormat.Author michael1_s4 = new SecondaryFormat.Author(keys[6], keys[7], 3);
            SecondaryFormat.Author ulf_s4 = new SecondaryFormat.Author(keys[8], keys[9], 4);
            SecondaryFormat.Author michael2_s4 = new SecondaryFormat.Author(keys[10], keys[11], 5);
            SecondaryFormat.Author frank_s4 = new SecondaryFormat.Author(keys[12], keys[13], 6);
            SecondaryFormat.Author terry_s4 = new SecondaryFormat.Author(keys[14], keys[15], 7);
            SecondaryFormat.Author neil_s4 = new SecondaryFormat.Author(keys[16], keys[17], 8);
            SecondaryFormat.Author jamey_s4 = new SecondaryFormat.Author(keys[18], keys[19], 9);
            SecondaryFormat.Author jakub_s4 = new SecondaryFormat.Author(keys[20], keys[21], 10, keys[22]);
            SecondaryFormat.Author klaus_s4 = new SecondaryFormat.Author(keys[23], keys[24], 11);
            SecondaryFormat.Author alfred_s4 = new SecondaryFormat.Author(keys[25], keys[26], 12);
            SecondaryFormat.Author james_s4 = new SecondaryFormat.Author(keys[27], keys[28], 13);
            SecondaryFormat.Author christian_s4 = new SecondaryFormat.Author(keys[29], keys[30], 14);

            authorListHashMap = new Dictionary<int, List<SecondaryFormat.Author>>() {
                //Board game authors lists
                {0, new List<SecondaryFormat.Author>(){jamey_s4, jakub_s4} }, {1, new List<SecondaryFormat.Author>(){klaus_s4} },
                {2, new List<SecondaryFormat.Author>(){james_s4, alfred_s4} }, {3, new List<SecondaryFormat.Author>(){christian_s4} },
                //books author list
                {4, new List<SecondaryFormat.Author>(){douglas_s4} }, {5, new List<SecondaryFormat.Author>(){tom_s4} },
                {6, new List<SecondaryFormat.Author>(){elmar_s4, michael1_s4, ulf_s4, michael2_s4} },
                {7, new List<SecondaryFormat.Author>(){frank_s4} }, {8, new List<SecondaryFormat.Author>(){terry_s4, neil_s4} }

            };

            //Books
            SecondaryFormat.Book book1_s4 = new SecondaryFormat.Book(keys[35], 27, 28, 4);
            SecondaryFormat.Book book2_s4 = new SecondaryFormat.Book(keys[36], 29, 30, 5);
            SecondaryFormat.Book book3_s4 = new SecondaryFormat.Book(keys[37], 31, 32, 6);
            SecondaryFormat.Book book4_s4 = new SecondaryFormat.Book(keys[38], 33, 34, 7);
            SecondaryFormat.Book book5_s4 = new SecondaryFormat.Book(keys[39], 35, 36, 8);

            //BoardGames
            SecondaryFormat.BoardGame boardGame1_s4 = new SecondaryFormat.BoardGame(keys[31], 15, 16, 17, 0);
            SecondaryFormat.BoardGame boardGame2_s4 = new SecondaryFormat.BoardGame(keys[32], 18, 19, 20, 1);
            SecondaryFormat.BoardGame boardGame3_s4 = new SecondaryFormat.BoardGame(keys[33], 21, 22, 23, 2);
            SecondaryFormat.BoardGame boardGame4_s4 = new SecondaryFormat.BoardGame(keys[34], 24, 25, 26, 3);

            //Newspapers
            SecondaryFormat.NewsPaper nwp1_s4 = new SecondaryFormat.NewsPaper(keys[40], 37, 38);
            SecondaryFormat.NewsPaper nwp2_s4 = new SecondaryFormat.NewsPaper(keys[41], 39, 40);
            SecondaryFormat.NewsPaper nwp3_s4 = new SecondaryFormat.NewsPaper(keys[42], 41, 42);
            SecondaryFormat.NewsPaper nwp4_s4 = new SecondaryFormat.NewsPaper(keys[43], 43, 44);

            //Books
            Project1_Adapter.Book book1_4a = new Project1_Adapter.BookAdapter(book1_s4, 4);
            Project1_Adapter.Book book2_4a = new Project1_Adapter.BookAdapter(book2_s4, 4);
            Project1_Adapter.Book book3_4a = new Project1_Adapter.BookAdapter(book3_s4, 4);
            Project1_Adapter.Book book4_4a = new Project1_Adapter.BookAdapter(book4_s4, 4);
            Project1_Adapter.Book book5_4a = new Project1_Adapter.BookAdapter(book5_s4, 4);

            //Newspapers
            Project1_Adapter.NewsPaper nwp1_4a = new Project1_Adapter.NewsPaperAdapter(nwp1_s4, 4);
            Project1_Adapter.NewsPaper nwp2_4a = new Project1_Adapter.NewsPaperAdapter(nwp2_s4, 4);
            Project1_Adapter.NewsPaper nwp3_4a = new Project1_Adapter.NewsPaperAdapter(nwp3_s4, 4);
            Project1_Adapter.NewsPaper nwp4_4a = new Project1_Adapter.NewsPaperAdapter(nwp4_s4, 4);

            //BoardGames
            Project1_Adapter.BoardGame boardGame1_4a = new Project1_Adapter.BoardGameAdapter(boardGame1_s4, 4);
            Project1_Adapter.BoardGame boardGame2_4a = new Project1_Adapter.BoardGameAdapter(boardGame2_s4, 4);
            Project1_Adapter.BoardGame boardGame3_4a = new Project1_Adapter.BoardGameAdapter(boardGame3_s4, 4);
            Project1_Adapter.BoardGame boardGame4_4a = new Project1_Adapter.BoardGameAdapter(boardGame4_s4, 4);

            List<Project1_Adapter.Book> bookList_4a = new List<Project1_Adapter.Book> { book1_4a, book2_4a, book3_4a, book4_4a, book5_4a };
            List<Project1_Adapter.NewsPaper> newsPaperList_4a = new List<Project1_Adapter.NewsPaper> { nwp1_4a, nwp2_4a, nwp3_4a, nwp4_4a };
            List<Project1_Adapter.BoardGame> boardGameList_4a = new List<Project1_Adapter.BoardGame> { boardGame1_4a, boardGame2_4a, boardGame3_4a, boardGame4_4a };

#if PRINTREP4
            //printing 
            Console.WriteLine("\n\n------------------------Representation 4 (With Adapter) ---------------------");
            Console.WriteLine("BOOKS [with atleast one author born after 1970]:\n");
            foreach (Project1_Adapter.Book book in bookList_4a) {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"{book.Title} by Author(s):");
                bool bornAfter1970 = false;
                foreach (Project1_Adapter.Author author in book.Authors) {
                    if (author.BirthYear > 1970) {
                        bornAfter1970 = true;
                        stringBuilder.Append($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
                    }
                }
                if (bornAfter1970) {
                    stringBuilder.Append($" publication year: {book.Year} page count: {book.PageCount}");
                    Console.WriteLine(stringBuilder);
                }
            }

            Console.WriteLine("\nNEWSPAPERS:\n");
            foreach (Project1_Adapter.NewsPaper newspaper in newsPaperList_4a) {
                Console.WriteLine($"{newspaper.Title} publication year: {newspaper.Year} page count: {newspaper.PageCount}");
            }

            Console.WriteLine("\nBOARD GAMES [with atleast one author born after 1970]:\n");
            foreach (Project1_Adapter.BoardGame bgame in boardGameList_4a) {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"{bgame.Title} min players: {bgame.MinPlayer} max players: {bgame.MaxPlayer} difficulty: {bgame.Diffuculty} by Author(s):");
                bool bornAfter1970 = false;
                foreach (Project1_Adapter.Author author in bgame.Authors) {
                    if(author.BirthYear > 1970) {
                        bornAfter1970 = true;
                        stringBuilder.Append($" {author.Name} {author.Surname} {author.Nickname} born in {author.BirthYear}");
                    }
                }
                if(bornAfter1970) {
                    stringBuilder.Append("\n");
                    Console.WriteLine(stringBuilder);                    
                }
            }
#endif

            #endregion

#region Project2_0

            Project2_Collections.Vector<Project1_Adapter.Book> bookVector = new Project2_Collections.Vector<Project1_Adapter.Book>();
            bookVector.Add(book1_4a);
            bookVector.Add(book2_4a);
            bookVector.Add(book1_1a);
            bookVector.Remove(book1_4a);

            Project2_Collections.DoublelyLinkedList<Project1_Adapter.NewsPaper> nwpList
                = new Project2_Collections.DoublelyLinkedList<Project1_Adapter.NewsPaper>();
            nwpList.Add(nwp1_4a);
            nwpList.Add(nwp2_4a);
            nwpList.Add(nwp3_4a);
            nwpList.Add(nwp4_4a);
            nwpList.Remove(nwp4_4a);

            //forward iterator
#if PRINTPROJ2
            Project2_Iterators.ForwardIterator<Project1_Adapter.NewsPaper>? fit =
                nwpList.GetForwardIterator();
            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{fit.Current()?.Title} publication year: {fit.Current()?.Year} page count: {fit.Current()?.PageCount}");
            for (int i = 0; i < 100; i++) {
                if (fit.Move()) {
                    Console.WriteLine($"{fit.Current()?.Title} publication year: {fit.Current()?.Year} page count: {fit.Current()?.PageCount}");
                }
            }
#endif

            //Reverse iterator
#if PRINTPROJ2
            Console.WriteLine("---Reverse mode----");
            Project2_Iterators.ReverseIterator<Project1_Adapter.NewsPaper>? rit =
                nwpList.GetReverseIterator();
            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{rit.Current()?.Title} publication year: {rit.Current()?.Year} page count: {rit.Current()?.PageCount}");
            for (int i = 0; i < 100; i++) {
                if (rit.Move()) {
                    Console.WriteLine($"{rit.Current()?.Title} publication year: {rit.Current()?.Year}  page count:  {rit.Current()?.PageCount}");
                }
            }

            Console.WriteLine("-----------------");
            Project2_Collections.Vector<Project1_Adapter.NewsPaper> nwpVector
                = new Project2_Collections.Vector<Project1_Adapter.NewsPaper>();
            nwpVector.Add(nwp1_4a);
            nwpVector.Add(nwp2_4a);
            nwpVector.Add(nwp3_4a);
            nwpVector.Add(nwp4_4a);
            nwpVector.Remove(nwp4_4a);
            Console.WriteLine($"the size: {nwpVector.Size()}");

            Project2_Iterators.ForwardIterator<Project1_Adapter.NewsPaper>? fit2 =
                nwpVector.GetForwardIterator();

            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{fit2.Current()?.Title}  publication year:  {fit2.Current()?.Year}  page count:  {fit2.Current()?.PageCount}");

            for (int i = 0; i < 100; i++) {
                if (fit2.Move()) {
                    //Console.WriteLine("\nNEWSPAPERS:\n");
                    Console.WriteLine($"{fit2.Current()?.Title} publication year: {fit.Current()?.Year} page count: {fit2.Current()?.PageCount}");
                }
            }

            Console.WriteLine("---Reverse mode----");
            Project2_Iterators.ReverseIterator<Project1_Adapter.NewsPaper>? rit2 =
                nwpVector.GetReverseIterator();
            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{rit2.Current()?.Title} publication year: {rit2.Current()?.Year} page count: {rit2.Current()?.PageCount}");
            for (int i = 0; i < 100; i++) {
                if (rit2.Move()) {
                    Console.WriteLine($"{rit2.Current()?.Title} publication year: {rit2.Current()?.Year} page count: {rit2.Current()?.PageCount}");
                }
            }

            //------Heap

            Project2_Collections.Heap<Project1_Adapter.NewsPaper> nwpHeap
                = new Project2_Collections.Heap<Project1_Adapter.NewsPaper>((a, b) => a.PageCount < b.PageCount);
            nwpHeap.Add(nwp1_4a);
            nwpHeap.Add(nwp2_4a);
            nwpHeap.Add(nwp3_4a);
            nwpHeap.Add(nwp4_4a);
            nwpHeap.Remove();
            Console.WriteLine($"the size: {nwpHeap.Size()}");

            Project2_Iterators.ForwardIterator<Project1_Adapter.NewsPaper>? fithp2 =
                nwpHeap.GetForwardIterator();

            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{fit2.Current()?.Title} publication year: {fit2.Current()?.Year} page count: {fit2.Current()?.PageCount}");

            for (int i = 0; i < 100; i++) {
                if (fit2.Move()) {
                    //Console.WriteLine("\nNEWSPAPERS:\n");
                    Console.WriteLine($"{fit2.Current()?.Title} publication year: {fit2.Current()?.Year} page count: {fit2.Current()?.PageCount}");
                }
            }

            Console.WriteLine("---Reverse mode----");
            Project2_Iterators.ReverseIterator<Project1_Adapter.NewsPaper>? rithp2 =
                nwpHeap.GetReverseIterator();
            Console.WriteLine("\nNEWSPAPERS:\n");
            Console.WriteLine($"{rit2.Current()?.Title} publication year: {rit2.Current()?.Year} page count: {rit2.Current()?.PageCount}");
            for (int i = 0; i < 100; i++) {
                if (rit2.Move()) {
                    Console.WriteLine($"{rit2.Current()?.Title} publication year: {rit2.Current()?.Year}  page count:  {rit2.Current()?.PageCount}");
                }
            }

            Console.WriteLine("----Algorithms----");
            Project2_Iterators.ForwardIterator<Project1_Adapter.NewsPaper> ffit =
                nwpVector.GetForwardIterator();

            Action<Project1_Adapter.NewsPaper> myAction = (T) => {
                Console.WriteLine(T.ToString());
            };
            Console.WriteLine("Foreach with print predicate, MyAction");
            Project2_Algorithms.Algorithms<Project1_Adapter.NewsPaper>.ForEach(ffit, myAction);
            Project2_Algorithms.Algorithms<Project1_Adapter.Book>.Print(bookVector, (T) => T.Year < 2030, false);

#endif

            #endregion

#region Project_3
            #region someAuthors
            //some Authors objects. (adapted seconary representation)
            Project1_Adapter.Author jamey_s_1a = new Project1_Adapter.AuthorAdapter(jamey_s, 1);
            Project1_Adapter.Author jakub_s_1a = new Project1_Adapter.AuthorAdapter(jakub_s, 1);
            Project1_Adapter.Author klaus_s_1a = new Project1_Adapter.AuthorAdapter(klaus_s, 1);
            Project1_Adapter.Author alfred_s_1a = new Project1_Adapter.AuthorAdapter(alfred_s, 1);
            Project1_Adapter.Author james_s_1a = new Project1_Adapter.AuthorAdapter(james_s, 1);
            Project1_Adapter.Author christian_s_1a = new Project1_Adapter.AuthorAdapter(christian_s, 1);
            #endregion

            //creating collections of objects of different representations.
            Project2_Collections.DoublelyLinkedList<Project1_Adapter.Author> authorLinkedlist_proj2 =
                new Project2_Collections.DoublelyLinkedList<Project1_Adapter.Author>();
            
            //base representation
            authorLinkedlist_proj2.Add(douglas);
            authorLinkedlist_proj2.Add(tom);
            authorLinkedlist_proj2.Add(elmar);
            authorLinkedlist_proj2.Add(michael1);
            authorLinkedlist_proj2.Add(ulf);
            authorLinkedlist_proj2.Add(michael2);
            authorLinkedlist_proj2.Add(frank);
            authorLinkedlist_proj2.Add(terry);
            authorLinkedlist_proj2.Add(neil);
            //secondary representation (adapted)
            authorLinkedlist_proj2.Add(james_s_1a);
            authorLinkedlist_proj2.Add(jakub_s_1a);
            authorLinkedlist_proj2.Add(klaus_s_1a);
            authorLinkedlist_proj2.Add(alfred_s_1a);
            authorLinkedlist_proj2.Add(james_s_1a);
            authorLinkedlist_proj2.Add(christian_s_1a);

            //Project2_Iterators.ForwardIterator<Project1_Adapter.Author> authorFit =
            //    authorLinkedlist_proj2.GetForwardIterator();

           Project2_Collections.Vector<Project1_Adapter.Book> bookVector_proj2 =
                new Project2_Collections.Vector<Project1_Adapter.Book>();
                    //secondary representation (adapted)
                bookVector_proj2.Add(book1_1a);
                bookVector_proj2.Add(book2_1a);
                bookVector_proj2.Add(book3_1a);
                    //base representation
                bookVector_proj2.Add(book4);
                bookVector_proj2.Add(book5);

            //Project2_Iterators.ForwardIterator<Project1_Adapter.Book> bookFit =
            //    bookVector_proj2.GetForwardIterator();

            Project2_Collections.Heap<Project1_Adapter.BoardGame> bGameHeap_proj2 =
                new Project2_Collections.Heap<Project1_Adapter.BoardGame>((a, b) => a.MaxPlayer < b.MaxPlayer);
                    //secondary representation (adapted)
                 bGameHeap_proj2.Add(boardGame1_4a);
                 bGameHeap_proj2.Add(boardGame2_4a);
                    //base representation
                 bGameHeap_proj2.Add(scrabble);
                 bGameHeap_proj2.Add(twilightImperium);

            //Project2_Iterators.ForwardIterator<Project1_Adapter.BoardGame> bGameFit =
            //    bGameHeap_proj2.GetForwardIterator();


            Project2_Collections.DoublelyLinkedList<Project1_Adapter.NewsPaper> nwpLinkedList_proj2 = 
                new Project2_Collections.DoublelyLinkedList<Project1_Adapter.NewsPaper>();
                    //secondary representation(adapted)
                nwpLinkedList_proj2.Add(nwp1_1a);
                nwpLinkedList_proj2.Add(nwp2_1a);
                    //base representation
                nwpLinkedList_proj2.Add(nwp3);
                nwpLinkedList_proj2.Add(nwp4);


            //Project2_Iterators.ForwardIterator<Project1_Adapter.NewsPaper> nwpFit =
            //    nwpLinkedList_proj2.GetForwardIterator();

            //Action<Project1_Adapter.Book> bookPrintAction = (T) => {
            //    Console.WriteLine(T.ToString());
            //};

            //Action<Project1_Adapter.NewsPaper> nwpPrintAction = (T) => {
            //    Console.WriteLine(T.ToString());
            //};

            //Action<Project1_Adapter.BoardGame> bGamePrintAction = (T) => {
            //    Console.WriteLine(T.ToString());
            //};

            //Action<Project1_Adapter.Author> authorPrintAction = (T) => {
            //    Console.WriteLine(T.ToString());
            //};

            //Console.WriteLine("\nAuthors\n--------------------------");
            //Project2_Algorithms.Algorithms<Project1_Adapter.Author>.ForEach(authorFit, authorPrintAction);
            //Console.WriteLine("\nBook\n--------------------------");
            //Project2_Algorithms.Algorithms<Project1_Adapter.Book>.ForEach(bookFit, bookPrintAction);
            //Console.WriteLine("\nNews paper\n--------------------------");
            //Project2_Algorithms.Algorithms<Project1_Adapter.NewsPaper>.ForEach(nwpFit, nwpPrintAction);
            //Console.WriteLine("\nBoard game\n--------------------------");
            //Project2_Algorithms.Algorithms<Project1_Adapter.BoardGame>.ForEach(bGameFit, bGamePrintAction);

            Dictionary<String, CollectionWrapper> collectionsDictionary = new Dictionary<string, CollectionWrapper>();
            collectionsDictionary.Add("book", bookVector_proj2);
            collectionsDictionary.Add("newspaper", nwpLinkedList_proj2);
            collectionsDictionary.Add("boardgame", bGameHeap_proj2);
            collectionsDictionary.Add("author", authorLinkedlist_proj2);


            Dictionary<String, Visitor> commandsDictionary = new Dictionary<String, Visitor>();
            commandsDictionary.Add("list", new ListVisitor());
            commandsDictionary.Add("find", new FindVisitor());
            commandsDictionary.Add("add", new AddVisitor());

            string? input = Console.ReadLine();
            while (!String.Equals(input, "exit", StringComparison.OrdinalIgnoreCase)) {
                List<String> inputList = ParseInput(input);
                if (inputList.Count == 1)
                    if (!String.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                        Console.WriteLine("Command not supported!");
                if (inputList.Count >= 2)
                    HandleCommands(inputList, commandsDictionary, collectionsDictionary);
                input = Console.ReadLine();
            }

            //var bindingFlags = BindingFlags.Instance |
            //       BindingFlags.NonPublic |
            //       BindingFlags.Public;
            ////var fieldValues = book1.GetType()
            ////                     .GetFields(bindingFlags)
            ////                     .Select(field => field.Name)
            ////                     .ToList();
            //var fields = book1.GetType().GetFields(bindingFlags);

            //foreach (var field in fields) {
            //    Console.WriteLine($"Field Name: {field.Name}, Field Type: {field.FieldType}");
            //}


            #endregion
        }

        private static List<string> ParseInput(string input) {
            List<String> inputList = new List<String>();
            string pattern = "\"([^\"]+)\"|([^ ]+)";

            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches) {
                if (match.Groups[1].Success)
                {
                    string word = match.Groups[1].Value;
                    inputList.Add(word);
                }
                else if (match.Groups[2].Success)
                {
                    string word = match.Groups[2].Value;
                    inputList.Add(word);
                }
            }

            return inputList;
        }

        private static void HandleCommands(List<String> inputList, Dictionary<String, Visitor> commandDict, Dictionary<String, CollectionWrapper> collectionDict) {
            string command = inputList[0];
            string classType = inputList[1];
            List<String> requirements = inputList.Count > 2 ? inputList.GetRange(2, inputList.Count - 2) : new List<string>();
            if (classType == "Book") {
                BajtpikCollection<Project1_Adapter.Book> collection = (BajtpikCollection<Project1_Adapter.Book>)collectionDict["book"];
                try {
                    commandDict[command].AddRequirements(requirements).Visit(collection);
                } catch(KeyNotFoundException e) {
                    Console.WriteLine($"{command} is not a valid command!");
                    return;
                }
            }
            else if(classType == "NewsPaper") {
                BajtpikCollection<Project1_Adapter.NewsPaper> collection = (BajtpikCollection<Project1_Adapter.NewsPaper>)collectionDict["newspaper"];
                try {
                    commandDict[command].AddRequirements(requirements).Visit(collection);
                }
                catch (KeyNotFoundException e) {
                    Console.WriteLine($"{command} is not a valid command!");
                    return;
                }
            }
            else if(classType == "BoardGame") {
                BajtpikCollection<Project1_Adapter.BoardGame> collection = (BajtpikCollection<Project1_Adapter.BoardGame>)collectionDict["boardgame"];
                try {
                    commandDict[command].AddRequirements(requirements).Visit(collection);
                }
                catch (KeyNotFoundException e) {
                    Console.WriteLine($"{command} is not a valid command!");
                    return;
                }
            }
            else if(classType == "Author") {
                BajtpikCollection<Project1_Adapter.Author> collection = (BajtpikCollection<Project1_Adapter.Author>)collectionDict["author"];
                try {
                    commandDict[command].AddRequirements(requirements).Visit(collection);
                }
                catch (KeyNotFoundException e) {
                    Console.WriteLine($"{command} is not a valid command!");
                    return;
                }
            }
            else {
                Console.WriteLine("Class not supported!");
                return;
            }

        }
    }
}