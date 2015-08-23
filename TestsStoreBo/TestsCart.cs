using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreBo;
using Xunit;

namespace TestsStoreBo
{
	public class TestsCart : IDisposable
	{
        private Cart cart;
        public TestsCart()
        {
            cart = new Cart();
        }
        public void Dispose()
        {
            cart = null;
        }

        [Fact]
        public void AddProduct_OneProduct_OneReturns()
		{
			cart.AddProduct(new Product() {Id = 1, Name="Cookies"});
			var productsInCart = cart.Items;
			Assert.Equal(1, productsInCart.Count);
			Assert.Equal(1, productsInCart[0].ProductId);
		}

		[Fact]
		public void GetPrice_EmptyCart_Zero()
		{
			var price = cart.GetPrice();
			Assert.Equal(0m, price);
		}

		[Fact]
		public void GetPrice_OneProduct_Price()
		{
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


        [Fact]
        public void NewCart_CartItemsList_NotEmpty()
        {
            Assert.NotNull(cart.Items);
        }

        [Fact]
        public void Add_OneProduct_CartItemCreated()
        {
            var product = new Product() { Id = 1 };
            cart.AddProduct(product);
            Assert.Equal(product.Id, cart.Items.Where(cartItem => cartItem.ProductId == product.Id).FirstOrDefault().ProductId);
        }

        [Fact]
        public void Add_WeightedProduct_WeighSame()
        {
            var product = new Product() { Id = 3, Price = 0.99m };
            cart.AddProductWithWeight(product, 1.43m);
            var cartItem = cart.Items.First(ci => ci.ProductId == 3);
            Assert.IsType<WeightCartItem>(cartItem);
            Assert.Equal(1.43m, ((WeightCartItem)cartItem).Weight);
        }

        [Fact]
        public void Add_WeightedProduct_PriceRounded()
        {
            var product = new Product() { Id = 3, Price = 0.99m };
            cart.AddProductWithWeight(product, 1.43m);
            var cartItem = cart.Items.First(ci => ci.ProductId == 3);
            Assert.Equal(1.42m, cartItem.GetPrice());
        }


	}
}
