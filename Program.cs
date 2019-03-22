using System.Collections.Generic;

namespace tfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var allOfTheTests = new Dictionary<string, List<string>>();
            var parser = new Parser(allOfTheTests);
            var updatedTests = parser.Parse("response.json");
           
        }
    }
}
