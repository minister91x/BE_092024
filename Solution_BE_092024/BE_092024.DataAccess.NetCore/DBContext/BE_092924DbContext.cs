using BE_092024.DataAccess.NetCore.DataObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_092024.DataAccess.NetCore.DBContext
{
    public class BE_092924DbContext : DbContext
    {
        public BE_092924DbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Room> room { get; set; }
        public virtual DbSet<User> user { get; set; }   
    }
}
