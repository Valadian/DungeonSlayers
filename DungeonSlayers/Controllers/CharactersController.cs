using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DungeonSlayers.Models;

namespace DungeonSlayers.Controllers
{
    public class CharactersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Characters
        public async Task<ActionResult> Index()
        {
            return View(await db.Characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.OwnerChoices = new[] { "berge403", "unitive", "jacky" }.Select(s => new SelectListItem() { Text = s }); //["OwnerChoices"] = 
            ViewBag.RaceChoices = new[] { "Human", "Elf", "Dwarf", "Orc" }.Select(s => new SelectListItem() { Text = s }); //["RaceChoices"] = 
            ViewBag.ClassChoices = new[] { "Fighter", "Scout", "Healer", "Wizard", "Sorcerer" }.Select(s => new SelectListItem() { Text = s});

            ViewBag.RacialAbilitiesChoices = db.RacialAbilities.Select(ra => new SelectListItem() { Text = ra.Name });

            var groups = new Dictionary<string, SelectListGroup>()
            {
                {"Fighter", new SelectListGroup() { Name = "Fighter" }},
                {"Scout", new SelectListGroup() { Name = "Scout" }},
                {"Healer", new SelectListGroup() { Name = "Healer" }},
                {"Wizard", new SelectListGroup() { Name = "Wizard" }},
                {"Sorcerer", new SelectListGroup() { Name = "Sorcerer" }},
            };

            var heroclasses = new List<SelectListItem>();
            heroclasses.Add(new SelectListItem() { Text="Nothing selected", Value=""});
            heroclasses.AddRange(new[] { "Berserker", "Paladin", "Weapon Master" }.Select(hc => new SelectListItem() { Text = hc, Group = groups["Fighter"] }));
            heroclasses.AddRange(new[] { "Assassin", "Ranger", "Rogue" }.Select(hc => new SelectListItem() { Text = hc, Group = groups["Scout"] }));
            heroclasses.AddRange(new[] { "Cleric", "Druid", "Monk" }.Select(hc => new SelectListItem() { Text = hc, Group = groups["Healer"] }));
            heroclasses.AddRange(new[] { "Archmage", "Battle Mage", "Elementalist" }.Select(hc => new SelectListItem() { Text = hc, Group = groups["Wizard"] }));
            heroclasses.AddRange(new[] { "Blood Mage", "Demonologist", "Necromancer" }.Select(hc => new SelectListItem() { Text = hc, Group = groups["Sorcerer"] }));

            ViewBag.HeroClasses = heroclasses;
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Race,Level,PP,TP,ClassName,HeroClassName,ExperiencePoints,Size,Gender,PlaceOfBirth,DateOfBirth,Age,Height,Weight,HairColor,EyeColor,Special,Languages,Alphabets,Name,Note")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Race,Level,PP,TP,ClassName,HeroClassName,ExperiencePoints,Size,Gender,PlaceOfBirth,DateOfBirth,Age,Height,Weight,HairColor,EyeColor,Special,Languages,Alphabets,Name,Note")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Character character = await db.Characters.FindAsync(id);
            db.Characters.Remove(character);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
