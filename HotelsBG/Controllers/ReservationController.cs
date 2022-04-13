using HotelsBG.Data;
using HotelsBG.Domain;
using HotelsBG.Models.ReservationRoom;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HotelsBG.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReservationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]

        public IActionResult Create(ReservationCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = this.context.Users.SingleOrDefault(u => u.Id == userId);
                var ev = this.context.Rooms.SingleOrDefault(e => e.Id == bindingModel.RoomId);

                if (user == null || ev == null)
                {

                    return this.RedirectToAction("All", "Room");
                }
                ReservationRoom orderForDb = new ReservationRoom
                {
                    ReservationDate = DateTime.UtcNow,
                    RoomId = bindingModel.RoomId,
                    UserId = userId,
                    AccommodationDate = bindingModel.AccommodationDate,
                    LeavingDate = bindingModel.LeavingDate,
                    //CategoryId = ev.CategoryId,


                    Price = ev.Price,
                    Discount = ev.Discount,

                    // TotalPrice = (ev.Quantity * ev.MaxPrice).ToString()
                };


                //   this.context.Rooms.Update(ev);
                this.context.Reservations.Add(orderForDb);
                this.context.SaveChanges();
            }
            return this.RedirectToAction("All", "Room");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = context.Users.SingleOrDefault(u => u.Id == userId);

            List<ReservationAllViewModel> orders = context
                 .Reservations
                 .Select(x => new ReservationAllViewModel
                 {
                     Id = x.Id,

                     //CategoryId = x.CategoryId,
                     //Category = x.Category.Name,
                     RoomId=x.RoomId,
                     ReservationDate = x.ReservationDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                     AccommodationDate = x.AccommodationDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                     LeavingDate = x.LeavingDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                     User = x.User.UserName,

                     Price = x.Price,
                     Discount = x.Discount,
                     DayCount = x.DayCount,
                     TotalPrice = x.TotalPrice,

                     // TotalPrice = (x.Count * x.MaxPrice).ToString()
                 }).ToList();

            return View(orders);
        }
        [Authorize]
        public IActionResult My(string searchString)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = this.context.Users.SingleOrDefault(u => u.Id == currentUserId);
            if (user == null)
            {
                return null;
            }

            List<ReservationAllViewModel> orders = context
                  .Reservations
                 .Where(x => x.UserId == user.Id)
            .Select(x => new ReservationAllViewModel
            {
                Id = x.Id,

                //CategoryId = x.CategoryId,
                //Category = x.Category.Name,
                ReservationDate = x.ReservationDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                AccommodationDate = x.AccommodationDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                LeavingDate = x.LeavingDate.ToString("dd-mm-yyyy hh:mm", CultureInfo.InvariantCulture),
                User = x.User.UserName,

                Price = x.Price,
                Discount = x.Discount,
                DayCount = x.DayCount,
                TotalPrice = x.TotalPrice,

                // TotalPrice = (x.Count * x.MaxPrice).ToString()
            }).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                orders = orders.Where(o => o.LeavingDate.Contains(searchString)).ToList();
            }
            return this.View(orders);
        }

    }
}
