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
        private static object locker = new object();
        public async Task<Dictionary<string, string>> ProcessWriteMult(string searchWord, string directory)
        {
            List<Task> tasks = new List<Task>();
            List<FileStream> sourceStreams = new List<FileStream>();
            var wordsStat = new Dictionary<string, string>();

            try
            {
                GetAllFiles getAllFiles = new GetAllFiles();
                
                // A method call that checks that the directory is not empty
                getAllFiles.CheckDirectory(directory);
                var paths = getAllFiles.FindAllFilesInDirectory(directory);
                foreach (var path in paths)
                {
                    // A method call that checks that the file is not empty
                    getAllFiles.CheckFile(path);

                    //Using FileStream without  USING
                    FileStream sourceStream = new FileStream(path,
                            FileMode.Open, FileAccess.Read, FileShare.None,
                            bufferSize: 4096, useAsync: true);

                    Task<Dictionary<string, string>> theTask = Task.Run(() =>
                    {
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
                                    lock (locker)
                                    {
                                        wordsStat[numberOfString + "----->" + path] = inputLine;
                                    }
                                }
                            }
                        }
                        return wordsStat;
                    });

                    tasks.Add(theTask);
                    sourceStreams.Add(sourceStream);
                }
                await Task.WhenAll(tasks);


            }

            //Catch exeption
            catch (Exception ex)
            {
                Console.WriteLine("The programm failed with an error.");
                Console.WriteLine(ex.ToString());
            }

            return wordsStat;
        }
    }
}
