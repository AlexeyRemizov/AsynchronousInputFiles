using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsynchronousInputFiles
{
    public class AsyncInputFiles
    {
        public async void ProcessWriteMult(string searchWord, string directory)
        {
            List<Task> tasks = new List<Task>();
            List<FileStream> sourceStreams = new List<FileStream>();
            try
            {
                GetAllFiles getAllFiles = new GetAllFiles();
                var amountOfFiles = getAllFiles.FindAllFilesInDirectory(directory).Count;
                var paths = getAllFiles.FindAllFilesInDirectory(directory);
                var wordsStat = new Dictionary<string, string>();
                foreach (var path in paths)
                {

                    FileStream sourceStream = new FileStream(path,
                        FileMode.Open, FileAccess.Read, FileShare.None,
                        bufferSize: 4096, useAsync: true);
                    int amountInTheLine;
                    using (var streamReader = new StreamReader(sourceStream))
                    {
                        int numberOfString = 0;
                        string inputLine;
                        while (!streamReader.EndOfStream)
                        {
                            inputLine = streamReader.ReadLine();
                            numberOfString++;
                            amountInTheLine = new Regex(searchWord).Matches(inputLine).Count;
                            if (amountInTheLine > 0)
                            {

                                wordsStat[numberOfString + "----->" + path] = inputLine;
                            }
                        }
                    }
                }
                await Task.WhenAll(tasks);
                foreach (var wordStat in wordsStat)
                {
                    Console.WriteLine("{0}   {1}", wordStat.Key, wordStat.Value);
                }
            }

            finally
            {
                foreach (FileStream sourceStream in sourceStreams)
                {
                    sourceStream.Close();
                }

            }
        }
    }
}
