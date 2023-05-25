using Project4_Strategy;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization;
namespace Project4_Command {
    //Singleton class
    public class Invoker {
        private static Queue<ICommand>? CommandQueue;
        private static List<string>? Arguments;
        private static Context context = new Context();
        private static IStrategy strategy;
        private Invoker() {}

        public static void AddArguments(List<string> args) {
            Invoker.Arguments = new List<string>(args);
        }

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
            try {
                if (Invoker.Arguments?.Count > 1 && Invoker.Arguments[1].ToLower() == "plaintext")
                    Invoker.context.SetStrategy(new TXTExporter(Invoker.Arguments[0], CommandQueue));
                else
                    Invoker.context.SetStrategy(new XMLExporter(Invoker.Arguments[0]));
            }catch (Exception e) {
                Console.WriteLine($"Error: [{e.Message}]");
            }
            Invoker.context.DoStrategy();
        }

        public static void Commit() {
            if (Invoker.CommandQueue == null) 
                return;
            foreach(var command in CommandQueue) {
                command.Execute();
            }
        }
        public static void Dismiss() {
            Invoker.CommandQueue?.Clear();
        }

        public static void load() {
            new NotImplementedException();
        }
    }
}
