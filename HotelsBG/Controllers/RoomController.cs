using HotelsBG.Abstraction;
using HotelsBG.Data;
using HotelsBG.Domain;
using HotelsBG.Models;
using HotelsBG.Models.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoryService _categoryService;

        public RoomController(ApplicationDbContext context, ICategoryService categoryService)
        {
            this.context = context;
            this._categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var room = new RoomCreateViewModel();
            room.Categories = _categoryService.GetCategories()
               .Select(c => new CategoryPairVM()
               {
                   Id = c.Id,
                   CategoryName = c.Name,
               })
               .ToList();

            return this.View(room);
        }
        [HttpPost]
        public IActionResult Create(RoomCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                bindingModel.Categories = _categoryService.GetCategories()
              .Select(c => new CategoryPairVM()
              {
                  Id = c.Id,
                  CategoryName = c.Name
              })
              .ToList();

                Room roomFromDb = new Room
                {
                    Id = bindingModel.Id,
                   RoomName = bindingModel.RoomName,
                    Description = bindingModel.Description,
                    Picture = bindingModel.Picture,
                    CategoryId=bindingModel.CategoryId,
                    Price = bindingModel.Price,
                    Discount = bindingModel.Discount,
                    NumberOfBed = bindingModel.NumberOfBed,
                    Extras=bindingModel.Extras
                };

              
                context.Rooms.Add(roomFromDb);
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
            List<RoomAllViewModel> rooms = context.Rooms.Select(roomFromDb => new RoomAllViewModel
            {
                Id = roomFromDb.Id,
                RoomName = roomFromDb.RoomName,
                Description = roomFromDb.Description,
                Picture = roomFromDb.Picture,
                CategoryId=roomFromDb.CategoryId,
               CategoryName= roomFromDb.Category.Name,
                Price = roomFromDb.Price,
                NumberOfBed = roomFromDb.NumberOfBed,
                Discount = roomFromDb.Discount,
                Extras=roomFromDb.Extras
            }).ToList();
            if (!String.IsNullOrEmpty(searchStringModel))
            {
                rooms = rooms.Where(x => x.RoomName.ToLower() == searchStringModel.ToLower())
                    .ToList();
            }
            return this.View(rooms);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Room item = context.Rooms.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            RoomCreateViewModel room = new RoomCreateViewModel()

            {
                Id = item.Id,
                RoomName = item.RoomName,
                Description = item.Description,
                Picture = item.Picture,
                CategoryId=item.CategoryId,
                Price = item.Price,
                Discount=item.Discount,
                NumberOfBed = item.NumberOfBed,
                Extras = item.Extras

            };

            room.Categories = _categoryService.GetCategories()
              .Select(c => new CategoryPairVM()
              {
                  Id = c.Id,
                  CategoryName = c.Name
              })
              .ToList();
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(RoomCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Room room = new Room
                {
                    Id = bindingModel.Id,
                    RoomName = bindingModel.RoomName,
                    Description = bindingModel.Description,
                    Picture = bindingModel.Picture,
                    CategoryId = bindingModel.CategoryId,
                    Price = bindingModel.Price,
                    Discount = bindingModel.Discount,
                    NumberOfBed = bindingModel.NumberOfBed,
                    Extras = bindingModel.Extras
                };
                context.Rooms.Update(room);
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
            Room item = context.Rooms.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            RoomCreateViewModel room = new RoomCreateViewModel()

            {
                Id = item.Id,
                RoomName = item.RoomName,
                Description = item.Description,
                Picture = item.Picture,
                CategoryId=item.CategoryId,
                Price = item.Price,
                Discount = item.Discount,
                NumberOfBed = item.NumberOfBed,
                Extras = item.Extras
            };
            return View(room);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Room item = context.Rooms.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            context.Rooms.Remove(item);
            context.SaveChanges();
            return this.RedirectToAction("All");
        }

        public IActionResult Statistic()
        {
            StatisticVM statistic = new StatisticVM();

            statistic.roomCount = context.Rooms.Count();
            statistic.countUsers = context.Users.Count();
            statistic.countReservations = context.Reservations.Count();
            return View(statistic);
        }
    }
}
