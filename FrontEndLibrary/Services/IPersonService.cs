using FrontEndLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndLibrary.Services
{
    public interface IPersonService
    {
        /// <summary>
        /// Get data
        /// </summary>
        /// <returns></returns>
        List<PersonDetails> GetPersonDetails();
    }
}
