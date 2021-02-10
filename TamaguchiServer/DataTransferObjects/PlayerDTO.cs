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
        public int PlayerId { get; set; }
        public string Email { get; set; }

        public string UserPassword { get; set; }
        public PlayerDTO(Player p)
        {
            PlayerId = p.PlayerId;
            Email = p.Email;
            UserPassword = p.UserPassword;
        }
    }
}
