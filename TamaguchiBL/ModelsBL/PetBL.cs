using System;
using System.Collections.Generic;
using System.Text;

namespace TamaguchiBL.Models
{
    public partial class Pet
    {
        public void DoExersice(Exercise ex)
        {
            int levelAffect = ex.LevelAffect;
            if (ex.ExerciseType.IsHungerLevel)
            {
                this.HungerLevel += levelAffect;
            }
            if (ex.ExerciseType.IsHappinessLevel)
            {
                this.HappinessLevel += levelAffect;
            }
            if (ex.ExerciseType.IsCleanLevel)
            {
                this.CleanLevel += levelAffect;
            }
            using (var db = new TamaguchiContext())
            {
                db.SaveChanges();
            }
        }
    }
}
