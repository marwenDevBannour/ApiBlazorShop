namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters, string connectionId = "SqlConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connctionId = "SqlConnection");
    }
}