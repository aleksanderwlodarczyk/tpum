namespace ShopLogic
{
    internal interface IBasket
    {
        public bool AddFruit(IFruitDTO fruit);
        public bool RemoveFruit(IFruitDTO fruit);
    }
}