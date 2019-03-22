using Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Script.Serialization;


namespace CalculatorService.DataLayer
{
    public class CalculatorDL
    {
        public static AddResult Add(AddRequest addRequest, string trackingID)
        {
            AddResult addResult = new AddResult();
            try
            {
                int cont = 0;
                string calculation = "";
                foreach (int number in addRequest.Addends)
                {
                    cont += 1;
                    addResult.Sum += Convert.ToInt32(number);
                    calculation = calculation + number.ToString() + (cont == addRequest.Addends.Length ? "" : "+");
                }
                //Si viene el header x-trackingID diferente de 0 se guarda el log
                if (Convert.ToInt32(trackingID) != 0)
                {
                    SaveLog(Convert.ToInt32(trackingID), "Sum", calculation, addResult.Sum);
                }
            }
            catch (Exception ex)
            {
                addResult.Sum = -1;
            }
            return addResult;
        }

        public static SqrtResult Sqrt(SqrtRequest sqrtRequest, string tracking_ID)
        {
            SqrtResult sqrtResult = new SqrtResult();
            try
            {
                double numberDou = Convert.ToDouble(sqrtRequest.Number);
                sqrtResult.Square = Math.Sqrt(numberDou);
                string calculation = "√" + numberDou.ToString();
                //Si viene el header x-trackingID diferente de 0 se guarda el log
                if (Convert.ToInt32(tracking_ID) != 0)
                {
                    SaveLog(Convert.ToInt32(tracking_ID), "Sqrt", calculation, Convert.ToInt32(sqrtResult.Square));
                }
            }
            catch (Exception ex)
            {
                sqrtResult.Square = -0;
            }
            return sqrtResult;
        }

        public static SubResult Sub(SubRequest subRequest, string trackingID)
        {
            SubResult subResult = new SubResult();
            try
            {
                subResult.Difference = subRequest.Minuend - subRequest.Subtrahend;
                string calculation = subRequest.Minuend.ToString() +"-" + subRequest.Subtrahend.ToString();
                //Si viene el header x-trackingID diferente de 0 se guarda el log
                if (Convert.ToInt32(trackingID) != 0)
                {
                    SaveLog(Convert.ToInt32(trackingID), "Sub", calculation, subResult.Difference);
                }
            }
            catch (Exception ex)
            {
                subResult.Difference = -1;
            }
            return subResult;
        }

        public static MultResult Mult(MultRequest multRequest, string tracking_ID)
        {
            MultResult multResult = new MultResult();
            try
            {
                int cont = 0;
                string calculation = "";
                multResult.Product = 1;
                foreach (int number in multRequest.Factors)
                {
                    cont += 1;
                    multResult.Product *= number;
                    calculation = calculation + number.ToString() + (cont == multRequest.Factors.Length ? "" : "*");
                }
                //Si viene el header x-trackingID diferente de 0 se guarda el log
                if (Convert.ToInt32(tracking_ID) != 0)
                {
                    SaveLog(Convert.ToInt32(tracking_ID), "Mult", calculation, multResult.Product);
                }
            }
            catch (Exception ex)
            {
                multResult.Product = -1;
            }
            return multResult;




        }


        public static DivtResult Div(DivtRequest divtRequest, string tracking_ID)
        {

            DivtResult divtResult = new DivtResult();
            try
            {
                divtResult.Quotient = divtRequest.Dividend / divtRequest.Divisor;
                divtResult.Remainder = divtRequest.Dividend % divtRequest.Divisor;
                string calculation = divtRequest.Dividend + "%" + divtRequest.Divisor.ToString();
                //Si viene el header x-trackingID diferente de 0 se guarda el log
                if (Convert.ToInt32(tracking_ID) != 0)
                {
                    SaveLog(Convert.ToInt32(tracking_ID), "Div", calculation, divtResult.Quotient);
                }
            }
            catch (Exception ex)
            {
                //divtResult.Difference = -1;
            }
            return divtResult;
        }



        public static List<Operations> Query(string id)
        {
            string content = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"));
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Operations> listOperations = js.Deserialize<List<Operations>>(content);
            List<Operations> resultingOperations = listOperations.Where(x => x.Id ==Convert.ToInt32(id)).ToList();
            return resultingOperations;
        }

        private static void SaveLog(int id, string typeOperation, string calculation, int resultCalculation)
        {
            string content = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"));
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Operations> listOperations = js.Deserialize<List<Operations>>(content);
            listOperations.Add(new Operations()
            {
                Id = Convert.ToInt32(id),
                Operation = typeOperation,
                Calculation = calculation + "=" + resultCalculation,
                Date = DateTime.Now,
            });
            string json = js.Serialize(listOperations);
            System.IO.File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath("~/jsondata.json"), json);
        }
    }
}
