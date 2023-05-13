﻿

using Project1_Adapter;
using Project2_Algorithms;
using Project2_Collections;
using Project2_Iterators;

namespace Project3_Visitor {
    public class ListVisitor : Visitor {
        private List<String>? requirements;
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
            Algorithms<Author>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public Visitor AddRequirements(List<String> requirements) {
            this.requirements = requirements;
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


        public void Visit(BajtpikCollection<Book> book) {
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

        public void Visit(BajtpikCollection<BoardGame> boardGame) {
            if (ParseRequirements()) ;
            else return;
            ForwardIterator<BoardGame> fid = boardGame.GetForwardIterator();
            //ParseNameTypes(fid.Current);
            Algorithms<BoardGame>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit(BajtpikCollection<NewsPaper> newsPaper) {
            if (ParseRequirements()) ;
            else return;
            ForwardIterator<NewsPaper> fid = newsPaper.GetForwardIterator();
            //ParseNameTypes(fid.Current);
            Algorithms<NewsPaper>.ForEach(fid, a => { Console.WriteLine(a.ToString()); });
        }

        public void Visit(BajtpikCollection<Author> author) {
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
}
