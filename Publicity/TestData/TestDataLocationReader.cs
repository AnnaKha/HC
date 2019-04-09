using System.IO;
using NUnit.Framework;

namespace Publicity.TestData
{
    public static class TestDataLocationReader
    {
        public static string ContactTestData => File.ReadAllText(ResolveFileLocation("TestData.json"));
        
        private static string ResolveFileLocation(string fileName)
        {
            // ReSharper disable once PossibleNullReferenceException
            var fileLocation = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
            return fileLocation;
        }
    }
}