using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiServer.DataTransferObjects
{
    public class PetDTO
    {
        public int PetId { get; set; }
        public int PlayerId { get; set; }
        public string PetName { get; set; }
        public DateTime BirthDate { get; set; }
        public int PetWeight { get; set; }
        public int Age { get; set; }
        public int HungerLevel { get; set; }
        public int CleanLevel { get; set; }
        public int HappinessLevel { get; set; }
        public int HealthStatusId { get; set; }
        public int LifeCycleStageId { get; set; }
        public PetDTO() { }
        public PetDTO(Pet p)
        {
            this.PetId = p.PetId;
            this.PlayerId = p.PlayerId;
            this.PetName = p.PetName;
            this.BirthDate = p.BirthDate;
            this.PetWeight = p.PetWeight;
            this.Age = p.Age;
            this.HungerLevel = p.HungerLevel;
            this.CleanLevel = p.CleanLevel;
            this.HappinessLevel = p.HappinessLevel;
            this.HealthStatusId = p.HealthStatusId;
            this.LifeCycleStageId = p.LifeCycleStageId;
        }
        

        
    }
}
