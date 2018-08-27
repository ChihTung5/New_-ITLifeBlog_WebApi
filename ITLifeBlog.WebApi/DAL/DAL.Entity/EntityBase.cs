using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class EntityBase
    {
        [Key]
        public int ID { get; set; }

    }
}
