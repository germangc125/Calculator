using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client.Models
{

    public class MultResult
    {
        public int Product { get; set; }
    }

    public class MultRequest
    {
        public int[] Factors { get; set; }
    }
}
