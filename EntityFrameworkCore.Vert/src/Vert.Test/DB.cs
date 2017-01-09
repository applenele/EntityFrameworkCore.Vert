using EntityFrameworkCore.Vert;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vert.Test
{
    public class DB : VertDBContext
    {
        public DbSet<Person> Persons { set; get; }

        public DB():base()
        {
            
        }

        public DB(int index=0) : base(index)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
