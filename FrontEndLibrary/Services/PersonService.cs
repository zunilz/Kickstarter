using FrontEndLibrary.DataAdapter;
using FrontEndLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndLibrary.Services
{
    public class PersonService : IPersonService
    {
        private IPersonAdapter _personAdapter { get; }
        public PersonService(IPersonAdapter personAdapter)
        {
            _personAdapter = personAdapter;
        }

 

        public List<PersonDetails> GetPersonDetails()
        {
            return _personAdapter.GetPersonDetails();
        }
    }
}
