using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using laba_1.Models;

namespace laba_1.Components
{
    public class Menu : ViewComponent
    {

        // Инициализация списка элементов меню
        private List<MenuItem> _menuItems = new List<MenuItem>
        {
            new MenuItem{ Controller="Home",Action="Index",Text="Lab 2"},
            new MenuItem{Controller="Product",Action="Index",Text="Каталог1"},
            new MenuItem{IsPage=true, Area="Admin",Page="/Index",Text="Администрирование"},
            new MenuItem{IsPage=true,Area="ApiDemo",Page="/Index", Text="API-demo"}
        };


        public IViewComponentResult Invoke()
        {
            // Получение значений сегментов маршрута
            var controller = ViewContext.RouteData.Values["controller"];
            var page = ViewContext.RouteData.Values["page"];
            var area = ViewContext.RouteData.Values["area"];
        

            foreach(var item in _menuItems)
            {
                //Название контроллера совпадает?
                var _matchController = controller?.Equals(item.Controller)
                    ?? false;
                //Название зоны совпадает?
                var _matchArea = area?.Equals(item.Area) ?? false;
                // Если есть совпадени, то сделать этот элемент меню активным
                //(применить соответствующий класс CSS)
                if(_matchController || _matchArea)
                {
                    item.Active = "active";
                }
        
            }
            return View(_menuItems);

        }


        
    }



}
