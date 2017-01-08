using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vert.Test
{
    public class Person
    {
        [Key]
        public int ID { set; get; }

        public string UserName { set; get; }
    }
}
