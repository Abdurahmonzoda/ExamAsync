using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Emtities
{
    public class Quotes
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string QuotesText { get; set; }
        public int CategoryId { get; set; }
    }
}
