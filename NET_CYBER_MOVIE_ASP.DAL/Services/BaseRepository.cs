using DemoASPMVC_DAL.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoASPMVC_DAL.Services
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel>
    {
        protected readonly IDbConnection _connection;

        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        protected abstract TModel Mapper(IDataReader reader);

        public virtual IEnumerable<TModel> GetAll(string tablename)
        {
            List<TModel> list = new List<TModel>();


            using (IDbCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM " + tablename;
                cmd.CommandText = sql;
                _connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(Mapper(reader));
                    }
                }
                _connection.Close();
            }
            return list;
        }

        public virtual TModel GetById(string tablename, int id)
        {


            using (IDbCommand cmd = _connection.CreateCommand())
            {
                string sql = "SELECT * FROM " + tablename + " WHERE Id = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.CommandText = sql;
                _connection.Open();
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return Mapper(reader);
                }
            }

        }

        public virtual void Delete(string tablename, int id)
        {

            using (IDbCommand cmd = _connection.CreateCommand())
            {
                string sql = $"DELETE FROM {tablename} WHERE Id = @id";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.CommandText = sql;
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
           
        }
    }
}
