using HotelsBG.Data;
using HotelsBG.Domain;
using HotelsBG.Models;
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
        public RoomController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Create(RoomCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                Room roomFromDb = new Room
                {
                    Id = bindingModel.Id,
                   RoomName = bindingModel.RoomName,
                    Description = bindingModel.Description,
                    Picture = bindingModel.Picture,
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

        public IActionResult All(string searchStringModel)
        {
            List<RoomAllViewModel> rooms = context.Rooms.Select(roomFromDb => new RoomAllViewModel
            {
                Id = roomFromDb.Id,
                RoomName = roomFromDb.RoomName,
                Description = roomFromDb.Description,
                Picture = roomFromDb.Picture,
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
            RoomCreateViewModel product = new RoomCreateViewModel()

            {
                Id = item.Id,
                RoomName = item.RoomName,
                Description = item.Description,
                Picture = item.Picture,
                Price = item.Price,
                Discount=item.Discount,
                NumberOfBed = item.NumberOfBed,
                Extras = item.Extras

            };
            return View(product);
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
    }
}
