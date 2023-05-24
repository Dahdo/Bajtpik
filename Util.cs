using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BajtpikOOD {
    internal class Util {
        public static List<string> GetFields(Type type) {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            List<string> fields = new List<string>();
            foreach (var prop in properties) {
                if (prop.Name == "Authors") {
                    continue;
                }
                fields.Add(prop.Name);
            }
            return fields;
        }

        public static List<string> SecondaryLoop(Type type) {
            List<string> fields = Util.GetFields(type);
            Console.Write("Available fields: [  ");
            foreach (string field in fields) {
                Console.Write($"{field}  ");
            }
            Console.WriteLine("]");

            List<string> inputList = new List<string>();
            string? input = Console.ReadLine();
            while (input?.ToLower() != "exit" && input?.ToLower() != "done") {
                if(input != null)
                    inputList.Add(input);               
                input = Console.ReadLine();
            }

            return inputList;
        }

        public static List<string> GetFieldVal(string input) {
            var vals = new List<string>();
            for (int i = 0; i < input.Length; i++) {
                if (input[i] == '=') {
                    vals.Add(input.Substring(0, i));

                    int startIdx = i + 1;

                    if (startIdx < input.Length && input[startIdx] == '\"') {
                        int endIdx = input.IndexOf('\"', startIdx + 1);
                        if (endIdx != -1) {
                            vals.Add(input.Substring(startIdx + 1, endIdx - startIdx - 1));
                            break;
                        }
                    }
                    else {
                        vals.Add(input.Substring(startIdx, input.Length - startIdx));
                        break;
                    }
                }
            }
            return vals;
        }
    }

}
