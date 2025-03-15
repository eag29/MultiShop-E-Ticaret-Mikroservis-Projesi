using _MultiShop.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace _MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1443; initial Catalog=MultiShopCommentVt; User=sa; Password=EmirAliGirgin_29");
        }
        public DbSet<UsserComment> UsserComments { get; set; }
    }
}
