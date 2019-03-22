using CalculatorService.BusinessLayer;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CalculatorService.Server.Controllers
{
    public class CalculatorController : ApiController
    {
        [Route("api/Calculator/Add")]
        [HttpPost]
        public AddResult Add([FromBody] AddRequest addRequest)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count -1].Value.First().ToString();
            return CalculatorBL.Add(addRequest,  tracking_ID); 
        }

        [Route("api/Calculator/Sub")]
        [HttpPost]
        public SubResult Sub([FromBody] SubRequest subRequest)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBL.Sub(subRequest, tracking_ID);
        }

        [Route("api/Calculator/Mult")]
        [HttpPost]
        public MultResult Mult([FromBody] MultRequest multRequest)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBL.Mult(multRequest, tracking_ID);
        }

        [Route("api/Calculator/Div")]
        [HttpPost]
        public DivtResult Div([FromBody] DivtRequest divtRequest)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBL.Div(divtRequest, tracking_ID);
        }

        [Route("api/Calculator/Sqrt")]
        [HttpPost]
        public SqrtResult Sqrt([FromBody] SqrtRequest sqrtRequest)
        {
            var headers = this.Request.Headers.ToList();
            string tracking_ID = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBL.Sqrt(sqrtRequest, tracking_ID);
        }

        [Route("api/Calculator/Query")]
        [HttpPost]
        public List<Operations> Query([FromBody] string id)
        {
            return CalculatorBL.Query(id);
        }


    }
}
