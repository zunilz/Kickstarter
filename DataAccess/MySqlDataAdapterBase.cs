using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class MySqlDataAdapterBase
    {
        private readonly string _connectionString;

        public MySqlDataAdapterBase(string sqlConnectionString)
        {
            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                throw new ArgumentException($"'{nameof(sqlConnectionString)}' cannot be null or empty.", nameof(sqlConnectionString));
            }

            _connectionString = sqlConnectionString;
        }


        protected int Execute_SP_NonQuery(string spName, MySqlParameters mySqlParameters = null)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if(mySqlParameters!=null && mySqlParameters.AnyParamaters)
                {
                    sqlCommand.Parameters.AddRange(mySqlParameters.GetSqlParameters());
                }

                connection.Open();
                return sqlCommand.ExecuteNonQuery();    
            }
        }

        protected object Execute_SP_Scalar(string spName, MySqlParameters mySqlParameters = null)
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                if (mySqlParameters != null && mySqlParameters.AnyParamaters)
                {
                    sqlCommand.Parameters.AddRange(mySqlParameters.GetSqlParameters());
                }

                connection.Open();
                return sqlCommand.ExecuteScalar();
            }
        }

        protected TData Execute_SP_Reader<TData>(
                string spName,
                Func<SqlDataReader, TData> processDataFunction,
                MySqlParameters mySqlParameters,
                int timeOut = 0
            )
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if(timeOut > 0)
                {
                    sqlCommand.CommandTimeout = timeOut;
                }

                if (mySqlParameters != null && mySqlParameters.AnyParamaters)
                {
                    sqlCommand.Parameters.AddRange(mySqlParameters.GetSqlParameters());
                }

                connection.Open();
                return processDataFunction(sqlCommand.ExecuteReader());
            }

        }

        protected TData Execute_SP_Reader_With_ReturnValue<TData>(
               string spName,
               Func<SqlDataReader, TData> processDataFunction,
               MySqlParameters mySqlParameters,
               int timeOut = 0
           )
        {

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(spName, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (timeOut > 0)
                {
                    sqlCommand.CommandTimeout = timeOut;
                }

                if (mySqlParameters != null && mySqlParameters.AnyParamaters)
                {
                    sqlCommand.Parameters.AddRange(mySqlParameters.GetSqlParameters());
                }

                sqlCommand.Parameters.Add("@returnvalue",SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                connection.Open();
                return processDataFunction(sqlCommand.ExecuteReader());
            }

        }
    }
}