using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;
using ZooApp.Services.DataAccess;
using ZooApp.ViewModels;

namespace ZooApp.Services
{
    public class FoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService()
        {
            _foodRepository=new FoodRepository();
        }
        
        public List<ViewFood> GetAll()
        {

            var animals =_foodRepository.GetAll().AsEnumerable().Select(s => new ViewFood(s)).ToList();
            return animals;
        }

        public ViewFood Get(int id)
        {
            Food food = _foodRepository.GetFood(id);
            return new ViewFood (food);
        }

        public bool Save(Food animal)
        {
           _foodRepository.Add(animal);
            _foodRepository.Save();
            return true;
        }

        public bool Update(Food animal)
        {
           _foodRepository.Update(animal);
            _foodRepository.Save();
            return true;
        }

        public bool Delete(int id)
        {
            var food = _foodRepository.GetFood(id);
            _foodRepository.Delete(food);
            _foodRepository.Save();
            return true;
        }

        public Food GetDbModel(int id)
        {
            return _foodRepository.GetFood(id);
        }
    }
}
