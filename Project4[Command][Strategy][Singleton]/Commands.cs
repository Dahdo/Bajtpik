using Project3_Builder;
using Project3_CollectionWrapper;
using Project3_Visitor;
using Project5_Memento;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project4_Command {
    public class ListCommand : ICommand {
        private Visitor ListVisitor;
        private CollectionWrapper CollectionWrapper;
        private List<string> Arguments;

        public ListCommand(Visitor listVisitor, CollectionWrapper collectionWrapper, List<string> args) {
            this.ListVisitor = listVisitor;
            this.CollectionWrapper = collectionWrapper;
            this.Arguments = args;
        }
        public void Execute() {
            this.CollectionWrapper.Accept(this.ListVisitor);
        }
        public CollectionWrapper GetOriginator() {
            return this.CollectionWrapper;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(" ", this.Arguments))
                .Append('\n');
            return stringBuilder.ToString().Trim();
        }
    }

    public class FindCommand : ICommand {
        private Visitor FindVisitor;
        private CollectionWrapper CollectionWrapper;
        private List<string> Arguments;

        public FindCommand(Visitor findVisitor, CollectionWrapper collectionWrapper, List<string> args) {
            this.FindVisitor = findVisitor;
            this.CollectionWrapper = collectionWrapper;
            this.Arguments = args; 
        }
        public void Execute() {
            this.FindVisitor.AddRequirements(Arguments.GetRange(2, Arguments.Count - 2));
            this.CollectionWrapper.Accept(this.FindVisitor);
        }

        public CollectionWrapper GetOriginator() {
            return this.CollectionWrapper;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(" ", this.Arguments))
                .Append('\n');
            return stringBuilder.ToString().Trim();
        }
    }

    public class AddCommand : ICommand {
        private CollectionWrapper CollectionWrapper;
        private ResourceBuilder Builder;
        private Director Director;
        private List<string> Arguments;
        public AddCommand(ResourceBuilder builder, Director director, CollectionWrapper collectionWrapper, List<string> args) {
            this.Builder = builder;
            this.Director = director;
            this.CollectionWrapper = collectionWrapper;
            this.Arguments = args;
        }

        public void Execute() {
            this.CollectionWrapper.Direct(this.Director, this.Builder);
        }

        public CollectionWrapper GetOriginator() {
            return this.CollectionWrapper;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(" ", this.Arguments))
                .Append('\n').Append(string.Join(" ", this.Director.Arguments))
                .Append('\n').Append("done");

            return stringBuilder.ToString().Trim();
        }
    }

    public class EditCommand : ICommand {
        private CollectionWrapper CollectionWrapper;
        private ResourceBuilder Builder;
        private Director Director;
        private List<string> Arguments;
        public EditCommand(ResourceBuilder builder, Director director, CollectionWrapper collectionWrapper, List<string> args) {
            this.Builder = builder;
            this.Director = director;
            this.CollectionWrapper = collectionWrapper;
            this.Arguments = args;
        }

        public void Execute() {
            this.CollectionWrapper.Direct(this.Director, this.Builder);
        }

        public CollectionWrapper GetOriginator() {
            return this.CollectionWrapper;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(" ", this.Arguments))
                .Append('\n').Append(string.Join(" ", this.Director.Arguments))
                .Append('\n').Append("done");

            return stringBuilder.ToString().Trim();
        }
    }

    public class DeleteCommand : ICommand {
        private Visitor DeleteVisitor;
        private CollectionWrapper CollectionWrapper;
        private List<string> Arguments;

        public DeleteCommand(Visitor deleteVisitor, CollectionWrapper collectionWrapper, List<string> args) {
            this.DeleteVisitor = deleteVisitor;
            this.CollectionWrapper = collectionWrapper;
            this.Arguments = args;
        }
        public void Execute() {
            this.DeleteVisitor.AddRequirements(Arguments.GetRange(2, Arguments.Count - 2));
            this.CollectionWrapper.Accept(this.DeleteVisitor);
        }

        public CollectionWrapper GetOriginator() {
            return this.CollectionWrapper;
        }
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Join(" ", this.Arguments))
                .Append('\n');
            return stringBuilder.ToString().Trim();
        }
    }
}
