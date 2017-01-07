using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Vert
{
    public class VertDBContext : DbContext
    {
        private List<string> connectionStringList;

        private int connIndex = 0;

        public VertDBContext()
        {

        }

        public VertDBContext(int index)
        {
            connIndex = index;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringList[connIndex]);
        }
    }
}
