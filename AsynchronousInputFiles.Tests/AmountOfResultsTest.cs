using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsynchronousInputFiles.Tests
{
    public class AmountOfResultsTest
    {
        [Fact]
        public void TestOfResults()
        {
            //Arange
            var curWord = ConfigurationManager.AppSettings["Word"];
            var curFilePath = ConfigurationManager.AppSettings[@"Path"];
            AsyncInputFiles asyncInputFile = new AsyncInputFiles();

            //Act
            var results = asyncInputFile.ProcessWriteMult("English", @"d:\logs!\");

            //Assert
            Assert.Equal(12, results.Result.Count);
        }
    }
}
