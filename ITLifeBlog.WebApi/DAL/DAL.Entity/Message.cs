using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 留言
    /// </summary>
    public class Message : EntityBase
    {
        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }
    }
}
