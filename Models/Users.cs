using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOTC.Models
{
    public enum UserType
    {
        Admin,
        Public
    }
    public class Users
    {
        [Key]
        public int UserID { get; set; }   
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public string password { get; set; }
        public string emailID { get; set; }
    }
}
