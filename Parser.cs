using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tfs
{
    public class Parser
    {
        public void Parse(string singleTestRun)
        {
            var parsedObject = JObject.Parse(singleTestRun);
        }
        
    }
}
