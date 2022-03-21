using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Models
{
    public class RoomCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="RoomName")]
        public string RoomName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Range(50, 4000, ErrorMessage = "Price must be between 50 and 4000 ")]
        [Display(Name = "Price per day")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Percent discount")]
        public decimal Discount { get; set; }
        [Required]
        [Display(Name = "Number beds")]
        public decimal Number{ get; set; }
        [Required]
        [Display(Name = "Exstras")]
        public string Exstras{ get; set; }





    }
}
