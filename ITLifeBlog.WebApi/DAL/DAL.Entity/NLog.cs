using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 日志记录
    /// </summary>
    public class NLog : EntityBase
    {
        [StringLength(1000)]
        public string Origin { get; set; }

        [StringLength(1000)]
        public string LogLevel { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(1000)]
        public string Exception { get; set; }

        [StringLength(1000)]
        public string StackTrace { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
