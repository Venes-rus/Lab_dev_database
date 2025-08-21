using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppNHibernate
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Cipher { get; set; }
        public virtual string Title { get; set; }
        public virtual string FirstAuthor { get; set; }
        public virtual string Publisher { get; set; }
        public virtual string PublicationPlace { get; set; }
        public virtual int PublicationYear { get; set; }
        public virtual int Pages { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int ThemeCode { get; set; }
        public virtual int CopiesCount { get; set; }
    }
}
