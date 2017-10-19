using System;
using System.Collections.Generic;
using System.Configuration;
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
            var curWord = ConfigurationManager.AppSettings["Word"];
            var curFilePath = ConfigurationManager.AppSettings[@"Path"];

            AsyncInputFiles asyncInputFile = new AsyncInputFiles();
            var results = asyncInputFile.ProcessWriteMult(curWord, curFilePath);
            Console.WriteLine(results.Result.Count);
            foreach (var result in results.Result)
            {
                Console.WriteLine("{0}---{1}", result.Key, result.Value);
            }

            Console.WriteLine(" End of program, PRESS ANY KEY ");
            Console.ReadKey();

        }
    }
}
