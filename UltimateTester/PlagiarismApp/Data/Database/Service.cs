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

        public abstract void Add(T item);

        public void SaveChangesAsync()
        {
            database.SaveChangesAsync();
        }
        
        public void SaveChanges()
        {
            database.SaveChanges();
        }
    }
}
