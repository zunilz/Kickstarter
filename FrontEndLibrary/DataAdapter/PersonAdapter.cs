using DataAccess;
using FrontEndLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndLibrary.DataAdapter
{
    public class PersonAdapter : MySqlDataAdapterBase, IPersonAdapter
    {

        public PersonAdapter(string sqlConnectionString)
            :base(sqlConnectionString)
        {
            if (sqlConnectionString is null)
            {
                throw new ArgumentNullException(nameof(sqlConnectionString));
            }
        }
        public List<PersonDetails> GetPersonDetails()
        {
            return Execute_SP_Reader("Person.GetPersonDetails",
                ProcessPersonDataFunction,
                null);
        }

        private List<PersonDetails> ProcessPersonDataFunction(SqlDataReader sqlDataReader)
        {
            if (sqlDataReader is null)
            {
                throw new ArgumentNullException(nameof(sqlDataReader));
            }

            List<PersonDetails> personDetails = new List<PersonDetails>();

            while (sqlDataReader.Read())
            {
                personDetails.Add(new PersonDetails
                {
                    //Id = ConvertType<string>(sqlDataReader["Id"]),
                    FirstName = ConvertType<string>(sqlDataReader["FirstName"]),
                    MiddleName = ConvertType<string>(sqlDataReader["MiddleName"]),
                    LastName = ConvertType<string>(sqlDataReader["LastName"]),
                    AccountNumber = ConvertType<string>(sqlDataReader["AccountNumber"]),
                    PhoneNumber = ConvertType<string>(sqlDataReader["PhoneNumber"])
                }); 
            }

            return personDetails;
        }


        public static T ConvertType<T>(object field)
        {
            return  (field != DBNull.Value) ? (T)field: default(T);
        }

    }
}
