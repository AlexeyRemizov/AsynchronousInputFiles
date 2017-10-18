using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsynchronousInputFiles
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            AsyncInputFiles asyncInputFile = new AsyncInputFiles();
            asyncInputFile.ProcessWriteMult("English", @"d:\logs!\");
            Console.WriteLine(" End of program ");
            Console.ReadKey();

        }
    }
}
