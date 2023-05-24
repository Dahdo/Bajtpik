using Project3_Builder;
using Project3_CollectionWrapper;
using Project3_Visitor;

namespace Project4_Command {
    public class ListCommand : ICommand {
        private Visitor ListVisitor;
        private CollectionWrapper CollectionWrapper;

        public ListCommand(Visitor listVisitor, CollectionWrapper collectionWrapper) {
            this.ListVisitor = listVisitor;
            this.CollectionWrapper = collectionWrapper;
        }
        public void Execute() {
            this.CollectionWrapper.Accept(this.ListVisitor);
        }
    }

    public class FindCommand : ICommand {
        private Visitor FindVisitor;
        private CollectionWrapper CollectionWrapper;
        private List<string> Requirements;

        public FindCommand(Visitor findVisitor, CollectionWrapper collectionWrapper, List<string> requirements) {
            this.FindVisitor = findVisitor;
            this.CollectionWrapper = collectionWrapper;
            this.Requirements = requirements; 
        }
        public void Execute() {
            this.FindVisitor.AddRequirements(Requirements);
            this.CollectionWrapper.Accept(this.FindVisitor);
        }
    }

    public class AddCommand : ICommand {
        private CollectionWrapper CollectionWrapper;
        private ResourceBuilder Builder;
        private Director Director;
        public AddCommand(ResourceBuilder builder, Director director, CollectionWrapper collectionWrapper) {
            this.Builder = builder;
            this.Director = director;
            this.CollectionWrapper = collectionWrapper;
        }

        public void Execute() {
            this.CollectionWrapper.Direct(this.Director, this.Builder);
        }
    }
}
