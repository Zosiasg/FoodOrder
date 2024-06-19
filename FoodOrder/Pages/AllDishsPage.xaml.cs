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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_allDishViewModel.FromSearch)
        {
            await Task.Delay(100);
            searchBar.Focus();
        }
    }

    void searchBar_TextChanged(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if(!string.IsNullOrWhiteSpace(e.OldTextValue)
            && string.IsNullOrWhiteSpace(e.NewTextValue))
        {
            _allDishViewModel.SearchDishsCommand.Execute(null);
        }
    }
}
