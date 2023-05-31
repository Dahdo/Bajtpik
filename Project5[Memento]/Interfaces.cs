namespace Project5_Memento {
    public interface IMemento {
        public List<object> GetState();
        public DateTime GetDate();
    }
}
