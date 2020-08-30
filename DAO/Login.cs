using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.DAO
{
    public class Login
    {
        [Key]
        public long Id { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
