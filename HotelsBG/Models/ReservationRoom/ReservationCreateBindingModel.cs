using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models.ReservationRoom
{
    public class ReservationCreateBindingModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int RoomId { get; set; }
     
        [Required]
        [Display(Name = "Accommodation Date")]
        public DateTime AccommodationDate { get; set; }
        [Required]
        [Display(Name = "Leaving Date")]
        public DateTime LeavingDate { get; set; }
      
               
    }
}
