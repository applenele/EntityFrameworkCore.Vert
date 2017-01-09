using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Data.SqlClient;

namespace EntityFrameworkCore.Vert
{
    public class VertContext<T> : IDisposable where T : VertDBContext
    {
        private List<VertDBContext> contexts;

        public T CreateContext(int index = 0)
        {
            Type type = typeof(T);
            object[] parameters = new object[1];
            parameters[0] = index;
            object o = Activator.CreateInstance(type, parameters);
            return (T)o;
        }

        public VertContext()
        {
            contexts = new List<VertDBContext>();
        }

        public T UseDB(int index)
        {
            T t = CreateContext(index);
            contexts.Add(t);
            return t;
        }

        public int SaveChanges()
        {
            int result = 0;
            foreach (var item in contexts)
            {
                result = result + item.SaveChanges();
            }
            return result;
        }

        //TODO  wait 1.2 System.Transactions
        public void BeginTransaction()
        {

        }

        public void Dispose()
        {
            foreach (var item in contexts)
            {
                item.Dispose();
            }
        }
    }
}
