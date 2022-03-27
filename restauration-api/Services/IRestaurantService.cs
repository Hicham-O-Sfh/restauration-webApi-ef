using restauration_api.Models;

namespace restauration_api.Services
{
    public interface IRestaurantService
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurants();
        public Task<Restaurant> GetRestaurant(int id);

        public Task AddRestaurant(Restaurant restaurant);

        public Task EditRestaurant(int id, Restaurant restaurant);

        public Task DeleteRestaurant(Restaurant restaurant);
    }
}
