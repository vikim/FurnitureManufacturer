namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private readonly ICollection<IFurniture> furnitures = new Collection<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            //this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            // Name cannot be empty, null or with less than 5 symbols.
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty!");
                }

                if (value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be less than 5 symbols!");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            // Registration number must be exactly 10 symbols and must contain only digits.
            private set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be exactly 10 symbols!");
                }

                if (!IsDigitsOnly(value))
                {
                    throw new ArgumentException("Registration number must contain only digits!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        // Adding duplicate furniture is allowed.
        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        // Removing furniture removes the first occurance. If such is not found, nothing happens.
        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        // Finding furniture by model gets the first occurance. If such is not found, return null. Searching is case insensitive.
        public IFurniture Find(string model)
        {
            var result = this.Furnitures.FirstOrDefault(f => f.Model.ToLower() == model.ToLower());
            return result;
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            catalog.Append(string.Format("{0} - {1} - {2} {3}", this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"));

            ICollection<IFurniture> orderedFurnitures = new Collection<IFurniture>(this.Furnitures.ToList());

            orderedFurnitures = orderedFurnitures
                 .OrderBy(f => f.Price)
                 .ThenBy(f => f.Model)
                 .ToList();

            foreach (var furniture in orderedFurnitures)
            {
                catalog.AppendLine();
                catalog.Append(furniture.ToString());
            }

            return catalog.ToString();
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
