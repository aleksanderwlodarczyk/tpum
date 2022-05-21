using System;
using ShopServerLogic;

namespace ShopServerPresentation
{
    internal class FruitDTO : IFruitDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public int Origin { get; set; }
        public int FruitType { get; set; }

        public FruitDTO(string name, float price, Guid id, int origin, int fruitType)
        {
            Name = name;
            Price = price;
            Origin = origin;
            ID = id;
            FruitType = fruitType;
        }
    }
}