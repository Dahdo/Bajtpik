using BajtpikOOD;
using Project1_Adapter;

namespace Project3_Builder {
    public class BookBuilderBase : ResourceBuilder, BookBuilder {
        private MainFormat.Book book;
        private List<string> fields;
        public BookBuilderBase() {
            this.book = new MainFormat.Book();
            this.fields = new List<string>();
        }

        public void AddPageCount(int pageCount) {
            this.book.PageCount = pageCount;
        }

        public void AddTitle(string title) {
            this.book.Title = title;
        }

        public void AddYear(int year) {
            this.book.Year = year;
        }

        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.Book)));
            return this.fields;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.book = new MainFormat.Book();
            return this;
        }

        public Resource GetResource() {
            return this.book;
        }
    }

    public class BookBuilderSecondary : ResourceBuilder, BookBuilder {
        private SecondaryFormat.Book book;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BookBuilderSecondary() {
            this.book = new SecondaryFormat.Book();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddPageCount(int pageCount) {
            intMap.Add(intMap.Count, pageCount);
            this.book.PageCount = intMap.Count - 1;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.book.Title = stringMap.Count - 1;
        }

        public void AddYear(int year) {
            intMap.Add(intMap.Count, year);
            this.book.Year = intMap.Count - 1;
        }

        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.Book)));
            return this.fields;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.book = new SecondaryFormat.Book();
            return this;
        }

        public Resource GetResource() {
            return new BookAdapter(this.book, 1);
        }
    }

    public class NewsPaperBase : ResourceBuilder, NewsPaperBuilder {
        private MainFormat.NewsPaper newsPaper;
        private List<string> fields;
        public NewsPaperBase() {
            this.newsPaper = new MainFormat.NewsPaper();
            this.fields = new List<string>();
        }

        public void AddPageCount(int pageCount) {
            this.newsPaper.PageCount = pageCount;
        }

        public void AddTitle(string title) {
            this.newsPaper.Title = title;
        }

        public void AddYear(int year) {
            this.newsPaper.Year = year;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.newsPaper = new MainFormat.NewsPaper();
            return this;
        }

        public Resource GetResource() {
            return this.newsPaper;
        }

        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.NewsPaper)));
            return this.fields;
        }
    }

    public class NewsPaperSecondary : ResourceBuilder, NewsPaperBuilder {
        private SecondaryFormat.NewsPaper newsPaper;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public NewsPaperSecondary() {
            this.newsPaper = new SecondaryFormat.NewsPaper();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddPageCount(int pageCount) {
            intMap.Add(intMap.Count, pageCount);
            this.newsPaper.PageCount = intMap.Count - 1;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.newsPaper.Title = stringMap.Count - 1;
        }

        public void AddYear(int year) {
            intMap.Add(intMap.Count, year);
            this.newsPaper.Year = intMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.newsPaper = new SecondaryFormat.NewsPaper();
            return this;
        }

        public Resource GetResource() {
            return new NewsPaperAdapter(this.newsPaper, 1);
        }
        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.NewsPaper)));
            return this.fields;
        }
    }

    public class BoardGameBase : ResourceBuilder, BoardGameBuilder {
        private MainFormat.BoardGame boardGame;
        private List<string> fields;
        public BoardGameBase() {
            this.boardGame = new MainFormat.BoardGame();
            this.fields = new List<string>();
        }

        public void AddTitle(string title) {
            this.boardGame.Title = title;
        }

        public void AddMinPlayer(int player) {
            this.boardGame.MinPlayer = player;
        }

        public void AddMaxPlayer(int player) {
            this.boardGame.MaxPlayer = player;
        }

        public void AddDifficulty(int difficulty) {
            this.boardGame.Diffuculty = difficulty;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.boardGame = new MainFormat.BoardGame();
            return this;
        }

        public Resource GetResource() {
            return this.boardGame;
        }

        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.BoardGame)));
            return this.fields;
        }
    }

    public class BoardGameSecondary : ResourceBuilder, BoardGameBuilder {
        private SecondaryFormat.BoardGame boardGame;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BoardGameSecondary() {
            this.boardGame = new SecondaryFormat.BoardGame();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.boardGame.Title = stringMap.Count - 1;
        }

        public void AddMinPlayer(int player) {
            intMap.Add(intMap.Count, player);
            this.boardGame.MinPlayer = intMap.Count - 1;
        }

        public void AddMaxPlayer(int player) {
            intMap.Add(intMap.Count, player);
            this.boardGame.MaxPlayer = intMap.Count - 1;
        }

        public void AddDifficulty(int difficulty) {
            intMap.Add(intMap.Count, difficulty);
            this.boardGame.Diffuculty = intMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.boardGame = new SecondaryFormat.BoardGame();
            return this;
        }

        public Resource GetResource() {
            return new BoardGameAdapter(this.boardGame, 1);
        }
        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.BoardGame)));
            return this.fields;
        }
    }

    public class AuthorBase : ResourceBuilder, AuthorBuilder {
        private MainFormat.Author author;
        private List<string> fields;
        public AuthorBase() {
            this.author = new MainFormat.Author();
            this.fields = new List<string>();
        }

        public void AddBirthYear(int year) {
            this.author.BirthYear = year;
        }

        public void AddName(string name) {
            this.author.Name = name;
        }

        public void AddNickname(string nickname) {
            this.author.Surname = nickname;
        }

        public void AddSurname(string surname) {
            this.author.Surname = surname;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.author = new MainFormat.Author();
            return this;
        }

        public Resource GetResource() {
            return this.author;
        }
        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }
    }

    public class AuthorSecondary : ResourceBuilder, AuthorBuilder {
        private SecondaryFormat.Author author;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public AuthorSecondary() {
            this.author = new SecondaryFormat.Author();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddBirthYear(int year) {
            intMap.Add(intMap.Count, year);
            this.author.BirthYear = intMap.Count - 1;
        }

        public void AddName(string name) {
            stringMap.Add(stringMap.Count, name);
            this.author.Name = stringMap.Count - 1;
        }

        public void AddNickname(string nickname) {
            stringMap.Add(stringMap.Count, nickname);
            this.author.Surname = stringMap.Count - 1;
        }

        public void AddSurname(string surname) {
            stringMap.Add(stringMap.Count, surname);
            this.author.Surname = stringMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.author = new SecondaryFormat.Author();
            return this;
        }

        public Resource GetResource() {
            return new AuthorAdapter(this.author, 1);
        }
        public List<string> GetFields() {
            this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }
    }
    


    //Director
    public class Director {
        private ResourceBuilder? resourceBuilder;
        Dictionary<string, Action<ResourceBuilder, string>> resourceActions;

        public Director() {
            resourceBuilder = null;
            resourceActions = new Dictionary<string, Action<ResourceBuilder, string>>();
        }

        public void MakeResource(BookBuilder bookBuilder) {
           this.resourceBuilder = (ResourceBuilder?)bookBuilder;

            this.resourceActions["title"] = (book, title) => ((BookBuilder)book).AddTitle(title);
            this.resourceActions["year"] = (book, year) => ((BookBuilder)book).AddYear(int.Parse(year));
            this.resourceActions["pagecount"] = (book, pagecount) => ((BookBuilder)book).AddPageCount(int.Parse(pagecount));
            Loop();
        }

        private void Loop() {
            Console.Write("Available fiels: [  ");
            foreach(string field in this.resourceBuilder?.GetFields()!) {
                Console.Write($"{field}  ");
            }
            Console.WriteLine("]");


            string? input = Console.ReadLine();
            while (input?.ToLower() != "exit" && input?.ToLower() != "done") {
                string[] parsedInput = input!.Split("=");
                if (parsedInput.Length == 1)
                    if (input.ToLower() != "exit" && input.ToLower() != "done")
                        Console.WriteLine("Command not supported!");
                if (parsedInput.Length == 2)
                    try {
                        this.resourceActions[parsedInput[0]](this.resourceBuilder!, parsedInput[1]);
                    }
                    catch (Exception e) {
                        Console.WriteLine($"Add error: [{e.Message}]");
                    }
                input = Console.ReadLine();
            }

            if(input?.ToLower() == "done") {
                Console.WriteLine("[Added successfuly]");
            }
            if (input?.ToLower() == "exit") {
                this.resourceBuilder?.ResetData();
                Console.WriteLine("[Add failed]");
            }
        }
    }
}
