using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooApp.Models;

namespace ZooApp.Services.DataAccess
{
    public interface  IFoodRepository:IGenericRepository<Food>
    {
        Food GetFood(int foodId);
    }
}
