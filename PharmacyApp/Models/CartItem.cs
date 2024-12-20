using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public partial class CartItem : ObservableObject
    {
        public Medication? Medication { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Total))]
        private int quantity;

        public decimal Total => Medication?.Price * Quantity ?? 0;
    }

}
