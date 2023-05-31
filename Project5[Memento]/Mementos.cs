namespace Project5_Memento {
    public class Memento : IMemento {
        private List<object> State;
        private DateTime Date;
        public Memento(List<object> collection) {
            this.State = new List<object>(collection);
            this.Date = DateTime.Now;
        }
        public List<object> GetState() {
            return this.State;
        }

        public DateTime GetDate() {
            return this.Date;
        }
    }
}
