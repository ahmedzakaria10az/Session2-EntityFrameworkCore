using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Session2_EntityFrameworkCore.Models
{
    [Table("EventOrganizers")]
    internal class Organizer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(150)]
        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }

        // One-to-One Relationship with OrganizerProfile
        public OrganizerProfile? Profile { get; set; }

        // One-to-Many
        public ICollection<Event> Events { get; set; }
            
    }
}
