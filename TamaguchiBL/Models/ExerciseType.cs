using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TamaguchiBL.Models
{
    [Table("Exercise Type")]
    [Index(nameof(TypeName), Name = "idx_ExerciseTypeName")]
    public partial class ExerciseType
    {
        public ExerciseType()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        [Column("ExerciseTypeID")]
        public int ExerciseTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string TypeName { get; set; }
        public bool IsHungerLevel { get; set; }
        public bool IsCleanLevel { get; set; }
        public bool IsHappinessLevel { get; set; }

        [InverseProperty(nameof(Exercise.ExerciseType))]
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
