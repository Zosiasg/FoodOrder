using System;


namespace FoodOrder.ViewModels
{
    [QueryProperty(nameof(Dish), nameof(Dish))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;
        }


        [ObservableProperty]
        private Dish _Dish;

        [RelayCommand]
        private void AddToCart()
        {
            Dish.CartQuantity++;
            _cartViewModel.UpdateCartItemCommand.Execute(Dish);
        }

        [RelayCommand]
        private void RemoveFromCart()
        {
            if (Dish.CartQuantity > 0)
            {
                Dish.CartQuantity--;
                _cartViewModel.UpdateCartItemCommand.Execute(Dish);
            }
        }

        [RelayCommand]
        private async Task ViewCart()
        {
            if(Dish.CartQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), animate: true);
            }
            else
            {
                await Toast.Make("Musisz dodać coś do koszyka żeby przejść dalej", ToastDuration.Short)
                    .Show();
            }
        }
    }
}

