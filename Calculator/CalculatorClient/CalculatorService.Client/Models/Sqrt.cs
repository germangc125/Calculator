using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client.Models
{

    public class SqrtResult
    {
        public double Square { get; set; }
    }

    public class SqrtRequest
    {
        public int Number { get; set; }
    }
}
