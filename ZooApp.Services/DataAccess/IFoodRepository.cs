using ZooApp.Models;

namespace ZooApp.Services.DataAccess
{
    public interface  IFoodRepository: IGenericRepository<Food>
    {
        Food GetFood(int foodId);
    }
}
