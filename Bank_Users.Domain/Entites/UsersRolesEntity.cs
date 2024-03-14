using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Users.Domain.Entites
{
    public class UsersRolesEntity
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual UsersEntity User { get; set; }
        [ForeignKey("RoleId")]
        public virtual RolesEntity Role { get; set; }
    }
}
