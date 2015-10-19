namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        // Model cannot be empty, null or with less than 3 symbols
        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(string.Format(ModelsConstants.NullOrEmptyError, "Model"));
                }

                if (value.Length < 3)
                {
                    throw new ArgumentOutOfRangeException("Model cannot be less than 3 symbols!");
                }

                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(string.Format(ModelsConstants.NullOrEmptyError, "Material"));
                }

                this.material = value;
            }
        }

        // Price cannot be less or equal to $0.00
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ModelsConstants.MoneyError, "Price", "$"));
                }

                this.price = value;
            }
        }

        // Height cannot be less or equal to 0.00 m
        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ModelsConstants.LengthWidthHeightError, "Height"));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Model: {0}, Material: {1}, Price: {2}, Height: {3}",
                this.Model, this.Material, this.Price, this.Height);
        }
    }
}
