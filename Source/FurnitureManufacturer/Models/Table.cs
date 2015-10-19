namespace FurnitureManufacturer.Models
{
    using System;

    using Interfaces;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;

        public Table(string model, string material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ModelsConstants.LengthWidthHeightError, "Length"));
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ModelsConstants.LengthWidthHeightError, "Width"));
                }

                this.width = value;
            }
        }

        // Can calculate area by the following formula: length * width
        public decimal Area
        {
            get { return this.Length * this.Width; }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, {1}, Length: {2}, Width: {3}, Area: {4}",
                this.GetType().Name, base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
