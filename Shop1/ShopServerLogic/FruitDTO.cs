using System;

namespace ShopServerLogic
{
    internal class FruitDTO : IFruitDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public string Origin { get; set; }
        public string FruitType { get; set; }
    }
}