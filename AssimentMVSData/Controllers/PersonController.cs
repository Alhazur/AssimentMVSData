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

        IPesronService _personService;

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
                //doljen pokazat odnogo cheloveka potomychto partielview
                _personService.CreatePerson(person.Name, person.City, person.Phone);

                return PartialView("_Person", person);//doljen pokazat odnogo cheloveka potomychto partielview
            }

            return View(person);
        }

        [HttpGet]
        public IActionResult DelPerson(int? id)
        {
            if (id != null)
            {
                _personService.DeletePerson((int)id);
            }

            return Content("");
            //return View("Index",_personService.AllPersons());
            //return RedirectToAction("Index");
        }

        public IActionResult Person(Person person)
        {
            if (ModelState.IsValid)
            {
            var item = _personService.FindPerson((int)person.Id);

            return PartialView("_Person", item);
            }
            return View(person);
        }
        [HttpGet]
        public IActionResult Edit(Person person)
        {
            if (person.Id == null)
            {
                return NotFound();
            }

            var item = _personService.FindPerson((int)person.Id);
            if (person == null)
            {
                return NotFound();
            }
            return PartialView("_Edit", person);
        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditComplete(Person person)
        {

            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(person);
                return PartialView("_Edit", person);

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
