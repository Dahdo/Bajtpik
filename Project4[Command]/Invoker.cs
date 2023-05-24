using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_Command {
    public class Invoker {
        private static Queue<ICommand>? CommandQueue;
        private Invoker() {}

        public static void AddCommand(ICommand command) {
            if(CommandQueue == null) {
                Invoker.CommandQueue = new Queue<ICommand>();
            }
            CommandQueue.Enqueue(command);
        }

        public static void Print() {
            if (Invoker.CommandQueue == null)
                return;
            foreach(var command in CommandQueue) {
                Console.WriteLine(command.ToString());
            }
        }

        public static void Export() {
            new NotImplementedException();
        }

        public static void Commit() {
            if (Invoker.CommandQueue == null) 
                return;
            foreach(var command in CommandQueue) {
                command.Execute();
            }
        }
    }
}
