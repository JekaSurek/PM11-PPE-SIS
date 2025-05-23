using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace УчетСИЗ.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Role { get; set; }
        public string Rolename { get; set; }  
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FullName => $"{Surname} {Firstname} {Lastname}".Trim();
    }
}
