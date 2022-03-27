using Microsoft.EntityFrameworkCore;
using restauration_api.DAL;
using restauration_api.Models;

namespace restauration_api.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly DataContext _context;
        public RestaurantService(DataContext context)
        {
            _context = context;
        }

        public async Task AddRestaurant(Restaurant restaurant)
        {
            this._context.Restaurants.Add(restaurant);
            await this._context.SaveChangesAsync();
        }


        public async Task<Restaurant> GetRestaurant(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public async Task EditRestaurant(int id, Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await this._context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task DeleteRestaurant(Restaurant restaurant)
        {
            this._context.Restaurants.Remove(restaurant);
            await this._context.SaveChangesAsync();
        }

    }
}
