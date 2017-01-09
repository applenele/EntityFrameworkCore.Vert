using EntityFrameworkCore.Vert.Helper;
using EntityFrameworkCore.Vert.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Vert
{
    public class VertDBContext : DbContext
    {
        private static List<string> connectionStringList = new ServiceCollection().
            AddOptions().Configure<List<ConnectionModel>>(ConfigurationHelper.GetConfiguration("appsettings.json").GetSection("ConnectionStrings"))
            .BuildServiceProvider().GetService<IOptions<List<ConnectionModel>>>().Value.Select(x => x.ConnectString).ToList();

        private int connIndex = 0;

        public VertDBContext()
        {
        }

        public VertDBContext(int index = 0)
        {
            connIndex = index;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringList[connIndex]);
        }


    }
}
