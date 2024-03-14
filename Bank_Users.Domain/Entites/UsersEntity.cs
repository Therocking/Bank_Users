using System.ComponentModel.DataAnnotations;
using Bank_Users.Domain.Entites.Base;

namespace Bank_Users.Domain.Entites
{
    public class UsersEntity: BaseEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(125)]
        public string Password { get; set; }

        public virtual ICollection<UsersRolesEntity> UserRoles { get; set; }
    }
}
