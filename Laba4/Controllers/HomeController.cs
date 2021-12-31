using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace laba_1.Controllers
{
    public class HomeController : Controller
    {
        private List<ListDemo> _listDemo;

        public HomeController()

        {
            _listDemo = new List<ListDemo>
            {
            new ListDemo { ListItemValue = 1, ListItemTExt = "Item 1" },
            new ListDemo { ListItemValue = 2, ListItemTExt = "Item 2" },
            new ListDemo { ListItemValue = 3, ListItemTExt = "Item 3" }
            };
        }
        
       
        public IActionResult Index()
            
        {

            ViewData["lst"]=new SelectList(_listDemo,"ListItemValue", "ListItemTExt"); //создаем колекцию SelectList на основе 
            // колекции _ListDemo

            ViewData["Text"] = "Лабораторная работа 2";
            return View();

           
        }

    }
    public class ListDemo

    {
        public int ListItemValue { get; set; }
        public string ListItemTExt { get; set; }        

    }

    

    
  


}