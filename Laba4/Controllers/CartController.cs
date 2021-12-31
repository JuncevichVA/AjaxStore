using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using laba_1.DAL.Data;
using laba_1.Extensions;
using laba_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace laba_1.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private Cart _cart;

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public IActionResult Index()
        {
            //_cart = HttpContext.Session.Get<Cart>("cart");
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            //_cart = HttpContext.Session.Get<Cart>("cart");
            var item = _context.Ajaxes.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
                //HttpContext.Session.Set<Cart>("cart", _cart);
            }
            return Redirect(returnUrl);
        }

        public IActionResult Delete(int id)
        {
            _cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}