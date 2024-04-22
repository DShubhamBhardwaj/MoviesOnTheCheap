using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public class Producers
    {
        [Key]
        public int ProducerID { get; set; }
        [Required]
        public string ProducersName { get; set; }
    }
}
