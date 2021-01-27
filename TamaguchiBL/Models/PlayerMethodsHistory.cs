using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("Player Methods History")]
    [Index(nameof(PlayerId), nameof(PetId), nameof(ExerciseId), Name = "idx_MethodInfo")]
    public partial class PlayerMethodsHistory
    {
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [Column("PetID")]
        public int PetId { get; set; }
        [Column("ExerciseID")]
        public int ExerciseId { get; set; }
        [Key]
        [Column("MethodID")]
        public int MethodId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MethodDate { get; set; }
        public int PetAge { get; set; }
        [Column("PetLifeCycleStageID")]
        public int PetLifeCycleStageId { get; set; }

        [ForeignKey(nameof(ExerciseId))]
        [InverseProperty("PlayerMethodsHistories")]
        public virtual Exercise Exercise { get; set; }
        [ForeignKey(nameof(PetId))]
        [InverseProperty("PlayerMethodsHistories")]
        public virtual Pet Pet { get; set; }
        [ForeignKey(nameof(PetLifeCycleStageId))]
        [InverseProperty(nameof(LifeCycleStage.PlayerMethodsHistories))]
        public virtual LifeCycleStage PetLifeCycleStage { get; set; }
        [ForeignKey(nameof(PlayerId))]
        [InverseProperty("PlayerMethodsHistories")]
        public virtual Player Player { get; set; }
    }
}
