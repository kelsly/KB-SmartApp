using NMCT.Resto.CoreM.Model;
using NMCT.Resto.CoreM.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NMCT.Resto.CoreM.Services
{
    public class RestoDataService : IRestoDataService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IReviewRepository _reviewRepository;

        public RestoDataService(IRestaurantRepository restaurantRepository, IReviewRepository reviewRepository)
        {
            this._restaurantRepository = restaurantRepository;
            this._reviewRepository = reviewRepository;
        }

        public async Task<bool> AddReview(Guid restoId, Review review)
        {
            var check = await _reviewRepository.PostReview(restoId, review);
            return true;
        }

        public async Task<Restaurant> GetRandomRestaurant()
        {
            List<Restaurant> restaurant = await GetRestaurants();
            Random rnd = new Random();
            int i = rnd.Next(0, restaurant.Count);
            return restaurant[i];

        }

        public async Task<Restaurant> GetRestaurantById(Guid restoId)
        {
            return await _restaurantRepository.GetRestaurantDetails(restoId);
        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            return await _restaurantRepository.GetRestaurants();
        }

        public async Task<List<Review>> GetReviews(Guid restoId)
        {
            return await _reviewRepository.GetReviews(restoId);
        }
    }
}
