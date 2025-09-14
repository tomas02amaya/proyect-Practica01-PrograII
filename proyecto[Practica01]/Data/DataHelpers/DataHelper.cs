using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace proyectoPractica01.Data.DataHelpers
{
    public class DataHelper
    {
        private readonly SqlConnection _connection;
        private static DataHelper _instance;
        private SqlTransaction _transaction;
        
        public DataHelper()
        {
            _connection = new SqlConnection(Propierty_Resource.CadenaDeConexionLocal);
        }


        public void Open() => _connection.Open();
        public void BeginTransaction() => _transaction = _connection.BeginTransaction();
        public void Commit() => _transaction?.Commit();
        public void Rollback() => _transaction?.Rollback();


        public SqlConnection GetConnection()
        {
            return _connection;
        }

        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }



        public int ExecuteNonQuery(string sp, List<SqlParameter> param = null)
        {
            using (var cmd = new SqlCommand(sp, _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null) cmd.Parameters.AddRange(param.ToArray());
                return cmd.ExecuteNonQuery();
            }
        }

        // Método para consultas (SELECT)
        public DataTable ExecuteSPQuery(string sp, List<SqlParameter> param = null)
        {
            var dt = new DataTable();
            using (var cmd = new SqlCommand(sp, _connection, _transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null) cmd.Parameters.AddRange(param.ToArray());
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        // Método para DML
        public int ExecuteSpDml(string sp, List<Parameter>? param, SqlTransaction transaction)
        {
            // Se asume que la conexión está abierta y la transacción ya fue iniciada por la capa superior (Unit of Work).

            using (var cmd = new SqlCommand(sp, transaction.Connection, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (param != null)
                {
                    foreach (Parameter p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
                    }
                }

                return cmd.ExecuteNonQuery();
            }
        }
    }
    
}
