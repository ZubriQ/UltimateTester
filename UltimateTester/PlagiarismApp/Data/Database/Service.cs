namespace PlagiarismApp.Data.Database
{
    public abstract class Service<T>
    {
        protected PlagiarismContext database { get; set; }

        public Service()
        {
            database = new PlagiarismContext();
        }

        public abstract Task<T[]> GetItemsAsync();
    }
}
