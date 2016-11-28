using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TableBooking.Models.RestaurantModels;

namespace TableBooking.Models.ViewModels
{
    public class TableViewModel
    {
            public int TableId { get; set; }
            public int MaxPerson { get; set; }
            public ICollection<BookingPeriod> Schedule { get; set; }
    }
}
