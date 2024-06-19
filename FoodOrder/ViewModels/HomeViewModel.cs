﻿
namespace FoodOrder.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly DishService _DishService;
        public HomeViewModel(DishService DishService)
        {
            _DishService = DishService;
            Dishs = new(_DishService.GetPopularDishs());
        }

        public ObservableCollection<Dish> Dishs { get; set; }

        [RelayCommand]
        private async Task GoToAllDishsPage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllDishViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllDishsPage), animate: true, parameters);
        }

        [RelayCommand]
        private async Task GoToDetailsPage(Dish Dish)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Dish)] = Dish
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}

