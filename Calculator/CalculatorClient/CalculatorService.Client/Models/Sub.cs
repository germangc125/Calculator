using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client.Models
{

    public class SubResult
    {
        public int Difference { get; set; }
    }

    public class SubRequest
    {
        public int Minuend { get; set; }
        public int Subtrahend { get; set; }
    }
}
