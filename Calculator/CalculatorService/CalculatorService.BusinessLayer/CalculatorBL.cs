using System;
using System.Collections.Generic;
using CalculatorService.DataLayer;
using Common.Models;

namespace CalculatorService.BusinessLayer
{
    public class CalculatorBL
    {

        public static AddResult Add(AddRequest Addends,string trackingID) {

            return CalculatorDL.Add(Addends, trackingID);
        }

        public static List<Operations> Query(string id)
        {
            return CalculatorDL.Query(id);

        }

        public static SubResult Sub(SubRequest subRequest, string tracking_ID)
        {
            return CalculatorDL.Sub(subRequest, tracking_ID);
        }

        public static MultResult Mult(MultRequest multRequest, string tracking_ID)
        {
            return CalculatorDL.Mult(multRequest, tracking_ID);
        }

        public static DivtResult Div(DivtRequest divtRequest, string tracking_ID)
        {
            return CalculatorDL.Div(divtRequest, tracking_ID);
        }

        public static SqrtResult Sqrt(SqrtRequest sqrtRequest, string tracking_ID)
        {
            return CalculatorDL.Sqrt(sqrtRequest, tracking_ID);
        }
    }
}



