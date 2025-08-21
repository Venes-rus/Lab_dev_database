using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppNHibernate
{
    public class Reader
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Phone { get; set; }
    }
}
