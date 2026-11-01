using System;
using System.Collections.Generic;
using System.Text;

namespace Session2_EntityFrameworkCore.Models
{
    public enum BadgeTier { Standard,VIP }

    internal class Badge
    {
        public int Id { get; set; }
        public string? BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }
    }
}
