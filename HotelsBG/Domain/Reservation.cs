﻿using HotelsBG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsBG.Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime ReservationDate {get;set;} 
        public DateTime AccommodationDate { get; set; }
        public DateTime LeavingDate { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set;}
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
       

    }
}
