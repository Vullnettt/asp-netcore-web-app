using asp_netcore_web_app.Data;
using asp_netcore_web_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_netcore_web_app.Controllers
{
    public class CharacterController : Controller
    {
        private readonly CharacterDbContext characterDb;

        public CharacterController(CharacterDbContext characterDb)
        {
            this.characterDb = characterDb;
        }

        public IActionResult Index()
        {
            IEnumerable<Character> category = characterDb.characters;
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Character character)
        {
            if (ModelState.IsValid)
            {
                characterDb.characters.Add(character);
                characterDb.SaveChanges();
                TempData["success"] = "Character created successfully";
                return RedirectToAction("Index");

            }
            return View(characterDb);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFindDb = characterDb.characters.Find(id);
            //var firstOrDefault = haracterDb.characters.FirstOrDefault(c => c.Id == id);
            //var singleOrDefault = haracterDb.characters.SingleOrDefault(c => c.Id == id);

            if (categoryFindDb == null)
            {
                return NotFound();
            }
            return View(categoryFindDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Character character)
        {
            if (ModelState.IsValid)
            {
                characterDb.characters.Update(character);
                characterDb.SaveChanges();
                TempData["success"] = "Character updated successfully";
                return RedirectToAction("Index");

            }
            return View(characterDb);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFindDb = characterDb.characters.Find(id);

            if (categoryFindDb == null)
            {
                return NotFound();
            }
            return View(categoryFindDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = characterDb.characters.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            characterDb.characters.Remove(category);
            characterDb.SaveChanges();
            TempData["success"] = "Character deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
