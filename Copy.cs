using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppNHibernate
{
    public class Copy
    {
        public virtual int Id { get; set; }
        public virtual int BookId { get; set; }
        public virtual string InventoryNumber { get; set; }
        public virtual DateTime? IssueDate { get; set; } // Дата выдачи книги
        public virtual DateTime? ReturnDate { get; set; } // Дата возврата книги
        public virtual int? ReaderId { get; set; } // ID читателя, которому выдана книга
    }
}