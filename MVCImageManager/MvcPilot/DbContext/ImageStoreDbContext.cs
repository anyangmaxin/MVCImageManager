using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MvcPilot.Models;

namespace MvcPilot.DbContext
{
    /// <summary>
    /// 数据库链接
    /// </summary>
    public class ImageStoreDbContext : System.Data.Entity.DbContext
    {
        public ImageStoreDbContext() : base("ImageStore")
        {
        }

        public DbSet<ImageStore> ImageStores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}