using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using laba_1.DAL.Entities;
using laba_1.Models;
using laba_1.Extensions;
using Microsoft.AspNetCore.Http;
using laba_1.DAL.Data;
using Microsoft.Extensions.Logging;



namespace laba_1.Controllers
{
    public class ProductController : Controller
    {
       public List<Ajax> _ajaxes;
        List<AjaxGroup> _ajaxGroups;
        ApplicationDbContext _context;
        int _pageSize; //кол-во на странице
        private ILogger _logger;

        public ProductController(ApplicationDbContext context,ILogger<ProductController>logger)
        {
            _pageSize = 3;
            //SetupData();
            _context = context;
            _logger = logger;
        }


        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int ? group,int pageNo = 1)
        {
            var groupMame = group.HasValue
                 ? _context.AjaxGroups.Find(group.Value)?.GroupName
                 : "all groups";
            _logger.LogInformation($"info: group={groupMame}, page ={ pageNo}");
            // Поместить список групп во ViewData
            var ajaxesFiltered = _context.Ajaxes
                .Where(d => !group.HasValue || d.AjaxGroupId == group.Value);

            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.AjaxGroups;

            // Получить id текущей группы и поместить в TempData
            var currentGroup = 0;
            int.TryParse(HttpContext .Request.Query["group"], out currentGroup);
            TempData["CurrentGroup"] = currentGroup;
            //var items = _ajaxes
            //    .Skip((pageNo - 1) * _pageSize)
            //    .Take(_pageSize)
            //    .ToList();
           if (Request.IsAjaxRequest())
               return PartialView("_ListPartial", ListViewModel<Ajax>.GetModel(ajaxesFiltered, pageNo, _pageSize));
            return View(ListViewModel<Ajax>.GetModel(ajaxesFiltered, pageNo, _pageSize));
            //return View(items);

        }
        /// <summary>
        /// Инициализация списков
        /// </summary>

        private void SetupData()
        {
            _ajaxGroups = new List<AjaxGroup>
            {
                new AjaxGroup{AjaxGroupId=1, GroupName="Контроллеры"},
                new AjaxGroup{AjaxGroupId=2, GroupName="Датчики пожарные"},
                new AjaxGroup{AjaxGroupId=3, GroupName="Датчики охранные"},
                new AjaxGroup{AjaxGroupId=4, GroupName="Датчики водяные"},
                new AjaxGroup{AjaxGroupId=5, GroupName="Рэлле"},
                new AjaxGroup{AjaxGroupId=6, GroupName="Средства оповещения"}

            };

            _ajaxes = new List<Ajax>
            {
                new Ajax{DivicesID=1,DivicesName="Контроллер",Description="Wi-fi",
                detection=2000,AjaxGroupId=1,Image="AjaxHub-1-456x340-1-456x340.png"},
                new Ajax{DivicesID=2,DivicesName="Охранный датчик",Description="Wi-fi",
                detection=200,AjaxGroupId=3,Image="door_big.png"},
                new Ajax{DivicesID=3,DivicesName="Рэлле",Description="Wi-fi",
                detection=200,AjaxGroupId=5,Image="ff34-456x340.png"},
                new Ajax{DivicesID=4,DivicesName="Клавиатура",Description="Wi-fi",
                detection=200,AjaxGroupId=6,Image="keypad_big.png"},
                new Ajax{DivicesID=5,DivicesName="Пожарный датчик",Description="Wi-fi",
                detection=200,AjaxGroupId=2,Image="MP_Big.png"},
                new Ajax{DivicesID=6,DivicesName="Сирена",Description="Wi-fi",
                detection=200,AjaxGroupId=2,Image="streetsiren_big-456x340.png"}

            };
        }
    }
}