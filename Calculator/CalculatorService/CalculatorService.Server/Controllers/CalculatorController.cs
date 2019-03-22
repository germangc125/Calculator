using CalculatorService.BusinessLayer;
using Common.Models;
using System.Linq;
using System.Web.Http;

namespace CalculatorService.Server.Controllers
{
    public class CalculatorController : ApiController
    {
        CalculatorBL calculatorBL = new CalculatorBL();

        [Route("api/Calculator/Add")]
        [HttpPost]
        public AddResult Add([FromBody] AddRequest Addends)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count -1].Value.First().ToString();
            return calculatorBL.Add(Addends,  tracking_ID); 
        }
    }
}
