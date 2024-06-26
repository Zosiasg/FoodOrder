
namespace FoodOrder.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllDishViewModel : ObservableObject
    {
        private readonly DishService _DishService;
        public AllDishViewModel(DishService DishService)
        {
            _DishService = DishService;
            Dishs = new(_DishService.GetAllDishs());
        }
        public ObservableCollection<Dish> Dishs { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [RelayCommand]
        private async Task SearchDishs(string searchTerm)
        {
            Dishs.Clear();
            foreach (var Dish in _DishService.SearchDishs(searchTerm))
            {
                Dishs.Add(Dish);
            }
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

