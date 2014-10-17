using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBo
{
	public class ProductStore
	{
		private IList<Product> productList;

		public ProductStore()
		{
			productList = new List<Product>();
		}

		public Product GetProductForId(int productId)
		{
			if(productList.Count == 0)
				return null;

			return productList.Where(p => p.Id == productId).Single();
		}

		public void AddProduct(Product product)
		{
			var existingProduct = productList.Where(p => p.Id == product.Id).FirstOrDefault();
			if(existingProduct!=null)
			{
				productList.Remove(existingProduct);
			}
			productList.Add(product);
		}

		


	}
}
