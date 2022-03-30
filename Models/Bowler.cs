using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }

        [Required(ErrorMessage = "Pleasee enter a valid last name")]
        public string BowlerLastName { get; set; }

        [Required(ErrorMessage = "Pleasee enter a valid first name")]
        public string BowlerFirstName { get; set; }

        [MaxLength(1)]
        public string BowlerMiddleInit { get; set; }
        public string BowlerAddress { get; set; }
        public string BowlerCity { get; set; }

        [MaxLength(2)]
        public string BowlerState { get; set; }

        [MaxLength(10)]
        public string BowlerZip { get; set; }

        [MaxLength(14)]
        public string BowlerPhoneNumber { get; set; }

        //build the foreign key relationship
        [Required(ErrorMessage = "Pleasee enter a valid team")]
        public int TeamId { get; set; }
        public Team TeamName { get; set; }
    }
}
