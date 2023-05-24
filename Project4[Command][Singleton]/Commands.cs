using Project3_Builder;
using Project3_CollectionWrapper;
using Project3_Visitor;

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
        public override string ToString() {
            return string.Join(" ", this.Arguments);
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
            this.FindVisitor.AddRequirements(Arguments);
            this.CollectionWrapper.Accept(this.FindVisitor);
        }
        public override string ToString() {
            return string.Join(" ", this.Arguments);
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
        public override string ToString() {
            return string.Join(" ", this.Arguments);
        }
    }
}
