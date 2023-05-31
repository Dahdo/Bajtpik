using Project3_CollectionWrapper;
using Project4_Strategy;
using Project5_Memento;

namespace Project4_Command {
    //Singleton class
    public class Invoker {
        private static Queue<ICommand>? CommandQueue;
        private static List<string>? Arguments;
        private static Context context = new Context();
        private static IStrategy strategy;
        private static Stack<IMemento> UndoMementoStack = new Stack<IMemento>();
        private static Stack<IMemento> RedoMementoStack = new Stack<IMemento>();
        private static Stack<ICommand> UndoCommandStack = new Stack<ICommand>();
        private static Stack<ICommand> RedoCommandStack = new Stack<ICommand>();
        private static IMemento CurrentState;
        private static ICommand CurrentCommand;

        private Invoker() {}

        public static void AddArguments(List<string> args) {
            Invoker.Arguments = new List<string>(args);
        }

        public static void Log(ICommand command) {
            if(CommandQueue == null) {
                Invoker.CommandQueue = new Queue<ICommand>();
            }
            CommandQueue.Enqueue(command); //for history and export, load
            if(command.GetType() == typeof(EditCommand) || command.GetType() == typeof(DeleteCommand)
                || command.GetType() == typeof(AddCommand)) {
                Invoker.Backup(CurrentCommand);
                initCurrent(command);
            }
        }

        public static void History() {
            if (Invoker.CommandQueue == null)
                return;
            int count = 0;
            foreach(var command in CommandQueue) {
                Console.WriteLine($"-------------------------{count++}-----------------------");
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

        public static void Load() {
            try {
                if (Invoker.Arguments?.Count != 0)
                    Invoker.context.SetStrategy(new TXTLoader(Invoker.Arguments[0]));
                else
                    Invoker.context.SetStrategy(new XMLExporter(Invoker.Arguments[0]));
            }
            catch (Exception e) {
                Console.WriteLine($"Error: [{e.Message}]");
            }
            Invoker.context.DoStrategy();
        }

        public static void Backup(ICommand command) {
            Invoker.UndoMementoStack.Push(command.GetOriginator().Save());
            UndoCommandStack.Push(command);
        }

        public static void Undo() {
            if (UndoMementoStack.Count == 0) {
                Console.WriteLine("No undoable command left!");
                return;
            }

            RedoCommandStack.Push(CurrentCommand);
            RedoMementoStack.Push(CurrentState);

            IMemento memento = Invoker.UndoMementoStack.Pop();
            ICommand command = Invoker.UndoCommandStack.Pop();
            command.GetOriginator().Restore(memento);
            initCurrent(command);
            
        }
        public static void Redo() {
            if (RedoMementoStack.Count == 0) {
                Console.WriteLine("No redoable command left!");
                return;
            }
            UndoCommandStack.Push(CurrentCommand);
            UndoMementoStack.Push(CurrentState);

            IMemento memento = Invoker.RedoMementoStack.Pop();
            ICommand command = Invoker.RedoCommandStack.Pop();
            command.GetOriginator().Restore(memento);
            initCurrent(command);
        }

        public static void InitialBackup(ICommand command) {
            if (command.GetType() == typeof(EditCommand) || command.GetType() == typeof(DeleteCommand)
                || command.GetType() == typeof(AddCommand)) {
                initCurrent(command);
            }
        }

        private static void initCurrent(ICommand command) {
            CurrentCommand = command;
            CurrentState = command.GetOriginator().Save();
        }


        //LEGACY ROUTINES
        public static void Commit() {
            if (Invoker.CommandQueue == null)
                return;
            foreach (var command in CommandQueue) {
                command.Execute();
            }
        }
        public static void Dismiss() {
            Invoker.CommandQueue?.Clear();
        }
    }
}
