using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laba_1.Models;

namespace laba_1.Components
{
    public class CartViewComponent : ViewComponent
    {
        private Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            //var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            return View(_cart);
        }
    }
}

