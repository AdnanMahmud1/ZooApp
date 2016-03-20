﻿using System;
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
        public List<ViewAnimal> GetAnimals()
        {

            List<ViewAnimal> animals = db.Animals.Select(s => new ViewAnimal()
            {
                Id = s.Id,
                Quantity = s.Quantity,
                Origin = s.Origin,
                Name = s.Name,
                Food = s.Food
            }).ToList();
            return animals;
        }

        public ViewAnimal GetAnimal(int id)
        {
            Animal animal = db.Animals.Find(id);
            return new ViewAnimal { Food = animal.Food, Quantity = animal.Quantity, Origin = animal.Origin, Name = animal.Name, Id = animal.Id };
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

        public Animal GetDbAnimal(int id)
        {
            return db.Animals.Find(id);
        }
    }
}