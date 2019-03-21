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
        public IActionResult Index(string name, int phone, string city)
        {

            _personService.CreatePerson(name, phone, city);


            return View(_personService.AllPersons());
        }

        [HttpPost]
        public IActionResult DelPerson(int? id)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);
            }

            //return View("Index",_personService.AllPersons());
            return RedirectToAction("Index");
        }
         
        public IActionResult Person(int id) 
        {
            return PartialView("_Person", _personService.FindPerson(id));
        }
    }
}