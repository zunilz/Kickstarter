using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class MySqlParameters
    {

        private List<SqlParameter> _sqlParams;


        public MySqlParameters()
        {
            _sqlParams = new List<SqlParameter>();
        }

        public void AddSqlParams(
            string paramName,
            SqlDbType sqlDbType,
            object paramValue)
        {
            if (string.IsNullOrEmpty(paramName))
            {
                throw new ArgumentException($"'{nameof(paramName)}' cannot be null or empty.", nameof(paramName));
            }

            //if (paramValue is null)
            //{
            //    throw new ArgumentNullException(nameof(paramValue));
            //}

            if (paramValue == null)
            {
                _sqlParams.Add(new SqlParameter(paramName, sqlDbType) { Value = DBNull.Value });
            }
            else
            {
                _sqlParams.Add(new SqlParameter(paramName, sqlDbType) { Value = paramValue });
            }
        }

        //public bool IsAnyParams()
        //{
        //    return _sqlParams.Any();
        //}

        public SqlParameter[] GetSqlParameters() {
        
            return _sqlParams.ToArray();

        }

        public bool AnyParamaters { get
            {
                return _sqlParams.Any();
            }
        } 
    }
}
