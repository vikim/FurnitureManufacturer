namespace FurnitureManufacturer.Models
{
    using System;

    using FurnitureManufacturer.Interfaces;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format(ModelsConstants.NumberError, "Number of legs"));
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, {1}, Legs: {2}",
               this.GetType().Name, base.ToString(), this.NumberOfLegs);
        }
    }
}
