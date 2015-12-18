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
using DungeonSlayers.Repositories;

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
            AddChoicesToViewBag(ViewBag);
            var character = new Character().Initialize(db);
            character.Owner = db.Users.Where(u => u.UserName == User.Identity.Name).First();
            ViewBag.PropertyDefs = db.PropertyDefs;
            return View();
        }
        private void AddChoicesToViewBag(dynamic ViewBag)
        {
            ViewBag.OwnerChoices = db.Users.AsChoices();
            ViewBag.RaceChoices = db.DefaultRaces.AsChoices(valueStrings: true);
            ViewBag.ClassChoices = db.Classes.AsChoices(valueStrings: true);
            ViewBag.RacialAbilitiesChoices = db.RacialAbilities.AsChoices();
            ViewBag.HeroClasses = db.HeroClasses.AsChoices(valueStrings: true);

        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Race,Level,PP,TP,ClassName,HeroClassName,ExperiencePoints,Size,Gender,PlaceOfBirth,DateOfBirth,Age,Height,Weight,HairColor,EyeColor,Special,Languages,Alphabets,Name,Note")] Character character)
        {
            if (ModelState.IsValid)
            {
                //character.Owner = db.Users.Where(u => u.UserName==User.Identity.Name).First();
                character.DateOfBirth = DateTime.Now;
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
            AddChoicesToViewBag(ViewBag);
            ViewBag.PropertyDefs = db.PropertyDefs;
            return View(character);
        }
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
        public ActionResult AddWeapon()
        {
            return View(new List<CharacterWeapon>() { new CharacterWeapon() {
                Weapon = db.Weapons.Find(3)
            } });
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
