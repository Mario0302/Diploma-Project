using HotelsBG.Data;
using HotelsBG.Domain;
using HotelsBG.Models.HotelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Controllers
{
    public class HotelServiceController : Controller
    {
        private readonly ApplicationDbContext context;
        

        public HotelServiceController(ApplicationDbContext context)
        {
            this.context = context;
          
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var hotelService = new HotelServiceCreateViewModel();
           

            return this.View(hotelService);
        }
        [HttpPost]
        public IActionResult Create(HotelServiceCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
               

                HotelService serviceFromDb = new HotelService
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,
                    Price = bindingModel.Price,
                    
                };


                context.HotelServices.Add(serviceFromDb);
                context.SaveChanges();
                return this.RedirectToAction("Success");
            }
            return this.View();
        }
        public IActionResult Success()
        {
            return this.View();
        }
        [AllowAnonymous]
        public ActionResult All(string searchStringModel)
        {
            List<HotelServiceAllViewModel> hotelServices = context.Rooms.Select(hotelFromDb => new HotelServiceAllViewModel
            {
                Id = hotelFromDb.Id,
                Name = hotelFromDb.RoomName,
               
                Price = hotelFromDb.Price,
              
            }).ToList();
            if (!String.IsNullOrEmpty(searchStringModel))
            {
                hotelServices = hotelServices.Where(x => x.Name.ToLower() == searchStringModel.ToLower())
                    .ToList();
            }
            return this.View(hotelServices);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HotelService item = context.HotelServices.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            HotelServiceCreateViewModel hotelService = new HotelServiceCreateViewModel()

            {
                Id = item.Id,
                Name = item.Name,
                
                Price = item.Price,
               

            };

           
            return View(hotelService);
        }

        [HttpPost]
        public IActionResult Edit(HotelServiceCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                HotelService hotelService = new HotelService
                {
                    Id = bindingModel.Id,
                    Name = bindingModel.Name,

                    Price = bindingModel.Price,

                };
                context.HotelServices.Update(hotelService);
                context.SaveChanges();
                return this.RedirectToAction("All");
            }
            return View(bindingModel);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HotelService item = context.HotelServices.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            HotelServiceCreateViewModel hotelService = new HotelServiceCreateViewModel()

            {
                Id = item.Id,
                Name = item.Name,

                Price = item.Price,

            };
            return View(hotelService);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           var item = context.HotelServices.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.HotelServices.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All");
        }
    }
}
