

using Project1_Adapter;
using Project2_Algorithms;
using Project2_Collections;
using Project2_Iterators;
using Project3_CollectionWrapper;
using System.Reflection;
using System.Reflection.Metadata;

namespace Project3_Visitor {
    public class ListVisitor : Visitor {
        private List<String> requirements;
        public ListVisitor() { }
        public void Visit<Book>(Vector<Book> book) {
            ForwardIterator<Book > fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            ForwardIterator<Author> fid = author.GetForwardIterator();
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public Visitor AddRequirements(List<String> requirements) {
            this.requirements = requirements;
            return this;
        
        }

        public Visitor AddNameTypes(Dictionary<String, Type> dict) {
            return this;
        }
    }

    public class FindVisitor : Visitor {
        private List<String> requirements;
        private List<String> fields;
        private List<Char> compOp;
        private List<String> values;
        private Dictionary<String, Type> nameTypesDict;

        public FindVisitor() {
            this.nameTypesDict = new Dictionary<string, Type>();
            this.requirements = new List<string>();
            this.fields = new List<String>();
            this.compOp = new List<char>();
            this.values = new List<String>();
        }


        public void Visit<Book>(Vector<Book> book) {
            if (ParseRequirements());
            else return;
            ForwardIterator<Book> fid = book.GetForwardIterator();
            Action<Project1_Adapter.Book> bookPrintAction = (T) => {
                for(int i = 0; i < fields.Count; i++) {
                    String field = fields[i];
                    char op = compOp[i];
                    String val = values[i];

                    if(op == '=') {
                        if (field == "Title" && T.Title == val)
                            Console.WriteLine(T.ToString());
                        else if (field == "Year" && T.Year == int.Parse(val))
                            Console.WriteLine(T.ToString());
                        else if (field == "PageCount" && T.PageCount == int.Parse(val))
                            Console.WriteLine(T.ToString());
                    }
                    else if(op == '>') {
                        if (field == "Title" && String.Compare(val, T.Title) > 0)
                            Console.WriteLine(T.ToString());
                        else if (field == "Year" && T.Year > int.Parse(val))
                            Console.WriteLine(T.ToString());
                        else if (field == "PageCount" && T.PageCount > int.Parse(val))
                            Console.WriteLine(T.ToString());
                    }
                    else if(op == '<') {
                        if (field == "Title" && String.Compare(val, T.Title) < 0)
                            Console.WriteLine(T.ToString());
                        else if (field == "Year" && T.Year < int.Parse(val))
                            Console.WriteLine(T.ToString());
                        else if (field == "PageCount" && T.PageCount < int.Parse(val))
                            Console.WriteLine(T.ToString());
                    }
                }
                //Console.WriteLine(T.ToString());
            };
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            if (ParseRequirements()) ;
            else return;
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            //ParseNameTypes(fid.Current);
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            if (ParseRequirements()) ;
            else return;
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            //ParseNameTypes(fid.Current);
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            if (ParseRequirements());
            else return;
            ForwardIterator<Author> fid = author.GetForwardIterator();
            //ParseNameTypes(fid.Current);
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
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
        public Visitor AddNameTypes(Dictionary<String, Type> dict) {
            nameTypesDict = dict;
            return this;
        }
    }

    public class AddVisitor : Visitor {
        private List<String> requirements;
        private List<String> fields;
        private List<Char> compOp;
        private List<String> values;
        private Dictionary<String, Type> nameTypesDict;

        public AddVisitor() {
            this.nameTypesDict = new Dictionary<string, Type>();
            this.requirements = new List<string>();
            this.fields = new List<String>();
            this.compOp = new List<char>();
            this.values = new List<String>();
        }
        public void Visit<Book>(Vector<Book> book) {
            showFields();
            MainFormat.Book b = (MainFormat.Book)startProc(requirements[0], 0);
            //book.Add(b);
            ForwardIterator<Book> fid = book.GetForwardIterator();
            Algorithms<Book>.ForEach(fid, a => { Console.WriteLine(a.ToString());});
            Console.WriteLine(b.ToString());
        }

        public void Visit<BoardGame>(Heap<BoardGame> boardGame) {
            showFields();
            startProc(requirements[0], 1);
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<NewsPaper>(DoublelyLinkedList<NewsPaper> newsPaper) {
            showFields();
            startProc(requirements[0], 2);
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit<Author>(BajtpikCollection<Author> author) {
            showFields();
            startProc(requirements[0], 3);
            ForwardIterator<Author> fid = author.GetForwardIterator();
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public Visitor AddRequirements(List<String> requirements) {
            this.requirements = requirements;
            return this;
        }
        public Visitor AddNameTypes(Dictionary<String, Type> dict) {
            nameTypesDict = dict;
            return this;
        }
        private void showFields() {
            foreach(var val in nameTypesDict) {
                if (val.Key == "Authors")
                    continue;
                Console.WriteLine($"{val.Key} : {val.Value}");
            }
        }

        private Object startProc(string repr, int type) {
            List<string> vals;
            string input = Console.ReadLine();
            MainFormat.Book book = new MainFormat.Book();
            while (!String.Equals(input, "done", StringComparison.OrdinalIgnoreCase)) {
                vals = GetVals(input);
                if(type == 0) {
                    if (vals[0] == "Title")
                        book.Title = vals[1];
                    else if (vals[0] == "Year")
                        book.Year = int.Parse(vals[1]);
                    else if (vals[0] == "PageCount")
                        book.PageCount = int.Parse(vals[1]);
                }   
                input = Console.ReadLine();
            }
            return book;
        }

        private List<string> GetVals(string input) {
            var vals = new List<string>();
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == '=') {
                    vals.Add(input.Substring(0, i));

                    int startIdx = i + 1;

                    if (startIdx < input.Length && input[startIdx] == '\"') {
                        int endIdx = input.IndexOf('\"', startIdx + 1);
                        if (endIdx != -1) {
                            vals.Add(input.Substring(startIdx + 1, endIdx - startIdx - 1));
                            break;
                        }
                    }
                    else {
                        vals.Add(input.Substring(startIdx, input.Length - startIdx));
                        break;
                    }
                }
            }
            return vals;
        }

    }

}
