using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class WorkplaceBooking : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }        
        public int WorkplaceId { get; set; }
        public Workplace Workplace { get; set; }
        public BookingType BookingType { get; set; }
        public DateTime BookingTimeFrom { get; set; }
        public DateTime BookingTimeTo { get; set; }
        public BookingStatus BookingStatus { get; set; }

    }
}
