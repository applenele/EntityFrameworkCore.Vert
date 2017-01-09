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
            VertContext<DB> context = new VertContext<DB>();
            DB db1 = context.UseDB(0);
            DB db2 = context.UseDB(1);
            //List<Person> personList1 = db1.Set<Person>().ToList();
            //List<Person> personList11 = db1.Set<Person>().ToList();
            //List<Person> personList2 = db2.Set<Person>().ToList();
            //List<Person> personList22 = db2.Set<Person>().ToList();

            db1.Persons.Add(new Person { UserName = "db1" });
 
            db2.Persons.Add(new Person { UserName = "db2" });

            context.SaveChanges();

            context.Dispose();
        }
    }
}
