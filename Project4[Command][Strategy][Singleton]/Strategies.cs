using BajtpikOOD;
using Project4_Command;
using System.Collections;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Client;
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
                    foreach (var command in this.CommandsQueue) {
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
        public TXTLoader(string path) {
            this.Path = path;
        }
        public void Execute() {
            try {
                using (StreamReader reader = new StreamReader(this.Path)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        List<string> strList = line.Split(" ").ToList();
                        if (strList.Count == 0)
                            continue;
                        if (strList[0] == "add") {
                            line = reader.ReadLine();
                            List<string> arguments = line.Split(" ").ToList();
                            ICommand command = Util.GetAddCommand(Client.Program.collectionsDictionary, Client.Program.buildersDict,
                                Client.Program.typeDict, strList, arguments);
                            Invoker.AddCommand(command);
                            reader.ReadLine();
                        }
                        else if (strList[0] == "edit") {
                            line = reader.ReadLine();
                            List<string> arguments = line.Split(" ").ToList();
                            ICommand command = Util.GetEditCommand(Client.Program.collectionsDictionary, Client.Program.buildersDict,
                                Client.Program.typeDict, strList, arguments);
                            Invoker.AddCommand(command);
                            reader.ReadLine();
                        }
                        else {
                            ICommand command =
                                Util.GetOtherCommand(Client.Program.commandsDictionary,
                                Client.Program.collectionsDictionary, strList);
                            Invoker.AddCommand(command);
                        }
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"error(Load Strategy): [{ex.Message}]");
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
