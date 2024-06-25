
using System;
namespace FoodOrder.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {
        public event EventHandler<Dish> CartItemRemoved;
        public event EventHandler<Dish> CartItemUpdated;
        public event EventHandler CartCleared;

        public ObservableCollection<Dish> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;

        private void RecalculateTotalAmount() => TotalAmount = Items.Sum(i => i.Amount);

        [RelayCommand]
        private void UpdateCartItem(Dish Dish)
        {
            var item = Items.FirstOrDefault(i => i.Name == Dish.Name);
            if(item is not null)
            {
                item.CartQuantity = Dish.CartQuantity;
            }
            else
            {
                Items.Add(Dish.Clone());
            }
            RecalculateTotalAmount();
        }

        [RelayCommand]
        private async Task RemoveCartItem(string name)
        {
            var item = Items.FirstOrDefault(i => i.Name == name);
            if (item is not null)
            {
                Items.Remove(item);
                RecalculateTotalAmount();

                CartItemRemoved?.Invoke(this, item);

                var snackbarOptions = new SnackbarOptions
                {
                    CornerRadius = 10,
                    BackgroundColor = Colors.PaleGoldenrod
                };
                var snackbar = Snackbar.Make($"'{item.Name}' usuń z koszyka",
                    () =>
                    {
                        Items.Add(item);
                        RecalculateTotalAmount();
                        CartItemUpdated?.Invoke(this, item);
                    }, "Cofnij", TimeSpan.FromSeconds(5), snackbarOptions);

                await snackbar.Show();
            }
        }

        [RelayCommand]
        private async Task ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Potwierdz?", "Czy wyczyścić?", "Tak", "Nie"))
            {
                Items.Clear();
                RecalculateTotalAmount();
                CartCleared?.Invoke(this, EventArgs.Empty);

                await Toast.Make("Kosz wyczyszczony", ToastDuration.Short).Show();
            }
        }

        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            CartCleared?.Invoke(this, EventArgs.Empty);
            RecalculateTotalAmount();
            await Shell.Current.GoToAsync(nameof(CheckoutPage), animate: true);
        }
    }
}

