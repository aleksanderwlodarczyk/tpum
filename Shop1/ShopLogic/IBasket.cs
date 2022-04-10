namespace ShopLogic
{
    public interface IBasket
    {
        public bool AddFruit(FruitDTO fruit);
        public bool RemoveFruit(FruitDTO fruit);
    }
}