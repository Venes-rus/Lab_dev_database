using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppNHibernate
{
    public class Theme
    {
        public virtual int Id { get; set; }
        public virtual string ThemeName { get; set; }
    }
}
