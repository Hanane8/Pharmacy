using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class CartItem
    {
        public Medication? Medication { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Medication?.Price * Quantity ?? 0;
    }

}
