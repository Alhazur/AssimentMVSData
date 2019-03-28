using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssimentMVSData.Models
{
    public class PersonViewModel
    {
        public List<Person> persons = new List<Person>();

        public string Filter { get; set; }
    }
}
