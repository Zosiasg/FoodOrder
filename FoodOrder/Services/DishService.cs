using FoodOrder.Models;

namespace FoodOrder.Services
{
    public class DishService
    {
        private readonly static IEnumerable<Dish> _Dishs = new List<Dish>
        {
            new Dish
            {
                Name = "Dish 1",
                Image = "Dish1img",
                Price = 5.1
            },
            new Dish
            {
                Name = "Dish 2",
                Image = "Dish2img",
                Price = 2.5
            },
            new Dish
            {
                Name = "Dish 3",
                Image = "Dish3img",
                Price = 1.45
            },
            new Dish
            {
                Name = "Dish 4",
                Image = "Dish4img",
                Price = 3.5
            },
            new Dish
            {
                Name = "Dish 5",
                Image = "Dish5img",
                Price = 2.99
            },
            new Dish
            {
                Name = "Dish 6",
                Image = "Dish6img",
                Price = 5.1
            },
            new Dish
            {
                Name = "Dish 7",
                Image = "Dish7img",
                Price = 4.0
            },
            new Dish
            {
                Name = "Dish 8",
                Image = "Dish8img",
                Price = 9.25
            },
            new Dish
            {
                Name = "Dish 9",
                Image = "Dish9img",
                Price = 3.24
            },
            new Dish
            {
                Name = "Dish 10",
                Image = "Dish10img",
                Price = 2.9
            }
        };

        public IEnumerable<Dish> GetAllDishs() => _Dishs;

        public IEnumerable<Dish> GetPopularDishs(int count = 6) =>
            _Dishs.OrderBy(p => Guid.NewGuid())
            .Take(count);

        public IEnumerable<Dish> SearchDishs(string searchTerm) =>
            string.IsNullOrWhiteSpace(searchTerm)
            ? _Dishs
            : _Dishs.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}

