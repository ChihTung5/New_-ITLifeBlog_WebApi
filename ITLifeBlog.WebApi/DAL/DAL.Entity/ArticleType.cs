using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 文章分类
    /// </summary>
    public class ArticleType : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public bool IsDelete { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
