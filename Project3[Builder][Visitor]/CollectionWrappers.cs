using Project2_Collections;
using Project3_Visitor;
using Project1_Adapter;
using Project3_Builder;
using Project5_Memento;
using System.Runtime.InteropServices.ObjectiveC;

namespace Project3_CollectionWrapper {
    public class BookCollection : CollectionWrapper {
        private readonly BajtpikCollection<Book> collection;
        public BookCollection(BajtpikCollection<Book> collection) {
            this.collection = collection;
        }
        public void Accept(Visitor visitor) {
            visitor.Visit(collection);
        }
        public void Direct(Director director, ResourceBuilder builder) {
            director.MakeResource(builder, collection);
        }

        public void Restore(IMemento memento) {
            this.collection.Restore(memento);
        }

        public IMemento Save() {
            return this.collection.Save();
        }
    }

    public class NewsPaperCollection : CollectionWrapper {
        private readonly BajtpikCollection<NewsPaper> collection;
        public NewsPaperCollection(BajtpikCollection<NewsPaper> collection) {
            this.collection = collection;
        }
        public void Accept(Visitor visitor) {
            visitor.Visit(collection);
        }

        public void Direct(Director director, ResourceBuilder builder) {
            director.MakeResource(builder, collection);
        }

        public void Restore(IMemento memento) {
            this.collection.Restore(memento);
        }

        public IMemento Save() {
            return this.collection.Save();
        }
    }

    public class BoardGameCollection : CollectionWrapper {
        private readonly BajtpikCollection<BoardGame> collection;
        public BoardGameCollection(BajtpikCollection<BoardGame> collection) {
            this.collection = collection;
        }
        public void Accept(Visitor visitor) {
            visitor.Visit(collection);
        }
        public void Direct(Director director, ResourceBuilder builder) {
            director.MakeResource(builder, collection);
        }

        public void Restore(IMemento memento) {
            this.collection.Restore(memento);
        }

        public IMemento Save() {
            return this.collection.Save();
        }
    }

    public class AuthorCollection : CollectionWrapper {
        private readonly BajtpikCollection<Author> collection;
        public AuthorCollection(BajtpikCollection<Author> collection) {
            this.collection = collection;
        }
        public void Accept(Visitor visitor) {
            visitor.Visit(collection);
        }
        public void Direct(Director director, ResourceBuilder builder) {
            director.MakeResource(builder, collection);
        }

        public void Restore(IMemento memento) {
            this.collection.Restore(memento);
        }

        public IMemento Save() {
            return this.collection.Save();
        }
    }
}
