using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KatlaSport.Repository.Models;
//using KatlaSport.Repository.ViewModels;

namespace KatlaSport.Repository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISportNutritionClientRepository _sportNutritionClientRepository;

        public HomeController(ISportNutritionClientRepository sportNutritionClientRepository)
        {
            //_sportNutritionClientRepository = new MockSportNutritionClientRepository;
            _sportNutritionClientRepository = sportNutritionClientRepository;
        }
        public ViewResult Index()
        {
            var model = _sportNutritionClientRepository.GetAllSportNutritionClients();
            return View(model);
         }

        //public ViewResult Details(int? id)
        //{
            //HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            //{

            //    SportNutritionClient = _sportNutritionClientRepository.GetSportNutritionClient(id ?? 1),
            //    PageTitle = "Sport Nutrition Clients Details"
            //};

            //return View(homeDetailsViewModel);
            //return Json(model)
        //}

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(SportNutritionClient sportNutritionClient)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        SportNutritionClient newSportNutritionClient = _sportNutritionClientRepository.AddSportNutritionClient(sportNutritionClient);
        //        //return RedirectToAction("details", new {id = new { id = newSportNutritionClient.Id});
        //    }
        //}
    }
}
