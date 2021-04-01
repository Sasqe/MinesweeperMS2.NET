using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinesweeperASP.NET.Models
{
    public class userModel
    {
        //[Required]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

     

        [Required]
        [StringLength(25, MinimumLength = 3)]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 4)]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
