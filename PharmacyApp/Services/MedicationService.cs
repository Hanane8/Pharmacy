using PharmacyApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Services
{
    public class MedicationService
    {
        public ObservableCollection<Category> Categories { get; private set; }
        public ObservableCollection<Medication> Medications { get; private set; }
        public Cart Cart { get; private set; }

        public MedicationService()
        {
            // Initialisera kategorier
            Categories = new ObservableCollection<Category>
            {
                new Category { Name = "Painkillers", Image = "painkillers.jpg" },
                new Category { Name = "Antibiotics", Image = "antibiotics.jpg" },
                new Category { Name = "Vitamins", Image = "vitamins.jpg" }
            };

            // Initialisera läkemedel
            Medications = new ObservableCollection<Medication>
            {
                // Painkillers
                new Medication { Name = "Paracetamol", Description = "Pain reliever", Price = 49.99M, Category = "Painkillers", Image = "paracetamol.jpg" },
                new Medication { Name = "Ibuprofen", Description = "Anti-inflammatory", Price = 59.99M, Category = "Painkillers", Image = "ibuprofen.jpg" },
                new Medication { Name = "Aspirin", Description = "Pain reliever and blood thinner", Price = 39.99M, Category = "Painkillers", Image = "aspirin.jpg" },

                // Antibiotics
                new Medication {Name = "Amoxicillin", Description = "Antibiotic", Price = 99.99M, Category = "Antibiotics", Image = "amoxicillin.jpg" },
                new Medication {Name = "Ciprofloxacin", Description = "Broad-spectrum antibiotic", Price = 89.99M, Category = "Antibiotics", Image = "ciprofloxacin.jpg" },
                new Medication {Name = "Doxycycline", Description = "Antibiotic for bacterial infections", Price = 79.99M, Category = "Antibiotics", Image = "doxycycline.jpg" },

                // Vitamins
                new Medication {Name = "Vitamin C", Description = "Boosts immune system", Price = 29.99M, Category = "Vitamins", Image = "vitamin_c.jpg" },
                new Medication {Name = "Vitamin D", Description = "Supports bone health", Price = 34.99M, Category = "Vitamins", Image = "vitamin_d.jpg" },
                new Medication {Name = "Multivitamins", Description = "Daily health supplement", Price = 49.99M, Category = "Vitamins", Image = "multivitamins.jpg" }
            };

            // Initialisera varukorg
            Cart = new Cart();
        }

        public ObservableCollection<Medication> GetMedicationsByCategory(string categoryName)
        {
            var medications = Medications.Where(m => m.Category == categoryName).ToList();
            return new ObservableCollection<Medication>(medications);
        }

        public Medication GetMedicationByName(string name)
        {
            return Medications.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

       


    }
}
