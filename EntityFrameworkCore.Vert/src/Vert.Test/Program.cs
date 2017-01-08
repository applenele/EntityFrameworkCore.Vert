using EntityFrameworkCore.Vert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vert.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DB context = new DB(1);
            Person person = new Person { UserName = "test" };
            context.Add(person);
            context.SaveChanges();
        }
    }
}
