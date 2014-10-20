using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBo
{
	public class Promotion
	{

		public Promotion()
		{

		}

		
		public decimal GetPrice(List<Product> productsToCalculate)
		{
			var productsWithGroups = productsToCalculate.GroupBy(p => p.Id).Select(p => new {ProductId = p.Key, ProductCount = p.Count()}).Where(p => p.ProductCount > 3).ToList();
			foreach(var group in productsWithGroups)
			{

			}


		}
	}
}
