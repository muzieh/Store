using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBo;
using Xunit;

namespace TestsStoreBo
{
	public class TestsProductStore
	{

		[Fact]
		public void ProductStore_CreateStore_Instance()
		{
			var store = new ProductStore();
			Assert.NotNull(store);
		}

		[Fact]
		public void ProductStore_AddProduct_NoErrors()
		{
			var store = new ProductStore();
			var product = new Product() { Id = 1, Name="Soup"};
			store.AddProduct(product);
		}

		[Fact]
		public void GetProductForId_StoreEmpty_Null()
		{
			var store = new ProductStore();
			Product product = store.GetProductForId(1);
			Assert.Null(product);
		}

		[Fact]
		public void GetProductForId_ProductAdded_ReturnsThatProduct()
		{
			var store = new ProductStore();
			var product = new Product() { Id = 1, Name = "Soup" };
			store.AddProduct(product); ;

			Product productReturned = store.GetProductForId(1);
			Assert.NotNull(productReturned);
			Assert.Equal(1, productReturned.Id);
		}
		
		[Fact]
		public void GetProductForId_ProductAddedTwice_LastReturned()
		{
			var store = new ProductStore();
			var product1 = new Product() { Id = 1, Name = "Soup" };
			var product2 = new Product() { Id = 1, Name = "Doughnat" };
			store.AddProduct(product1);
			store.AddProduct(product2);

			Product productReturned = store.GetProductForId(1);
			Assert.NotNull(productReturned);
			Assert.Equal("Doughnat", productReturned.Name);
		}
	}
}
