using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Cart
    {
        public ObservableCollection<CartItem> Items { get; set; } = new();
    }
}
