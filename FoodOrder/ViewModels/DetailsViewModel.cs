using System;


namespace FoodOrder.ViewModels
{
    [QueryProperty(nameof(Dish), nameof(Dish))]
    public partial class DetailsViewModel : ObservableObject, IDisposable
    {
        private readonly CartViewModel _cartViewModel;
        public DetailsViewModel(CartViewModel cartViewModel)
        {
            _cartViewModel = cartViewModel;

            _cartViewModel.CartCleared += OnCartCleared;
            _cartViewModel.CartItemRemoved += OnCartItemRemoved;
            _cartViewModel.CartItemUpdated += OnCartItemUpdated;
        }

        private void OnCartCleared(object? _, EventArgs e) => Dish.CartQuantity = 0;

        private void OnCartItemRemoved(object? _, Dish p) =>
            OnCartItemChanged(p, 0);

        private void OnCartItemUpdated(object? _, Dish p) =>
            OnCartItemChanged(p, p.CartQuantity);

        private void OnCartItemChanged(Dish p, int quantity)
        {
            if(p.Name == Dish.Name)
            {
                Dish.CartQuantity = quantity;
            }
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

        public void Dispose()
        {
            _cartViewModel.CartCleared -= OnCartCleared;
            _cartViewModel.CartItemRemoved -= OnCartItemRemoved;
            _cartViewModel.CartItemUpdated -= OnCartItemUpdated;
        }
    }
}

