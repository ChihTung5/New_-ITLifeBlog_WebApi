using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

        public bool IsDelete { get; set; }

        public int UserInfoId { get; set; }

        public int ArticleTypeId { get; set; }

        public UserInfo UserInfo { get; set; }

        public ArticleType ArticleType { get; set; }

    }
}
