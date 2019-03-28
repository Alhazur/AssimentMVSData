using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSData.Models
{
    public class FuncPersonService : IPesronService
    {
        PersonViewModel personViewModel = new PersonViewModel();

        private int idCount = 1;

        public FuncPersonService()
        {
            CreatePerson("Max",  "London",  0729998877 );
        }

        public List<Person> AllPersons()
        {
            return personViewModel.persons;
        }

        public Person CreatePerson(string name,string city ,int phone )
        {
            Person person = new Person() { Id = idCount, Name = name, City = city, Phone = phone };
            idCount++;
            personViewModel.persons.Add(person);
            return person;
        }

        public List<Person> DeletePerson(int id)//för ta bort måste sktiva list istället annat namn
        {
            foreach (Person item in personViewModel.persons)
            {
                if (item.Id == id)
                {
                    personViewModel.persons.Remove(item);
                    break;
                }
            }
            return personViewModel.persons;
        }

        public Person FindPerson(int id)
        {
            foreach (Person item in personViewModel.persons)
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
            foreach (Person item in personViewModel.persons)
            {
                if (item.Id == person.Id)
                {
                    item.Name = person.Name;
                    item.City = person.City;
                    item.Phone = person.Phone;
                    return true;
                }
            }
            return false;
        }
    }
}
