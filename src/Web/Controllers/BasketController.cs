using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            // test data
            var vm = new BasketViewModel()
            {
                Id = 1,
                BuyerId = "",
                Items = new List<BasketItemViewModel>()
                {
                    new BasketItemViewModel()
                    {
                        Id = 1,
                        ProductId = 1,
                        ProductName = "LENOVO IDEAPAD C340",
                        UnitPrice = 4599,
                        PhotoPath = "TeoriV2-106778-8_small.jpg",
                        Quantity = 2
                    },
                    new BasketItemViewModel()
                    {
                        Id = 1,
                        ProductId = 2,
                        ProductName = "LENOVO YOGA C940",
                        UnitPrice = 13999,
                        PhotoPath = "TeoriV2-105261-7_small.jpg",
                        Quantity = 3
                    },
                    new BasketItemViewModel()
                    {
                        Id = 1,
                        ProductId = 3,
                        ProductName = "HP ENVY X360 13-AR0003NT",
                        UnitPrice = 7899,
                        PhotoPath = "TeoriV2-104421-2_small.jpg",
                        Quantity = 1
                    }
                }
            };

            return View(vm);
        }
    }
}
