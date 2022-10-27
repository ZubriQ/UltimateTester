using F23.StringSimilarity;

namespace CodeParser.Plagiarism
{
    public class PlagiarismChecker
    {
        private Jaccard Jaccard { get; set; } = new Jaccard();

        /// <returns>Returns the similarity percentage between two strings.</returns>
        public double Compare(string code1, string code2)
        {
            return Math.Round(Jaccard.Similarity(code1, code2), 2);
        }

        /// <returns>Returns the ID of the best matching code with a similarity percentage.</returns>
        public Tuple<int, double> FindMostMatchingCode(string code, Dictionary<int, string> codes)
        {
            if (codes.Count == 0)
            {
                throw new Exception("Codes Count cannot be equals 0.");
            }

            return FindBest(code, codes);
        }

        private Tuple<int, double> FindBest(string code, Dictionary<int, string> codes)
        {
            double[] percentages = new double[codes.Count];
            Tuple<int, double> best = new Tuple<int, double>(0, 0);

            for (int i = 0; i < codes.Count; i++)
            {
                percentages[i] = Jaccard.Similarity(code, codes[i]);
                if (percentages[i] >= best.Item2)
                {
                    best = new Tuple<int, double>(i, percentages[i]);
                }
            }
            return best; // TODO: Math.Round?
        }
    }
}
