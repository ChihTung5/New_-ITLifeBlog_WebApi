using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Role : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }


    }
}
