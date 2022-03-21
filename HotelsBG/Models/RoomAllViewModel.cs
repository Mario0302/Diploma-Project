using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models
{
    public class RoomAllViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "RoomName")]
        public string RoomName { get; set; }
       
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        
        [Range(50, 4000, ErrorMessage = "Price must be between 50 and 4000 ")]
        [Display(Name = "Price per day")]
        public decimal Price { get; set; }
        
        [Display(Name = "Percent discount")]
        public decimal Discount { get; set; }
        
        [Display(Name = "Number beds")]
        public decimal Number { get; set; }
        
        [Display(Name = "Exstras")]
        public string Exstras { get; set; }
    }
}
