using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Core
{
    public class ITLifeBlogDbContext : DbContext
    {
        public ITLifeBlogDbContext(DbContextOptions<ITLifeBlogDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleType> ArticleTypes { get; set; }

        public DbSet<NLog> NLogs { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;");
        }
    }
}
