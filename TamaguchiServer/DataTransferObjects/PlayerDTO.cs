using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
