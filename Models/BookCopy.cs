using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCoordinatorApp.Models
{
    public class BookCopy
    {
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public string Status { get; set; }
        public string Barcode { get; set; }
    }
}
