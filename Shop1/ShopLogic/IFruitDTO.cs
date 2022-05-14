using System;

namespace ShopLogic
{
    public interface IFruitDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Guid ID { get; set; }
        public string Origin { get; set; }
        public string FruitType { get; set; }
    }
}