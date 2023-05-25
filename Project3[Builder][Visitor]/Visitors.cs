using Project1_Adapter;
using Project2_Algorithms;
using Project2_Collections;
using Project2_Iterators;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;

namespace Project3_Visitor {
    public class ListVisitor : Visitor {
        public ListVisitor() { }
        public void Visit(BajtpikCollection<Book> book) {
            ForwardIterator<Book > fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit(BajtpikCollection<BoardGame> boardGame) {
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit(BajtpikCollection<NewsPaper> newsPaper) {
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit(BajtpikCollection<Author> author) {
            ForwardIterator<Author> fid = author.GetForwardIterator();
            List<Author> authList = new List<Author>();
            while (!authList.Contains(fid.Current())) {
                Console.WriteLine(fid.Current()?.ToString());
                authList.Add(fid.Current());
                fid.Move();
            }
        }

        public Visitor AddRequirements(List<String> requirements) {
            return this;
        }

        public Visitor ClearData() {
            return this;
        }
    }

    public class FindVisitor : Visitor {
        private List<String> requirements;
        private List<String> fields;
        private List<Char> compOp;
        private List<String> values;
        private Dictionary<char, Func<object, object, Type, bool>> compOpsFun;
        private Dictionary<String, Tuple<Object, Type>> classTuple;

        public FindVisitor() {
            this.compOpsFun = new Dictionary<char, Func<object, object, Type, bool>>();
            this.classTuple = new Dictionary<string, Tuple<object, Type>>();
            this.requirements = new List<string>();
            this.fields = new List<String>();
            this.compOp = new List<char>();
            this.values = new List<String>();
        }


        public void Visit(BajtpikCollection<Book> book) {
            if (ParseRequirements());
            else return;
            InitCompOps();
            ForwardIterator<Book> fid = book.GetForwardIterator();
            DoFind(fid);
            ClearData();
        }

        public void Visit(BajtpikCollection<BoardGame> boardGame) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            DoFind(fid);
            ClearData();
        }

        public void Visit(BajtpikCollection<NewsPaper> newsPaper) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            DoFind(fid);
            ClearData();
        }

        public void Visit(BajtpikCollection<Author> author) {
            if (ParseRequirements());
            else return;
            InitCompOps();
            ForwardIterator<Author> fid = author.GetForwardIterator();
            //author iterators have their own issue. custom DoFind here
            List<Author> authList = new List<Author>();
            while (!authList.Contains(fid.Current())) {
                this.classTuple.Clear();
                InitClassTuple(fid.Current());
                for (int i = 0; i < fields.Count; i++) {
                    object obj = classTuple[fields[i].ToLower()].Item1;
                    Type type = classTuple[fields[i].ToLower()].Item2;
                    Func<object, object, Type, bool> fun = compOpsFun[compOp[i]];
                    if (fun != null && fun(obj, values[i], type)) {
                        Console.WriteLine(fid.Current().ToString());
                    }
                }
                authList.Add(fid.Current());
                fid.Move();
            }
            authList.Clear();
            ClearData();
        }
        public Visitor AddRequirements(List<String> requirements) {
            this.requirements = requirements;
            return this;
        }
        private bool ParseRequirements() {
            foreach(String str in requirements) {
                if(str.Contains("=")) {
                    fields.Add(str.Substring(0, str.IndexOf("=")));
                    compOp.Add('=');
                    values.Add(str.Substring(str.IndexOf("=") + 1));
                }
                else if (str.Contains("<")) {
                    fields.Add(str.Substring(0, str.IndexOf("<")));
                    compOp.Add('<');
                    values.Add(str.Substring(str.IndexOf("<") + 1));
                }
                else if (str.Contains(">")) {
                    fields.Add(str.Substring(0, str.IndexOf(">")));
                    compOp.Add('>');
                    values.Add(str.Substring(str.IndexOf(">") + 1));
                }
                else {
                    Console.WriteLine("invalid requirement input");
                    return false;
                }
            }

            return true;
        }
        private void InitClassTuple(Object obj) {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            
            foreach(var prop in properties) {
                if (prop.Name == "Authors") {
                    continue;
                }
                this.classTuple.Add(prop.Name.ToLower(), new Tuple<object, Type>(prop.GetValue(obj)!, prop.PropertyType));
            }
        }
        private void InitCompOps() {
            this.compOpsFun.Add('=', (a, b, c) => {
                if(c == typeof(int)) {
                    return (int)a == int.Parse((string)b);
                } else if(c == typeof(string)) {
                    return string.Equals((string)a, (string)b, StringComparison.OrdinalIgnoreCase);
                } else {
                    return false;
                }
            });

            this.compOpsFun.Add('>', (a, b, c) => {
                if (c == typeof(int)) {
                    return (int)a > int.Parse((string)b);
                }
                else if (c == typeof(string)) {
                    return string.Compare((string)a, (string)b, StringComparison.OrdinalIgnoreCase) > 0;
                }
                else {
                    return false;
                }
            });

            this.compOpsFun.Add('<', (a, b, c) => {
                if (c == typeof(int)) {
                    return (int)a < int.Parse((string)b);
                }
                else if (c == typeof(string)) {
                    return  string.Compare((string)a, (string)b, StringComparison.OrdinalIgnoreCase) < 0;
                }
                else {
                    return false;
                }
            });
        }
        private void DoFind<T>(ForwardIterator<T> fid) {
            bool isDone = false;
            while (!isDone) {
                this.classTuple.Clear();
                InitClassTuple(fid.Current());
                for (int i = 0; i < fields.Count; i++) {
                    object obj = classTuple[fields[i].ToLower()].Item1;
                    Type type = classTuple[fields[i].ToLower()].Item2;
                    Func<object, object, Type, bool> fun = compOpsFun[compOp[i]];
                    if (fun != null && fun(obj, values[i], type)) {
                        Console.WriteLine(fid.Current().ToString());
                    }
                }
                isDone = fid.IsDone();
                fid.Move();
            }
        }
        public Visitor ClearData() {
            requirements.Clear();
            classTuple.Clear();
            fields.Clear();
            compOp.Clear();
            values.Clear();
            compOpsFun.Clear();
            return this;
        }
    }

    public class DeleteVisitor : Visitor {
        private List<String> requirements;
        private List<String> fields;
        private List<Char> compOp;
        private List<String> values;
        private Dictionary<char, Func<object, object, Type, bool>> compOpsFun;
        private Dictionary<String, Tuple<Object, Type>> classTuple;

        public DeleteVisitor() {
            this.compOpsFun = new Dictionary<char, Func<object, object, Type, bool>>();
            this.classTuple = new Dictionary<string, Tuple<object, Type>>();
            this.requirements = new List<string>();
            this.fields = new List<String>();
            this.compOp = new List<char>();
            this.values = new List<String>();
        }


        public void Visit(BajtpikCollection<Book> book) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<Book> fid = book.GetForwardIterator();
            book.Remove(DoFind(fid));
            ClearData();
        }

        public void Visit(BajtpikCollection<BoardGame> boardGame) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            boardGame.Remove(DoFind(fid));
            ClearData();
        }

        public void Visit(BajtpikCollection<NewsPaper> newsPaper) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            newsPaper.Remove(DoFind(fid));
            ClearData();
        }

        public void Visit(BajtpikCollection<Author> author) {
            if (ParseRequirements()) ;
            else return;
            InitCompOps();
            ForwardIterator<Author> fid = author.GetForwardIterator();
            //author iterators have their own issue. custom DoFind here
            List<Author> authList = new List<Author>();
            while (!authList.Contains(fid.Current())) {
                this.classTuple.Clear();
                InitClassTuple(fid.Current());
                for (int i = 0; i < fields.Count; i++) {
                    object obj = classTuple[fields[i].ToLower()].Item1;
                    Type type = classTuple[fields[i].ToLower()].Item2;
                    Func<object, object, Type, bool> fun = compOpsFun[compOp[i]];
                    if (fun != null && fun(obj, values[i], type)) {
                        author.Remove(fid.Current());
                        return;
                    }
                }
                authList.Add(fid.Current());
                fid.Move();
            }
            authList.Clear();
            ClearData();
        }
        public Visitor AddRequirements(List<String> requirements) {
            this.requirements = requirements;
            return this;
        }
        private bool ParseRequirements() {
            foreach (String str in requirements) {
                if (str.Contains("=")) {
                    fields.Add(str.Substring(0, str.IndexOf("=")));
                    compOp.Add('=');
                    values.Add(str.Substring(str.IndexOf("=") + 1));
                }
                else if (str.Contains("<")) {
                    fields.Add(str.Substring(0, str.IndexOf("<")));
                    compOp.Add('<');
                    values.Add(str.Substring(str.IndexOf("<") + 1));
                }
                else if (str.Contains(">")) {
                    fields.Add(str.Substring(0, str.IndexOf(">")));
                    compOp.Add('>');
                    values.Add(str.Substring(str.IndexOf(">") + 1));
                }
                else {
                    Console.WriteLine("invalid requirement input");
                    return false;
                }
            }

            return true;
        }
        private void InitClassTuple(Object obj) {
            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var prop in properties) {
                if (prop.Name == "Authors") {
                    continue;
                }
                this.classTuple.Add(prop.Name.ToLower(), new Tuple<object, Type>(prop.GetValue(obj)!, prop.PropertyType));
            }
        }
        private void InitCompOps() {
            this.compOpsFun.Add('=', (a, b, c) => {
                if (c == typeof(int)) {
                    return (int)a == int.Parse((string)b);
                }
                else if (c == typeof(string)) {
                    return string.Equals((string)a, (string)b, StringComparison.OrdinalIgnoreCase);
                }
                else {
                    return false;
                }
            });

            this.compOpsFun.Add('>', (a, b, c) => {
                if (c == typeof(int)) {
                    return (int)a > int.Parse((string)b);
                }
                else if (c == typeof(string)) {
                    return string.Compare((string)a, (string)b, StringComparison.OrdinalIgnoreCase) > 0;
                }
                else {
                    return false;
                }
            });

            this.compOpsFun.Add('<', (a, b, c) => {
                if (c == typeof(int)) {
                    return (int)a < int.Parse((string)b);
                }
                else if (c == typeof(string)) {
                    return string.Compare((string)a, (string)b, StringComparison.OrdinalIgnoreCase) < 0;
                }
                else {
                    return false;
                }
            });
        }
        private T DoFind<T>(ForwardIterator<T> fid) {
            bool isDone = false;
            while (!isDone) {
                this.classTuple.Clear();
                InitClassTuple(fid.Current());
                for (int i = 0; i < fields.Count; i++) {
                    object obj = classTuple[fields[i].ToLower()].Item1;
                    Type type = classTuple[fields[i].ToLower()].Item2;
                    Func<object, object, Type, bool> fun = compOpsFun[compOp[i]];
                    if (fun != null && fun(obj, values[i], type)) {
                        return fid.Current();
                    }
                }
                isDone = fid.IsDone();
                fid.Move();
            }
            return default;
        }
        public Visitor ClearData() {
            requirements.Clear();
            classTuple.Clear();
            fields.Clear();
            compOp.Clear();
            values.Clear();
            compOpsFun.Clear();
            return this;
        }
    }
    
}
