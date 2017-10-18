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
    }
}
