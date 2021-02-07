using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiServer.DataTransferObjects
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public int ExerciseTypeId { get; set; }
        public string ExerciseName { get; set; }
        public int LevelAffect { get; set; }
        public int WeightAffect { get; set; }
        public ExerciseDTO(){}
        public ExerciseDTO(Exercise e)
        {
            this.ExerciseId = e.ExerciseId;
            this.ExerciseTypeId = e.ExerciseTypeId;
            this.ExerciseName = e.ExerciseName;
            this.LevelAffect = e.LevelAffect;
            this.WeightAffect = e.WeightAffect; 
        }
    }
}
