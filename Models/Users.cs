using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bill_API.Models
{
    [Table("Users")]
    public class Users
    {
        [Column("UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UeserId { get; set; }
        [Column("UserName")]
        [Required]
        public string UserName { get; set; }
        [Column("Password")]
        [Required]
        public string Password { get; set; }
        [Column("IsActive")]
        public byte IsActive { get; set; }
        [Column("CreatedBy")]
        public int CreatedBy { get; set; }
        [Column("CreatedOn")]
        public DateTime CreatedOn { get; set; }
        [Column("ModifiedBy")]
        public int? ModifiedBy { get; set; }
        [Column("ModifiedOn")]
        public DateTime? ModifiedOn { get; set; }
    }
}
