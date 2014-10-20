using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBo
{
	public class Cart
	{
		private readonly IList<Product> products;
		private readonly IList<Promotion> promotions;

		public Cart()
		{
			products = new List<Product>();
			this.promotions = new List<Promotion>();
		}

		public Cart(IList<Promotion> promotions)
		{
			this.promotions = promotions;
			products = new List<Product>();
		}

		public decimal GetPrice()
		{
			var promotionPrice = 0m;
			var productsToCalculate = new List<Product>(products);
			foreach(var promotion in this.promotions)
			{
				promotionPrice += promotion.GetPrice(productsToCalculate);
			}
			return productsToCalculate.Sum(p => p.Price) + promotionPrice;
		}

		public IList<Product> GetProducts()
		{
			return products;
		}

		public void AddProduct(Product product)
		{
			products.Add(product);
		}

	}
}
