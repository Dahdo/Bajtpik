using Project4_Command;
using System.Collections;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
namespace Project4_Strategy {
    public class TXTExporter : IStrategy {
        private string Path;
        private Queue<ICommand> CommandsQueue;
        public TXTExporter(string path, Queue<ICommand> commandQ) {
            this.Path = path;
            this.Path += ".txt";
            this.CommandsQueue = new Queue<ICommand>(commandQ);
        }
        public void Execute() {
            try {
                using (StreamWriter writer = new StreamWriter(this.Path)) {
                    foreach(var command in this.CommandsQueue) {
                        writer.WriteLine(command.ToString());
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"[Failed to create file: [{ex.Message}]");
            }
        }
    }

    public class XMLExporter : IStrategy {
        private string FileName;
        public XMLExporter(string fileName) {
            this.FileName = fileName;
        }
        public void Execute() {
            throw new NotImplementedException();
        }
    }

    public class TXTLoader : IStrategy {
        private string Path;
        private Queue<ICommand> CommandsQueue;
        public TXTLoader(string path, Queue<ICommand> commandQ) {
            this.Path = path;
            this.CommandsQueue = commandQ;
        }
        public void Execute() {
            try {
                using (StreamReader reader = new StreamReader(this.Path)) {
                    string line;
                    while ((line = reader.ReadLine()) != null){
                        Console.WriteLine(line);
                    }
                }

            }
            catch (Exception ex) {
                Console.WriteLine($"[Failed to create file: [{ex.Message}]");
            }


        }
    }


    public class Context {
        private IStrategy? strategy;
        public Context() { }
        public void SetStrategy(IStrategy strategy) {
            this.strategy = strategy;
        }
        public void DoStrategy() {
            if (strategy == null) {
                return;
            }
            strategy.Execute();
        }
    }
}
