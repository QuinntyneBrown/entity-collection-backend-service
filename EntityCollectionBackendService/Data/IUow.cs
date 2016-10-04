namespace EntityCollectionBackendService.Data
{
    public interface IUow
    {
        IRepository<Models.EntityCollection> EntityCollections { get; }
        void SaveChanges();
    }
}
