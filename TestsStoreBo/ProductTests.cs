using System;
using System.Linq;
using Xunit;
using StoreBo;

namespace TestsStoreBo
{
	public class ProductTests
	{
		[Fact]
		public void Product_CreateProduct_InstanceCreated()
		{
			var product = new Product(){
				Id = 1,
				Name = "Soup"
			};

			Assert.NotNull(product);
			Assert.Equal(1, product.Id);
			Assert.Equal("Soup", product.Name);
		}
	}
}
