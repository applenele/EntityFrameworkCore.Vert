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
        private List<string> connectionStringList;

        private int connIndex = 0;

        public VertDBContext()
        {
        }

        public VertDBContext(int index)
        {
            connIndex = index;
            IConfiguration config = ConfigurationHelper.GetConfiguration("appsettings.json");
            List<ConnectionModel> connections = new ServiceCollection().AddOptions().Configure<List<ConnectionModel>>(config.GetSection("connectionStrings")).BuildServiceProvider().GetService<IOptions<List<ConnectionModel>>>().Value;
            connectionStringList =  connections.Select(x=>x.ConnectString).ToList();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionStringList[connIndex]);
        }

        
    }
}
