using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ClassLibrary1;
using Microsoft.Dnx.Runtime;

namespace ConsoleApp1
{
    public class Program
    {
        private readonly ILibraryManager libraryManager;

        public Program(ILibraryManager libraryManager)
        {
            this.libraryManager = libraryManager;
        }

        public void Main(string[] args)
        {
            var c = new Class1();
            c.DoIt();

            var t = Type.GetType("ClassLibrary1.Class1");
            if (t != null)
            {
                Console.WriteLine(t.Name);
            }

            var library = libraryManager.GetLibrary("ClassLibrary1");
            var a = Assembly.Load(library.Assemblies.First());
            t = a.GetType("Class1");
            if (t != null)
            {
                Console.WriteLine(t.Name);
            }
            t = a.GetType("ClassLibrary1.Class1");
            if (t != null)
            {
                Console.WriteLine(t.Name);
            }
            t = a.GetTypes().First();
            Console.WriteLine(t.Name);
        }
    }
}
