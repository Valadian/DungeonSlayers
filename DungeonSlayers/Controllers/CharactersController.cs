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
using DungeonSlayers.Utils;
using DungeonSlayers.Extensions;
using System.Collections;
using System.Reflection;
using RefactorThis.GraphDiff;

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
            var character = new Character().Initialize(db);
            AddChoicesToViewBag(ViewBag, character);
            character.Owner = db.Users.Where(u => u.UserName == User.Identity.Name).First();
            ViewBag.PropertyDefs = db.PropertyDefs;
            return View();
        }
        private void AddChoicesToViewBag(dynamic ViewBag, Character character = null)
        {
            ViewBag.OwnerChoices = db.Users.AsChoices();
            ViewBag.RaceChoices = db.DefaultRaces.AsChoices(valueStrings: true);
            ViewBag.ClassChoices = db.Classes.AsChoices(valueStrings: true);
            ViewBag.RacialAbilitiesChoices = db.RacialAbilities.AsChoices();
            ViewBag.RacialAbilities = db.RacialAbilities.ToList();
            ViewBag.HeroClasses = db.HeroClasses.AsChoices(valueStrings: true);
            ViewBag.GenderChoices = SelectListUtil.Of<Gender>(true);
            ViewBag.WeaponChoices = db.Weapons.AsChoices();
            ViewBag.Weapons = db.Weapons.ToList();
            ViewBag.ArmorChoices = db.Armors.AsChoices();
            ViewBag.Armors = db.Armors.ToList();
            if (character != null)
            {
                IEnumerable<Spell> spells = null;
                switch (character.ClassName)
                {
                    case "Healer":
                        spells = db.Spells.Where(s => s.HealerLevel <= character.Level).ToList();
                        break;
                    case "Wizard":
                        spells = db.Spells.Where(s => s.WizardLevel <= character.Level).ToList();
                        break;
                    case "Sorcerer":
                        spells = db.Spells.Where(s => s.SorcererLevel <= character.Level).ToList();
                        break;
                }
                ViewBag.SpellChoices = spells.AsChoices();
            } else
            {
                ViewBag.SpellChoices = db.Spells.AsChoices();
            }
            ViewBag.Spells = db.Spells.ToList();
            ViewBag.EquipmentChoices = db.Equipment.OrderBy(e => e.Name).AsChoices();
            ViewBag.Equipments = db.Equipment.ToList();
            ViewBag.SelfTypes = new []{ "Weapon","Armor","Spell","Equipment"};
            ViewBag.Checks = db.Checks.ToList();
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
            AddChoicesToViewBag(ViewBag,character);
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
        [MyValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Race,Level,PP,TP,ClassName,HeroClassName,ExperiencePoints,Size,Gender,PlaceOfBirth,DateOfBirth,Age,Height,Weight,HairColor,EyeColor,Special,Languages,Alphabets,Name,Note,BOD,MOB,MND,ST,AG,IN,CO,DX,AU,Gold,Silver,Copper,RacialAbilities,Weapons,Armors,Spells,Equipments")] Character character)
        {
            if (ModelState.IsValid)
            {
                //Character old_character = await db.Characters.AsNoTracking().Where(c => c.Id == character.Id).SingleAsync();
                //SyncList(character, old_character, c => c.Weapons, cw => cw.Weapon);
                //SyncList(character, old_character, c => c.Armors, ca => ca.Armor);
                //SyncList(character, old_character, c => c.Spells, ca => ca.Spell);
                //SyncList(character, old_character, c => c.Equipments, ca => ca.Equipment);
                //db.Entry(old_character).State = EntityState.Detached;
                //db.Characters.Attach(character);
                //PurgeListsOfDestroyed(character);
                db.UpdateGraph(character, map => map
                    .OwnedCollection(c => c.RacialAbilities)
                    .OwnedCollection(c => c.Weapons)
                    .OwnedCollection(c => c.Armors)
                    .OwnedCollection(c => c.Spells)
                    .OwnedCollection(c => c.Equipments)
                    );
                //db.Entry(character).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(character);
        }
        public void PurgeListsOfDestroyed(Identifiable entity)
        {
            foreach(var listPropInfo in entity.GetType().GetProperties())
            {
                //var generic = listPropInfo.PropertyType.GenericTypeArguments.Length == 1;
                //var listOfKoEntity = typeof(KoEntity).IsAssignableFrom(listPropInfo.PropertyType.GenericTypeArguments[0]);
                //if (listPropInfo.PropertyType.IsAssignableFrom(typeof(ICollection<KoEntity>)))
                if(IsKoEntityEnumerable(listPropInfo.PropertyType))
                {
                    //var list = (listPropInfo.GetValue(entity) as IList).Cast<KoEntity>().ToList();
                    //list.Where(e => e._destroy).ToList().ForEach(e => { db.Entry(e).State = EntityState.Deleted; list.Remove(e); });
                    //list.Where(e => e._new).ToList().ForEach(e => db.Entry(e).State = EntityState.Added);
                    //listPropInfo.SetValue(entity, list);
                    var list = (listPropInfo.GetValue(entity) as IList);
                    var size = list.Count;
                    foreach (var i in Enumerable.Range(0, list.Count))
                    {
                        var item = list[size - 1 - i] as KoEntity;
                        if (item._destroy) {
                            list.Remove(item);
                            if (!item._new) {
                                db.Entry(item).State = EntityState.Deleted;
                            }
                        } else if (item._new) {
                            db.Entry(item).State = EntityState.Added;
                        } else {
                            db.Entry(item).State = EntityState.Modified;
                        }
                    }
                }
            }
        }
        public bool IsKoEntityEnumerable(Type type)
        {
            return type.GetInterfaces().Any(x => x.IsGenericType && 
                        x.GetGenericTypeDefinition() == typeof(IEnumerable<>) &&
                        x.GetGenericArguments().Length == 1 &&
                        typeof(KoEntity).IsAssignableFrom(x.GetGenericArguments()[0]));
        }
        public void SyncList<T,U,V>(T newObj, T oldObj, Func<T,ICollection<U>> selector, Func<U, V> relatedNoCascade) where T : Identifiable where U: class where V: class
        {
            var deleted = selector(oldObj).Except(selector(newObj)).ToList();
            var added = selector(newObj).Except(selector(oldObj)).Distinct().ToList();
            deleted.ForEach(w => selector(oldObj).Remove(w));
            foreach (var thing in added)
            {
                if (db.Entry(thing).State == EntityState.Detached)
                {
                    db.Entry(thing).State = EntityState.Added;
                    db.Entry(relatedNoCascade(thing)).State = EntityState.Unchanged;
                }
            }
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
