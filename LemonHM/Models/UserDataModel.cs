using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonDotNetCore.ConsoleApp.Models
{
    [Table("Tbl_User")]
    public class UserDataModel
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public long NRC { get; set; }
        public string Address { get; set; }
        public long MobileNo { get; set; }
    }
}