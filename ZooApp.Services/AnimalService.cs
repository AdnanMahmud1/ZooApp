using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class AnimalService
    {
        ZooContext db = new ZooContext();
        public List<ViewAnimal> GetAll()
        {
            List<ViewAnimal> animals=db.Animals.AsEnumerable().Select(s=>new ViewAnimal(s)).ToList();
            //List<ViewAnimal> animals;
            //foreach (var animal in db.Animals)
            //{
            //    var viewAnimal = new ViewAnimal(animal);
            //    animals.Add(viewAnimal);
            //}

            return animals;
        }

        public ViewAnimal Get(int id)
        {
            Animal animal = db.Animals.Find(id);
            return new ViewAnimal (animal);
        }

        public bool Save(Animal animal)
        {
            var add = db.Animals.Add(animal);
            db.SaveChanges();
            return true;
        }

        public bool Update(Animal animal)
        {
            db.Entry(animal).State=EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            db.Animals.Remove(db.Animals.Find(id));
            db.SaveChanges();
            return true;
        }

        public Animal GetDbModel(int id)
        {
            return db.Animals.Find(id);
        }
    }
}
