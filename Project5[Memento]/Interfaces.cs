namespace Project5_Memento {
    public interface IMemento {
        public IMemento GetState();
        public DateTime GetDate();
    }
}
