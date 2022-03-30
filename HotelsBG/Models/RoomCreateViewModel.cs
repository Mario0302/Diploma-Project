using System;
using System.ComponentModel.DataAnnotations;

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
        public int Price { get; set; }
        [Required]
        [Display(Name = "Percent discount")]
        public int Discount { get; set; }
        [Required]
        [Display(Name = "Number beds")]
        public int NumberOfBed{ get; set; }
        [Required]
        [Display(Name = "Extras")]
        public string Extras{ get; set; }





    }
}
