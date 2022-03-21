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
        [Required]
        public string Description { get; set; }
        public string Picture { get; set; }
        [Required]
        [Range(50, 4000)]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal Number { get; set; }
        public string Exstras { get; set; }
    }
    }
