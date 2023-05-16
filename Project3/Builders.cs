namespace Project3_Builder {
    public class BookBuilderBase : ResourceBuilder, BookBuilder {
        private MainFormat.Book book;
        private List<string> requirements;
        public BookBuilderBase() {
            this.book = new MainFormat.Book();
            this.requirements = new List<string>();
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

        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }

        public ResourceBuilder ResetData() {
            this.requirements.Clear();
            this.book = new MainFormat.Book();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
    }

    public class BookBuilderSecondary : ResourceBuilder, BookBuilder {
        private SecondaryFormat.Book book;
        private List<string> requirements;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BookBuilderSecondary() {
            this.book = new SecondaryFormat.Book();
            this.requirements = new List<string>();
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

        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }

        public ResourceBuilder ResetData() {
            this.requirements.Clear();
            this.book = new SecondaryFormat.Book();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
    }

    public class NewsPaperBase : ResourceBuilder, NewsPaperBuilder {
        private MainFormat.NewsPaper newsPaper;
        private List<string> requirements;
        public NewsPaperBase() {
            this.newsPaper = new MainFormat.NewsPaper();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.newsPaper = new MainFormat.NewsPaper();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }

        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class NewsPaperSecondary : ResourceBuilder, NewsPaperBuilder {
        private SecondaryFormat.NewsPaper newsPaper;
        private List<string> requirements;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public NewsPaperSecondary() {
            this.newsPaper = new SecondaryFormat.NewsPaper();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.newsPaper = new SecondaryFormat.NewsPaper();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class BoardGameBase : ResourceBuilder, BoardGameBuilder {
        private MainFormat.BoardGame boardGame;
        private List<string> requirements;
        public BoardGameBase() {
            this.boardGame = new MainFormat.BoardGame();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.boardGame = new MainFormat.BoardGame();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }

        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class BoardGameSecondary : ResourceBuilder, BoardGameBuilder {
        private SecondaryFormat.BoardGame boardGame;
        private List<string> requirements;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BoardGameSecondary() {
            this.boardGame = new SecondaryFormat.BoardGame();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.boardGame = new SecondaryFormat.BoardGame();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class AuthorBase : ResourceBuilder, AuthorBuilder {
        private MainFormat.Author author;
        private List<string> requirements;
        public AuthorBase() {
            this.author = new MainFormat.Author();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.author = new MainFormat.Author();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class AuthorSecondary : ResourceBuilder, AuthorBuilder {
        private SecondaryFormat.Author author;
        private List<string> requirements;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public AuthorSecondary() {
            this.author = new SecondaryFormat.Author();
            this.requirements = new List<string>();
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
            this.requirements.Clear();
            this.author = new SecondaryFormat.Author();
            return this;
        }

        public ResourceBuilder GetResource() {
            return this;
        }
        public ResourceBuilder AddRequirements(List<string> requirements) {
            this.requirements.AddRange(requirements);
            return this;
        }
    }

    public class Director {
        private ResourceBuilder? resourceBuilder;
        private Dictionary<string, string> fieldValue;

        public Director() {
            resourceBuilder = null;
            fieldValue = new Dictionary<string, string>();
        }

        public void MakeResource(BookBuilder bookBuilder) {
            this.resourceBuilder = (ResourceBuilder?)bookBuilder;
           Dictionary<string, Action<BookBuilder, string>> bookActions = 
           new Dictionary<string, Action<BookBuilder, string>>();

            bookActions["title"] = (book, title) => book.AddTitle(title);
            bookActions[""] = (book, title) => book.AddTitle(title);

        }

        private void Loop() {

        }
    }
}
