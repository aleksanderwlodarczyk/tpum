using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopData;

namespace ShopLogic
{
    internal class Shop : IShop, IObserver<IFruit>
    {
        private IWarehouse warehouse;
        private IPromotionManager promotionManager;
        private IDisposable unsubscriber;
        public Shop(IWarehouse warehouse)
        {
            this.warehouse = warehouse;
            promotionManager = new PromotionManager(warehouse);
            warehouse.PriceChanged += OnPriceChanged;
            warehouse.Subscribe(this);
        }

        public bool Sell(List<IFruitDTO> fruitDTOs)
        {
            List<Guid> guids = new List<Guid>();

            foreach (FruitDTO fruitDTO in fruitDTOs)
            {
                guids.Add(fruitDTO.ID);
            }

            List<IFruit> fruits = warehouse.GetFruitsWithIDs(guids);

            warehouse.RemoveFruits(fruits);

            return true;
        }

        public async Task SendMessageAsync(string message)
        {
            await warehouse.SendAsync(message);
        }

        public List<IFruitDTO> GetAvailableFruits(bool withPromotion = true)
        {
            Tuple<Guid, float> promotion = new Tuple<Guid, float>(Guid.Empty, 1f);
            if (withPromotion)
            {
                promotion = promotionManager.GetCurrentPromotion();
            }

            List<IFruitDTO> result = new List<IFruitDTO>();

            foreach (IFruit fruit in warehouse.Stock)
            {
                //float price = fruit.Price;
                //if (fruit.ID.Equals(promotion.Item1))
                //    price *= promotion.Item2;
                var dto = new FruitDTO();
                dto.Price = fruit.Price;
                dto.ID = fruit.ID;
                dto.Name = fruit.Name;
                dto.FruitType = fruit.FruitType.ToString();
                dto.Origin = fruit.Origin.ToString();
                result.Add(dto);
            }

            return result;
        }

        public event EventHandler<PriceChangeEventArgs> PriceChanged;
        public event EventHandler<IFruitDTO> OnFruitChanged;
        public event EventHandler<IFruitDTO> OnFruitRemoved;


        private void OnPriceChanged(object sender, ShopData.PriceChangeEventArgs e)
        {
            EventHandler<PriceChangeEventArgs> handler = PriceChanged;
            handler?.Invoke(this, new ShopLogic.PriceChangeEventArgs(e.Id, e.Price));
        }

        public void OnCompleted()
        {
            this.Unsunscribe();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(IFruit value)
        {
            var dto = new FruitDTO();
            dto.Price = value.Price;
            dto.ID = value.ID;
            dto.Name = value.Name;
            dto.FruitType = value.FruitType.ToString();
            dto.Origin = value.Origin.ToString();

            if (value.Price < -0.01f && value.Name == "" && value.FruitType == FruitType.Deleted && value.Origin == CountryOfOrigin.Deleted)
                OnFruitRemoved?.Invoke(this, dto);
            else
                OnFruitChanged?.Invoke(this, dto);
        }

        private void Unsunscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
