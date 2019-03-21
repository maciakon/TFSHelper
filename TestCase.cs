using Newtonsoft.Json.Linq;

namespace tfs
{
    class TestCase
    {
        public TestCase(string title, string contaier)
        {
            Name = title;
            Assembly = contaier;
        }

        string Assembly {get; set;}
        string Name {get; set;}
    }
}