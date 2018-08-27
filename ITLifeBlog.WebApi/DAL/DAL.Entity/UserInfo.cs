using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserInfo : EntityBase
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
