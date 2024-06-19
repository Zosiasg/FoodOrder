using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FoodOrder.Models
{
    public partial class Dish : ObservableObject
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

        public Dish Clone() => MemberwiseClone() as Dish;
    }
}

