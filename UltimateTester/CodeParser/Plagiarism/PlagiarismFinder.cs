using NGrammer.NGramSets;
using NGrammer;

namespace CodeParser.Plagiarism
{
    public class PlagiarismFinder
    {
        public NGrammer<string, StringSet> CodeFinder { get; private set; } 
            
        public PlagiarismFinder()
        {
            CodeFinder = new NGrammer<string, StringSet>();
        }

        // TODO: Add AddCodeRange method?
        public void AddCode(string identifier, string code)
        {
            CodeFinder.AddTrainingSet(identifier, code);
        }

        /// <returns>Returns id of the most suitable code string.</returns>
        public string FindMostSuitableCode(string codeToFind)
        {
            string identifier = CodeFinder.Predict(codeToFind);
            return identifier;
        }
    }
}
