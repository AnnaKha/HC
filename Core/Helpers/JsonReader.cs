using System.IO;
using NUnit.Framework;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Core.Helpers
{
	public class JsonReader
	{
		public string ReadFromFile(string pathToFile)
		{
			var workingDerictory = TestContext.CurrentContext.TestDirectory;

			return File.ReadAllText(Path.Combine(workingDerictory, pathToFile));
		}

		public static Dictionary<string, string> testCaseValues;

		public JsonReader(string testDataNode, int testDataIndex, string pathToFile)
		{
			var workingDerictory = TestContext.CurrentContext.TestDirectory;

			using (StreamReader file = File.OpenText(Path.Combine(workingDerictory, pathToFile)))
			{
				using (JsonTextReader reader = new JsonTextReader(file))
				{
					JObject o2 = (JObject)JToken.ReadFrom(reader);
					JObject o3 = (JObject)o2.GetValue(testDataNode).ElementAt(testDataIndex);
					testCaseValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(o3.ToString());
				}
			}
		}
	}
}
