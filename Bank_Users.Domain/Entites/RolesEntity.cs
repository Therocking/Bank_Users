using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Users.Domain.Entites.Base;

namespace Bank_Users.Domain.Entites
{
    public class RolesEntity: BaseEntity
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<UsersRolesEntity> UserRoles { get; set; }
    }
}
