namespace FoodOrder.Pages;

public partial class AllDishsPage : ContentPage
{
    private readonly AllDishViewModel _allDishViewModel;
    public AllDishsPage(AllDishViewModel allDishViewModel)
    {
        InitializeComponent();
        _allDishViewModel = allDishViewModel;
        BindingContext = _allDishViewModel;
    }
}
