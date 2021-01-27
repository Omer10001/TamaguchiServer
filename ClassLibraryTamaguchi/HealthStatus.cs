using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamaguchi.Models
{
    [Table("Health Status")]
    public partial class HealthStatus
    {
        public HealthStatus()
        {
            Pets = new HashSet<Pet>();
        }

        [Key]
        [Column("StatusID")]
        public int StatusId { get; set; }
        [Required]
        [StringLength(255)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Pet.HealthStatus))]
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
