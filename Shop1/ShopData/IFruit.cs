using System;

namespace ShopData
{
    public interface IFruit
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; }
        public CountryOfOrigin Origin { get; set; }
        public FruitType FruitType { get; set; }
    }
}