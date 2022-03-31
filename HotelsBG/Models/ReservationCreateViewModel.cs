using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models
{
    public class ReservationCreateViewModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        [Required]
        [Display(Name = "Reservation Date")]
        public DateTime AccommodationDate { get; set; }
        [Required]
        [Display(Name = "Accommodation Date")]
        public DateTime LeavingDate { get; set; }
        [Required]
        [Display(Name = "Leaving Date")]
        public int RoomId { get; set; }
        public int ServiceId { get; set; }
    }
}
