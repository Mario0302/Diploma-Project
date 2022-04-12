using HotelsBG.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Domain
{
    public class ReservationRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public DateTime ReservationDate {get;set;} 
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set;}

       // public int ServiceId { get; set; }
       // public virtual HotelService Service { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        //public int DayCount { get { return LeavingDate - AccommodationDate; } }
        //   public decimal TotalPrice { get{ return (Price - Price * Discount / 100)*dayCount; } }

        public decimal TotalPrice { get { return Price - Price * Discount / 100; } }

    }
}
