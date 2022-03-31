using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Domain
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string RoomName { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public string Description { get; set; }
        public string Picture { get; set; }
        [Required]
        [Range(50, 4000)]
        public int Price { get; set; }
        public int Discount { get; set; }
        public int NumberOfBed { get; set; }

             public string Extras { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }
        
      
    }
    }
