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
            //DB context = new DB(1);
            //Person person = new Person { UserName = "test" };
            //context.Add(person);
            //context.SaveChanges();

            VertContext<DB> context = new VertContext<DB>();
            VertDBContext db1 = context.UseDB(0);
            VertDBContext db2 = context.UseDB(1);
            List<Person> personList1 = db1.Set<Person>().ToList();
            List<Person> personList11 = db1.Set<Person>().ToList();
            List<Person> personList2 = db2.Set<Person>().ToList();
            List<Person> personList22 = db2.Set<Person>().ToList();
        }
    }
}
