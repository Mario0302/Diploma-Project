using HotelsBG.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HotelsBG.Models;
using HotelsBG.Domain;
using HotelsBG.Models.ReservationRoom;
using HotelsBG.Models.HotelService;

namespace HotelsBG.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ReservationRoom> Reservations { get; set; }
        public DbSet<HotelsBG.Domain.HotelService> HotelServices { get; set; }
        public DbSet<Category> Categories { get; set; }

       // public DbSet<ReservationHotelService> ReservationHotelServices { get; set; }


        public DbSet<HotelsBG.Models.ReservationRoom.ReservationAllViewModel> ReservationAllViewModel { get; set; }

       
        public DbSet<HotelsBG.Models.HotelService.HotelServiceAllViewModel> HotelServiceAllViewModel { get; set; }

       
        public DbSet<HotelsBG.Models.HotelService.HotelServiceCreateViewModel> HotelServiceCreateViewModel { get; set; }
        //public DbSet<HotelsBG.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.RoomCreateViewModel> RoomCreateViewModel { get; set; }
        //public DbSet<HotelsBG.Models.RoomAllViewModel> RoomAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.ReservationAllViewModel> ReservationAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.ReservationCreateViewModel> ReservationCreateViewModel { get; set; }
    }
}
