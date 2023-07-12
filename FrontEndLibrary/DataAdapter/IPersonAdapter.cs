using FrontEndLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndLibrary.DataAdapter
{
    public interface IPersonAdapter
    {
        List<PersonDetails> GetPersonDetails();
    }
}
