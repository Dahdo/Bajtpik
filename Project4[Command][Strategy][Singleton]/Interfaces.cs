using Project3_CollectionWrapper;
using Project5_Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_Command{
    public interface ICommand {
        public void Execute();
        public CollectionWrapper GetOriginator();
    }
}

namespace Project4_Strategy {
    public interface IStrategy {
        public void Execute();
    }
}
