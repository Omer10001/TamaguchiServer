using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamaguchi.Models
{
    [Index(nameof(ExerciseName), Name = "idx_ExerciseInfo")]
    public partial class Exercise
    {
        public Exercise()
        {
            PlayerMethodsHistories = new HashSet<PlayerMethodsHistory>();
        }

        [Key]
        [Column("ExerciseID")]
        public int ExerciseId { get; set; }
        [Column("ExerciseTypeID")]
        public int ExerciseTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string ExerciseName { get; set; }
        public int LevelAffect { get; set; }
        public int WeightAffect { get; set; }

        [ForeignKey(nameof(ExerciseTypeId))]
        [InverseProperty("Exercises")]
        public virtual ExerciseType ExerciseType { get; set; }
        [InverseProperty(nameof(PlayerMethodsHistory.Exercise))]
        public virtual ICollection<PlayerMethodsHistory> PlayerMethodsHistories { get; set; }
    }
}
