using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Index(nameof(PetName), nameof(PlayerId), Name = "idx_PetsInfo")]
    public partial class Pet
    {
        public Pet()
        {
            PlayerMethodsHistories = new HashSet<PlayerMethodsHistory>();
            Players = new HashSet<Player>();
        }

        [Key]
        [Column("PetID")]
        public int PetId { get; set; }
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(255)]
        public string PetName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }
        public int PetWeight { get; set; }
        public int Age { get; set; }
        public int HungerLevel { get; set; }
        public int CleanLevel { get; set; }
        public int HappinessLevel { get; set; }
        [Column("HealthStatusID")]
        public int HealthStatusId { get; set; }
        [Column("LifeCycleStageID")]
        public int LifeCycleStageId { get; set; }

        [ForeignKey(nameof(HealthStatusId))]
        [InverseProperty("Pets")]
        public virtual HealthStatus HealthStatus { get; set; }
        [ForeignKey(nameof(LifeCycleStageId))]
        [InverseProperty("Pets")]
        public virtual LifeCycleStage LifeCycleStage { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("Pets")]
        public virtual Player Player { get; set; }
        [InverseProperty(nameof(PlayerMethodsHistory.Pet))]
        public virtual ICollection<PlayerMethodsHistory> PlayerMethodsHistories { get; set; }
        [InverseProperty("CurrentPet")]
        public virtual ICollection<Player> Players { get; set; }
    }
}
