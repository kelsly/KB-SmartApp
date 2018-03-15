using NMCT.Resto.CoreM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NMCT.Resto.CoreM.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurants();

        Task<Restaurant> GetRestaurantDetails(Guid id);
    }
}
