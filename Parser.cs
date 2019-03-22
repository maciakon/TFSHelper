using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

namespace tfs
{
    public class Parser
    {
        private const string testCaseTitleNode = "testCaseTitle";
        private const string testContainerNode = "automatedTestStorage";

        private readonly Dictionary<string, List<string>> _testsCollection;

        public Parser(Dictionary<string, List<string>> testsCollection)
        {
            _testsCollection = testsCollection;
        }

        public Dictionary<string, List<string>> Parse(string singleTestRunJson)
        {
            using (StreamReader r = new StreamReader(singleTestRunJson))
            {
                string json = r.ReadToEnd();
                JObject items = JObject.Parse(json);
                JArray values = (JArray)items["value"];

                foreach (var value in values)
                {
                    var title = value[testCaseTitleNode].ToString();
                    var container = value[testContainerNode].ToString();

                    if (_testsCollection.ContainsKey(container))
                    {
                        _testsCollection[container].Add(title);
                    }
                    else
                    {
                        _testsCollection.Add(container, new List<string> { title });
                    }
                }
            }

            return _testsCollection;
        }
    }
}
