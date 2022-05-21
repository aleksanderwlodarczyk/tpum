using System;

namespace ShopServerLogic
{
    public interface IFruitDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public int Origin { get; set; }
        public int FruitType { get; set; }
    }
}