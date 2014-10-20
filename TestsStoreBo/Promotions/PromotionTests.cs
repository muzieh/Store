using System;
using System.Linq;
using StoreBo;
using Xunit;

namespace TestsStoreBo.Promotions
{
	public class PromotionTests
	{
		[Fact]
		public void ThreeSameGetOneFree_TwoInCart_PriceFor2()
		{
			var p = new Product() { Id = 1, Name = "chocolate", Price = 12.1m};
			var c = new Cart();
			c.AddProduct(p);
			c.AddProduct(p);
			var price = c.GetPrice();
			Assert.Equal(24.2m, price);	
		}

		public void ThreeSameGetOneFree_ThreeSameInCart_PriceFor2()
		{
			var p = new Product() { Id = 1, Name = "chocolate", Price = 12.1m};
			var c = new Cart();
			c.AddProduct(p);
			c.AddProduct(p);
			c.AddProduct(p);
			var price = c.GetPrice();
			Assert.Equal(24.2m, price);	
		}

	}
}
