using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBo
{
    public class Cart
    {
		private readonly IList<Promotion> promotions;
        public readonly IList<CartItem> Items;

		public Cart()
		{
			this.promotions = new List<Promotion>();
            this.Items = new List<CartItem>();
		}

		public Cart(IList<Promotion> promotions)
		{
			this.promotions = promotions;
            this.Items = new List<CartItem>();
		}

        public void AddProduct(Product product)
        {
            Items.Add(new QuantityCartItem(product, 1));
        }

        public void AddProductWithWeight(Product product, decimal weight)
        {
            Items.Add(new WeightCartItem(product, weight));
        }

        public decimal GetPrice()
        {
            var itemsToPrice = Items;
            foreach(var promotion in this.promotions)
            {
                promotion.GetPrice(itemsToPrice);
            }
            return Items.Sum(cartItem => cartItem.GetPrice());
            //var promotionPrice = 0m;
            //var productsToCalculate = new List<Product>(products);
            //foreach(var promotion in this.promotions)
            //{
            //    promotionPrice += promotion.GetPrice(productsToCalculate);
            //}
            //return productsToCalculate.Sum(p => p.Price) + promotionPrice;
		}

        public CartItem this[int i]
        {
            get
            {
                return Items[i];
            }
        }
    }
}
