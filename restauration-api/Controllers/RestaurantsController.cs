#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restauration_api.DAL;
using restauration_api.Models;
using restauration_api.Services;

namespace restauration_api.Controllers
{
    public class RestaurantsController : BaseApiController
    {
        private readonly DataContext _context;
        private IRestaurantService _restaurantService;

        public RestaurantsController(
            DataContext context,
             IRestaurantService restaurantService
        )
        {
            this._context = context;
            this._restaurantService = restaurantService;
        }

        [HttpGet("/Restaurants")]
        public async Task<IEnumerable<Restaurant>> Restaurants()
        {
            return await this._restaurantService.GetAllRestaurants();
        }

        [HttpGet("/Restaurants/{id}")]
        public async Task<ActionResult<Restaurant>> RestaurantById(int id)
        {
            var restaurant = await this._restaurantService.GetRestaurant(id);
            return restaurant is not null ? restaurant : NotFound();
        }


        [HttpPut("/Modifier-Restaurant/{id}")]
        public async Task EditRestaurant(int id, Restaurant restaurant)
        {
            await _restaurantService.EditRestaurant(id, restaurant);
        }

        [HttpPost("/Ajouter-Restaurant")]
        public async Task<ActionResult<Restaurant>> AjouterRestaurant(Restaurant restaurant)
        {
            await this._restaurantService.AddRestaurant(restaurant);
            return CreatedAtAction("RestaurantById", new { id = restaurant.Id }, restaurant);
        }

        [HttpDelete("/Supprimer-Restaurant/{id}")]
        public async Task SupprimerRestaurant(int id)
        {
            await this._restaurantService.DeleteRestaurant(await _context.Restaurants.FindAsync(id));
        }
    }
}
