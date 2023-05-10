using Project2_Collections;
using Project3_Visitor;
namespace Project3_Visitor {
    public interface Visitor {
        public void Visit<T>(BajtpikCollection<T> collection);
    }
}

namespace Project3_CollectionWrapper {
    public interface CollectionWrapper {
        public void Accept(Visitor visitor);
    }
}
