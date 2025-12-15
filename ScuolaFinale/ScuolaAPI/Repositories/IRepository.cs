namespace ScuolaAPI.Repositories
{
    /// <summary>
    /// Interfaccia generica per le operazioni CRUD
    /// </summary>
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
