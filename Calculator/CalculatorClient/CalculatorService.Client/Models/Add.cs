using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService.Client
{

    public class AddResponse
    {
        public int Sum { get; set; }
    }

    public class AddRequest
    {
        public string Addends { get; set; }
    }

}
