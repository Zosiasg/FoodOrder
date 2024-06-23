using FoodOrder.Models;

namespace FoodOrder.Services
{
    public class DishService
    {
        private readonly static IEnumerable<Dish> _Dishs = new List<Dish>
        {
            new Dish
            {
                Name = " Chrupiące Krewetki",
                Image = "krewetki2.png",
                Price = 31.90,
                Description = "Krewetki panierowane w panierce panko, podawane z sosem sweet chilli"
            },
            new Dish
            {
                Name = "Won Ton 🌶️",
                Image = "soup.png",
                Price = 19.90,
                Description = "Bulion z kilku rodzajów mięs, podawany z pierożkami z aksamitnego ciasta wonton, nadzianego farszem wieprzowym. Podawany z olejem czosnkowym i szczypiorkiem oraz makaronem sojowym"
            },
            new Dish
            {
                Name = "Bulion z Kaczki",
                Image = "bulionzkaczki.png",
                Price = 24.90,
                Description = "Aromatyczny bulion z kaczki, gotowany z przyprawami korzennymi. Podawany z makaronem ryżowym, plastrami kaczej piersi i prażonym czosnkiem\n"
            },
            new Dish
            {
                Name = "Tom Yum Noodles",
                Image = "noodles.png",
                Price = 31.90,
                Description = "Nasza bestsellerowa zupa Tom Yum z aromatyczną trawą cytrynową w wersji z makaronem ryżowym i orzeszkami ziemnymi"
            },
            new Dish
            {
                Name = "Tom Kha 🌶️",
                Image = "zupazkrewetkami.png",
                Price = 19.90,
                Description = "Kremowa i aksamitna zupa na bazie mleczka kokosowego z dodatkiem galangalu, trawy cytrynowej i kolendry"
            },
            new Dish
            {
                Name = "Pad thai",
                Image = "padthai.png",
                Price = 34.90,
                Description = "Tajski klasyk, nasz BESTSELLER. Makaron ryżowy z tofu, jajkiem w sosie z tamaryndowca, cukru, sosu rybnego. Podawany z limonką, orzechami arachidowymi i płatkami chilli"
            },
            new Dish
            {
                Name = "Chilli & Basil 🌶️🌶️",
                Image = "noodles.png",
                Price = 34.90,
                Description = "Makaron jajeczny smażony na woku w sosie ostrygowo-sojowym, z jajkiem, warzywami i świeżym chilli"
            },
            new Dish
            {
                Name = "Thai Style Noodles",
                Image = "makaron.png",
                Price = 34.90,
                Description = "\n34,90 zł\nŁagodniejszy brat Chili & Basil, makaron jajeczny w sosie ostrygowo-sojowym, smażony na woku z jajkiem, brokułem i innymi warzywami."
            },
            new Dish
            {
                Name = "Green Curry🌶️🌶️",
                Image = "curry.png",
                Price = 32.90,
                Description = "Aromatyczne i pikantne połączenie 100% mleczka kokosowego z green curry, podawane z bakłażanem, bazylią i innymi warzywami"
            },
            new Dish
            {
                Name = "Sweet & Sour Chicken",
                Image = "kurczak.png",
                Price = 36.90,
                Description = "Najbardziej znane dani kuchni azjatyckiej. Kurczak w sosie słodko-kwaśnym smażony na woku z warzywami. Podawane z aromatycznym ryżem jaśminowym"
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

