using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public class Order
    {
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ObservableCollection<CartItem> Items { get; set; }
        public decimal? Total => Items.Sum(item => item.Total);

        public override string ToString()
        {
            string orderDetails = $"Order for {CustomerName}\n" +
                                  $"Address: {Address}\n" +
                                  $"Email: {Email}\n" +
                                  $"Phone: {Phone}\n\n" +
                                  $"Items:\n";

            foreach (var item in Items)
            {
                orderDetails += $"{item.Medication.Name} x {item.Quantity} = {item.Total:C}\n";
            }

            orderDetails += $"\nTotal: {Total:C}";
            return orderDetails;
        }
    }

}
