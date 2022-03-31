using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models
{
    public class ReservationAllViewModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        [Display(Name = "Reservation Date")]
        public DateTime AccommodationDate { get; set; }
        [Display(Name = "Accommodation Date")]
        public DateTime LeavingDate { get; set; }
        [Display(Name = "Leaving Date")]
        public int RoomId { get; set; }
        public int ServiceId { get; set; }
    }
}
