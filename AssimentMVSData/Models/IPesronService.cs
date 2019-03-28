using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSData.Models
{
    public interface IPesronService
    {
        Person CreatePerson(string name, string city , int phone);

        List<Person> AllPersons();

        Person FindPerson(int id);

        List<Person> DeletePerson(int id);

        bool UpdatePerson(Person person);
    }
}
