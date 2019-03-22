using CalculatorService.DataLayer;
using Common.Models;

namespace CalculatorService.BusinessLayer
{
    public class CalculatorBL
    {
        CalculatorDL calculatorDl = new CalculatorDL();

        public AddResult Add(AddRequest Addends,string trackingID) {

            return calculatorDl.Add(Addends, trackingID);
        }
    }
}



