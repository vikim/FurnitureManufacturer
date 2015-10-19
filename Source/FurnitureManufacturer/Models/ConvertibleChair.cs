namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeightState = 0.10m;
        private bool isConverted = false;
        private decimal originalHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = isConverted;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;

            if (this.IsConverted)
            {
                this.originalHeight = this.Height;
                this.Height = ConvertedHeightState;
            }
            else
            {
                this.Height = this.originalHeight;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
