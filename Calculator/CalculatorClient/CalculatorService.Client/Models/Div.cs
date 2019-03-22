using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client.Models
{

    public class DivtResult
    {
        public int Quotient { get; set; }
        public int Remainder { get; set; }
    }

    public class DivtRequest
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }
    }
}
