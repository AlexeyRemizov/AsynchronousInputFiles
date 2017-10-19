using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsynchronousInputFiles
{
    public class GetAllFiles
    {
        public List<string> FindAllFilesInDirectory(string directory)
        {
            List<string> dirsList = new List<string>();
            string[] dirs = Directory.GetFiles(directory, "*");
            dirsList.AddRange(dirs);
            return dirsList;
        }

        //A method that verifies that the file is not empty
        public void CheckFile(string curFile)
        {
            if (!File.Exists(curFile))
            {
                Console.WriteLine(string.Format("File '{0}' is absent in the specified directory", curFile));
                Console.ReadKey();
                return;
            }
        }

        public void CheckDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Console.WriteLine(string.Format("Directory '{0}' is absent in the specified directory", directory));
                Console.ReadKey();
                return;
            }
        }
    }
}
