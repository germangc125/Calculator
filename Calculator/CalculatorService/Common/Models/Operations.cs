using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
   public class Operations
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }
    }
}
