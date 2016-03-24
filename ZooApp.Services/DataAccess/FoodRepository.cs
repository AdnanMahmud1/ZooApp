using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.Services.DataAccess
{
    public class FoodRepository:GenericRepository<ZooContext,Food>,IFoodRepository
    {
        public Food GetFood(int id)
        {
            return Context.Foods.FirstOrDefault(x => x.Id == id);
        }
    }
}