using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Manager
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CNP { get; set; }
        public int tel { get; set; } 
        public Person()
        {
            this.Id = 0;
            this.Name = "";
            this.CNP = 0;
            this.tel = 0;
        }

    }
}
