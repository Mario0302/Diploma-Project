using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models.ReservationRoom
{
    public class ReservationAllViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReservationDate { get; set; }
        public string AccommodationDate { get; set; }
        public string LeavingDate { get; set; }
        public int RoomId { get; set; }
        //[Display(Name = "Category")]
        //public int CategoryId { get; set; }
        //public string Category { get; set; }
        public string UserId { get; set; }
        [Display(Name = "User")]
        public string User { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int DayCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
