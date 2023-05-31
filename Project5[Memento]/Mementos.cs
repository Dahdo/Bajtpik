using Project1_Adapter;

namespace Project5_Memento {
    public class Memento {
        private List<Resource> State;
        public Memento(List<Resource> collection) {
            this.State = new List<Resource>(collection);
        }
        public List<Resource> GetState() {
            return this.State;
        }
    }
}
