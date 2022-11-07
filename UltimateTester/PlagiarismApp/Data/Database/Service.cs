namespace PlagiarismApp.Data.Database
{
    public abstract class Service<T>
    {
        protected IdentityDataContext database { get; set; }

        public Service()
        {
            database = new IdentityDataContext();
        }

        public abstract Task<T[]> GetItemsAsync();

        public abstract Task<T> GetItemAsync(int id);

        public void Add(T item)
        {
            if (item != null)
            {
                database.Add(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Attach(T item)
        {
            if (item != null)
            {
                database.Attach(item);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

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
