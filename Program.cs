using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tfs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Parser p = new Parser();
            Dictionary<string, List<TestCase>> tests = new Dictionary<string, List<TestCase>>();
            using (StreamReader r = new StreamReader("response.json"))
            {
                string json = r.ReadToEnd();
                JObject items = JObject.Parse(json);
                JArray values = (JArray)items["value"];
                foreach (var v in values)
                {
                    var title = v["testCaseTitle"];
                    var container = v["automatedTestStorage"];
                    var tc = new TestCase(title.ToString(), container.ToString());
                }
            }   
        }
    }
}
