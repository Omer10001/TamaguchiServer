using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamaguchiBL.Models;

namespace TamaguchiServer.DataTransferObjects
{
    public class PlayerDTO
    {
        public PlayerDTO()
        {

        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public PlayerDTO(Player p)
        {
            FirstName = p.FirstName;
            LastName = p.LastName;
            Email = p.Email;
            Gender = p.Gender;
            BirthDate = p.BirthDate;
            UserName = p.UserName;
            UserPassword = p.UserPassword;
        }
    }
}
