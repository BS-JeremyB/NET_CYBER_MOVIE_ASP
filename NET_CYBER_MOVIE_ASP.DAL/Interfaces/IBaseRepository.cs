namespace DemoASPMVC_DAL.Interface
{
    public interface IBaseRepository<TModel>
    {
        void Delete(string tablename, int id);
        IEnumerable<TModel> GetAll(string tablename);
        TModel GetById(string tablename, int id);
    }
}