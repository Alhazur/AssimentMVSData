using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSData.Models
{
    public interface IPesronService
    {
        Person CreatePerson(string name, int phone, string city);

        List<Person> AllPersons();

        Person FindPerson(int id);

        List<Person> DeletePerson(int id);
    }
}
