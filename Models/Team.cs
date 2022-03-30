using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySQLWeb.Models
{
    public class Team
    {
        [Key]
        [Required]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
