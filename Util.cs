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
    }
}
