using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Directors
    {
        [Key]
        public int DirectorId { get; set; }
        [Required]
        public string DirectorName { get; set; }
    }
}
