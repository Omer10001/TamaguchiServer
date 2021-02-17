using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace TamaguchiBL.Models
{
    public partial class Player
    {
        public List <PlayerMethodsHistory> GetPlayerMethodsHistories()
        {
            using (var db = new TamaguchiContext())
            {
                return db.PlayerMethodsHistories.Include(p => p.Player).Include(a => a.Exercise).Include(x => x.Pet).Where(x => x.PlayerId == this.PlayerId).OrderBy(r => r.MethodDate).ToList();

            }
        }
        public List<Pet> GetAllPets()
        {
            using (var db = new TamaguchiContext())
            {
                return db.Pets.Include(p => p.Player).Include(s => s.HealthStatus).Where(p => p.PlayerId == this.PlayerId).ToList();
                
            }
        }
        //public bool IsPetDead()
        //{
        //    var db = new TamaguchiContext();
        //    //using (var db = new TamaguchiContext())
        //    //{
        //        var player = db.Players.Where(p => p.PlayerId == this.PlayerId).Include(x => x.Pets).FirstOrDefault();
        //        if (player.CurrentPetId == null) //if the player doesn't have a current pet, return true.
        //            return true;
        //        return player.CurrentPet.HealthStatusId == 4;
        //    //}
        //}
    }
}
