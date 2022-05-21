using System;

namespace ShopServerLogic
{
    internal class FruitDTO : IFruitDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public int Origin { get; set; }
        public int FruitType { get; set; }
    }
}