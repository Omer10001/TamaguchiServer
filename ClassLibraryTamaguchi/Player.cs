using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Tamaguchi.Models
{
    [Index(nameof(Email), Name = "UQ__Players__A9D10534E194E9B1", IsUnique = true)]
    [Index(nameof(Email), nameof(UserName), nameof(FirstName), nameof(LastName), Name = "idx_playerInfo")]
    public partial class Player
    {
        public Player()
        {
            Pets = new HashSet<Pet>();
            PlayerMethodsHistories = new HashSet<PlayerMethodsHistory>();
        }

        [Key]
        [Column("PlayerID")]
        public int PlayerId { get; set; }
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [StringLength(255)]
        public string Gender { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserPassword { get; set; }
        [Column("CurrentPetID")]
        public int? CurrentPetId { get; set; }

        [ForeignKey(nameof(CurrentPetId))]
        [InverseProperty(nameof(Pet.Players))]
        public virtual Pet CurrentPet { get; set; }
        [InverseProperty(nameof(Pet.Player))]
        public virtual ICollection<Pet> Pets { get; set; }
        [InverseProperty(nameof(PlayerMethodsHistory.Player))]
        public virtual ICollection<PlayerMethodsHistory> PlayerMethodsHistories { get; set; }
    }
}
