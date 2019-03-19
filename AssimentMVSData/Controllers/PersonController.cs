using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssimentMVSData.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssimentMVSData.Controllers
{
    public class PersonController : Controller
    {
        IPesronService _personService;

        public PersonController(IPesronService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View(_personService.AllPersons());
        }

        [HttpPost]
        public IActionResult Index(int? id, string name, int phone, string city)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);
            }
            else
            {
                _personService.CreatePerson(name, phone, city);
            }

            return View(_personService.AllPersons());
        }
    }
}