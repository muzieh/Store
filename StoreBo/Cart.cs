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

		public Cart()
		{
			products = new List<Product>();
		}

		public decimal GetPrice()
		{
			return products.Sum(p => p.Price);
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
