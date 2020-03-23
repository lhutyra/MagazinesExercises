using System;

namespace Magazines.Lib
{
    public class MaterialQuantity
    {
        public Material Material { get; }
        public int Quantity { get; set; }
        private MaterialQuantity(Material material, int quantity)
        {
            this.Material = material;
            this.Quantity = quantity;
        }

        public static MaterialQuantity From(Material material, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InvalidOperationException("Quantity cannot be negative");
            }
            return new MaterialQuantity(material, quantity);
        }


    }
}
