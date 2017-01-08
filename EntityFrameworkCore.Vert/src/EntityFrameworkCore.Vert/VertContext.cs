using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Data.Common;

namespace EntityFrameworkCore.Vert
{
    public class VertContext<T> where T:VertDBContext,new ()
    {
        public T CreateContext(int index = 0)
        {
            Type type = typeof(T);

            object[] parameters = new object[1];
            parameters[0] =index;
            object o = Activator.CreateInstance(type,parameters);
            return (T)o;
        }

        public VertContext()
        {

        }

        public T UseDB(int index)
        {
            return CreateContext(index);
        }

        public void BeginTransaction()
        {
       //TODO
        }
    }
}
