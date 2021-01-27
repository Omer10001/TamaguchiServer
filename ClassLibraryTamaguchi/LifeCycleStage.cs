using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamaguchi.Models
{
    [Table("Life Cycle Stage")]
    public partial class LifeCycleStage
    {
        public LifeCycleStage()
        {
            Pets = new HashSet<Pet>();
            PlayerMethodsHistories = new HashSet<PlayerMethodsHistory>();
        }

        [Key]
        [Column("StageID")]
        public int StageId { get; set; }
        [Required]
        [StringLength(255)]
        public string StageName { get; set; }
        public int TimeInStage { get; set; }

        [InverseProperty(nameof(Pet.LifeCycleStage))]
        public virtual ICollection<Pet> Pets { get; set; }
        [InverseProperty(nameof(PlayerMethodsHistory.PetLifeCycleStage))]
        public virtual ICollection<PlayerMethodsHistory> PlayerMethodsHistories { get; set; }
    }
}
