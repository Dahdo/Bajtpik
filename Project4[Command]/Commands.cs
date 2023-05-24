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
            this.Requirements = new List<string>(requirements); //creating a new list. Not a reference to list which might change in main
        }
        public void Execute() {
            this.FindVisitor.AddRequirements(Requirements);
            this.CollectionWrapper.Accept(this.FindVisitor);
        }
    }
}
