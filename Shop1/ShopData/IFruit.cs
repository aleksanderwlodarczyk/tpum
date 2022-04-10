using System;

namespace ShopData
{
    public interface IFruit
    {
        public string Name { get; }
        public float Price { get; set; }
        public Guid ID { get; }
        public CountryOfOrigin Origin { get; }
        public FruitType FruitType { get; }
    }
}