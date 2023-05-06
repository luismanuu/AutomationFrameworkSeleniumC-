using Newtonsoft.Json;
using System.Reflection;

namespace PageObjectModel.Source.Support
{
    public class Data
    {
        public static IEnumerable<Dictionary<string, object>> GetTestData(string fileName)
        {
            string executingAssemblyPath = Assembly.GetExecutingAssembly().Location;
            string projectRootPath = Path.Combine(Path.GetDirectoryName(executingAssemblyPath) ?? "", "../../../");
            string jsonFilePath = Path.Combine(projectRootPath, "Data", fileName);
            string json = File.ReadAllText(jsonFilePath);
            var testData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
            return testData ?? new List<Dictionary<string, object>>();
        }
    }
}
