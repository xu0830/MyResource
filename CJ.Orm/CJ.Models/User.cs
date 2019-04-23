using CJ.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CJ.Models
{
    /// <summary>
    /// 数据库user表
    /// </summary>
    [Table("Users")]
    public class User
    {
        [KeyFilter]
        public int Id { get; set; }

        [Column("UserName")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public DateTime CreateTime { get; set; }

        public int UserType { get; set; }

        public string KeCheng { get; set; }

        public string FenShu { get; set; }
    }
}
