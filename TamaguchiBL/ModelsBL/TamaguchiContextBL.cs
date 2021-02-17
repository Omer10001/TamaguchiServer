using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tamaguchi.Models;
using System.Linq;

namespace TamaguchiBL.Models
{
    public partial class TamaguchiContext
    {
        public Player Login(string email, string pswd)
        {
            ; try
            {
                Player p = this.Players.Where((p => p.Email == email && p.UserPassword == pswd)).FirstOrDefault();
                return p;
            }
            catch (Exception e)
            {
                throw new Exception("Could not Login. error retreiving Data", e);
            }
        }
        public void CreateAnimal(string petName, int playerId)
        {
            Random r = new Random();
            

            

            Pet pet = new Pet
            {
                PetName = petName,
                PlayerId = playerId,
                BirthDate = DateTime.Now,
                PetWeight = r.Next(20, 320),
                Age = 0,
                HungerLevel = 80,
                CleanLevel = 80,
                HappinessLevel = 80,
                HealthStatusId = 1,
                LifeCycleStageId = 1,
            };
            this.Players.Where(x => x.PlayerId == playerId).FirstOrDefault().CurrentPetId = pet.PetId;
   
            
            this.Pets.Add(pet);
            this.SaveChanges();
        }
        public void CreateUser(string firstName, string lastName, string eMali, string gender, DateTime birthDate, string userName, string userPassword)
        {
            Player player = new Player
            {
                FirstName = firstName,
                LastName = lastName,
                Email = eMali,
                Gender = gender,
                BirthDate = birthDate,
                UserName = userName,
                UserPassword = userPassword
            };
            this.Players.Add(player);
            this.SaveChanges();
        }
        public List<Exercise> ExercisesByType(int typeID)
        {
            List<Exercise> excersicesList = this.Exercises.Where(e => e.ExerciseTypeId == typeID).Include(t => t.ExerciseType).ToList();
            return excersicesList;
        }
        public Pet GetCurrentPetInfo(int playerID)
        {
            return this.Pets.Include(x => x.Player).Include(x => x.LifeCycleStage).Include(x => x.HealthStatus).Where(a => a.PlayerId == playerID).FirstOrDefault();
        }
        public void UpdatePlayerMethodHistory(Pet p, Player a, Exercise e)
        {
            PlayerMethodsHistory r = new PlayerMethodsHistory
            {
                PlayerId = a.PlayerId,
                PetId = p.PetId,
                ExerciseId = e.ExerciseId,
                MethodDate = DateTime.Now,
                PetAge = p.Age,
                PetLifeCycleStageId = p.LifeCycleStageId
            };
            this.PlayerMethodsHistories.Add(r);
            this.SaveChanges();
        }
        public bool IsPetDead(Player p)
        {
            var player = this.Players.Where(x => x.PlayerId == p.PlayerId).Include(y => y.Pets).FirstOrDefault();
            if (player.CurrentPetId == null) //if the player doesn't have a current pet, return true.
                return true;
            return player.CurrentPet.HealthStatusId == 4;
           
        }
        public void DoExercise(Pet p, Exercise ex)
        {
            p.DoExersice(ex);
            this.SaveChanges();
        }

    }
}
