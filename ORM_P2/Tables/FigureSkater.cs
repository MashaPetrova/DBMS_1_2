using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_P2

{
    public class FigureSkater
    {
        public virtual int FigureSkaterId { get; set; }
        public virtual string FirstName { get; set;}
        public virtual string LastName { get; set;}
        public virtual int Age { get; set; }
        public virtual Club Club { get; set; }
    }
}
