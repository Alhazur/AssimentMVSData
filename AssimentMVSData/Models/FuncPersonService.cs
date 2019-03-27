using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSData.Models
{
    public class FuncPersonService : IPesronService
    {
        private List<Person> persons = new List<Person>();
        private int idCount = 1;

        public FuncPersonService()
        {
            persons.Add(new Person() { Name = "Max", Phone = 0729998877, City = "London" });
            persons.Add(new Person() { Name = "Lax", Phone = 0729998866, City = "Bondon" });
        }

        public List<Person> AllPersons()
        {
            return persons;
        }

        public Person CreatePerson(string name, int phone, string city)
        {
            Person person = new Person() { Id = idCount, Name = name, Phone = phone, City = city };
            idCount++;
            persons.Add(person);
            return person;
        }

        public List<Person> DeletePerson(int id)//för ta bort måste sktiva list istället annat namn
        {
            foreach (Person item in persons)
            {
                if (item.Id == id)
                {
                    persons.Remove(item);
                    break;
                }
            }
            return persons;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in persons)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool UpdatePerson(Person person)//måste finnas update method att byta namn
        {
            foreach (Person item in persons)
            {
                if (item.Id == person.Id)
                {
                    item.Name = person.Name;
                    item.Phone = person.Phone;
                    item.City = person.City;
                    return true;
                }
            }
            return false;
        }
    }
}
