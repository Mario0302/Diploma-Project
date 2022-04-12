using HotelsBG.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HotelsBG.Models;
using HotelsBG.Domain;

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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<HotelsBG.Domain.Service> Services { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<HotelsBG.Models.ClientBindingAllViewModel> ClientBindingAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.RoomCreateViewModel> RoomCreateViewModel { get; set; }
        //public DbSet<HotelsBG.Models.RoomAllViewModel> RoomAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.ReservationAllViewModel> ReservationAllViewModel { get; set; }
        //public DbSet<HotelsBG.Models.ReservationCreateViewModel> ReservationCreateViewModel { get; set; }
    }
}
