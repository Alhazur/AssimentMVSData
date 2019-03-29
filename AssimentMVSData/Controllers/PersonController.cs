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
        PersonViewModel personViewModel = new PersonViewModel();

        IPesronService _personService;//interface to indjection

        public PersonController(IPesronService personService)
        {
            _personService = personService;
        }

        public IActionResult Index()
        {
            personViewModel.persons = _personService.AllPersons();

            return View(personViewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                //måste visa ett person eftersom partial
                person = _personService.CreatePerson(person.Name, person.City, person.Phone);

                return PartialView("_Person", person);//måste visa ett person eftersom partial
            }

            return BadRequest();//det betyder lägg inget till
        }

        [HttpGet]
        public IActionResult DelPerson(int? id)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);
            }

            return Content("");//bara rensa person o inget mer
            //return View("Index",_personService.AllPersons());
            //return RedirectToAction("Index");
        }

        public IActionResult Person(Person person)
        {
            var item = _personService.FindPerson((int)person.Id);
            if (item != null)
            {

                return PartialView("_Person", item);
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult Edit(Person person)
        {
            if (person.Id == null)
            {
                return NotFound();
            }
            var item = _personService.FindPerson((int)person.Id);//cför att byta namn måste method hitta person
            if (person == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", item);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditComplete(Person person)
        {

            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);
                return PartialView("_Person", person);

            }
            return PartialView("_Edit", person);//om engenting är ändrat måste stanna i Edit
        }

        public IActionResult Filter(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return PartialView("_List", _personService.AllPersons());

            }
            else
            {

                filter = filter.ToLower();
                var vm = new PersonViewModel();//måste kalla model 
                vm.persons = _personService.AllPersons().Where(p => p.Name.ToLower().Contains(filter) || p.City.ToLower().Contains(filter)).ToList();//tolist det är convert
                return PartialView("_List", vm);
            }
        }
    }
}
