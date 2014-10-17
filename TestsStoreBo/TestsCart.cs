using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBo;
using Xunit;

namespace TestsStoreBo
{
	public class TestsCart
	{
		[Fact]
		public void GetProduct_EmptyList_EmptyList()
		{
			var cart = new Cart();
			var productsInCart = cart.GetProducts();
			Assert.Equal(0, productsInCart.Count);
		}

		[Fact]
		public void AddProduct_OneProduct_OneReturns()
		{
			var cart = new Cart();
			cart.AddProduct(new Product() {Id = 1, Name="Cookies"});
			var productsInCart = cart.GetProducts();
			Assert.Equal(1, productsInCart.Count);
			Assert.Equal(1, productsInCart[0].Id);
		}

		[Fact]
		public void GetPrice_EmptyCart_Zero()
		{
			var cart = new Cart();
			var price = cart.GetPrice();
			Assert.Equal(0m, price);
		}

		[Fact]
		public void GetPrice_OneProduct_Price()
		{
			var cart = new Cart();
			cart.AddProduct(new Product() {
				Id = 1,
				Name = "Cookies",
				Price = 10.43m
			});

			var price = cart.GetPrice();
			Assert.Equal(10.43m, price);
		}

		[Fact]
		public void GetPrice_TwoProducts_Price()
		{
			var cart = new Cart();
			cart.AddProduct(new Product() {
				Id = 1,
				Name = "Cookies",
				Price = 10.43m
			});

			cart.AddProduct(new Product() {
				Id = 2,
				Name = "Cookies Milk",
				Price = 4.03m
			});

			var price = cart.GetPrice();
			Assert.Equal((10.43m + 4.03m), price);
		}
	}
}
