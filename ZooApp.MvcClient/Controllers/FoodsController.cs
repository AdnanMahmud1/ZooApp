using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooApp.Models;
using ZooApp.Services;
using ZooApp.Services.DataAccess;

namespace ZooApp.MvcClient.Controllers
{
    public class FoodsController : Controller
    {
        private FoodService foodService;

        public FoodsController()
        {
            
           foodService=new FoodService();
        }
        // GET: Foods
        public ActionResult Index()
        {
            var foods = foodService.GetAll();
            return View(foods);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Food food)
        {
            try
            {
                foodService.Save(food);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View(food);
            }
            
        }

        public ActionResult Details(int id)
        {
            var food = foodService.GetDbModel(id);
            return View(food);
        }

        public ActionResult Edit(int id)
        {
            var food = foodService.GetDbModel(id);
            return View(food);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foodService.Update(food);
                    return RedirectToAction("Details", new {id = food.Id});
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(String.Empty, "Something went worng, Message: "+exception);
                }
            }
            return View(food);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var food = foodService.GetDbModel(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Confirm(int id)
        {
            var food = foodService.GetDbModel(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            foodService.Delete(id);
            
            return RedirectToAction("Index");

        }
    }
}