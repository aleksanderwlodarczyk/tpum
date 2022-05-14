namespace ShopServerLogic
{
    public interface IBasket
    {
        public bool AddFruit(IFruitDTO fruit);
        public bool RemoveFruit(IFruitDTO fruit);
    }
}