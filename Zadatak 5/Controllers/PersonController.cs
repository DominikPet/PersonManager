using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zadatak_5.Dal;

namespace Zadatak_5.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICosmosDbService service = CosmosDbServiceProvider.Service!;
        // GET: PersonController
        public async Task<ActionResult> Index()
        {
            return View(await service.GetPeopleAsync("SELECT * FROM Persons"));
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> Details(string id) => await ShowPerson(id);

        private async Task<ActionResult> ShowPerson(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var person = await service.GetPersonAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddPersonAsync(person);
                return RedirectToAction("Index");
            }
                return View(person);
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(string id) => await ShowPerson(id);

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatePersonAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: PersonController/Delete/5
        public async Task<ActionResult> Delete(string id) => await ShowPerson(id);

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Person person)
        {
                await service.DeletePersonAsync(person);
                return RedirectToAction("Index");
        }
    }
}
