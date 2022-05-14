﻿using System;

namespace ShopServerData
{
    public class PriceChangeEventArgs : EventArgs
    {
        public PriceChangeEventArgs(Guid id, float price)
        {
            Price = price;
            Id = id;
        }
        public Guid Id { get; }
        public float Price { get; }
    }
}