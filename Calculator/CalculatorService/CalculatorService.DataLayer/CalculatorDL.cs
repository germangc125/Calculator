using Common.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CalculatorService.DataLayer
{
    public class CalculatorDL
    {

       public DataTable dt = new DataTable("LogJournal");

        public CalculatorDL()
        {
                dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Operation", typeof(string));
            dt.Columns.Add("Calculation", typeof(string));
            dt.Columns.Add("Date", typeof(DateTime));
            //ds.Tables.Add(dt);
        }




        public AddResult Add(AddRequest Addends, string trackingID)
        {
         
            AddResult addResult = new AddResult();
            Operations operations = new Operations();
            operations.Operation = "Sum";
            try
            {
                string[] arrayNumbers = Addends.Addends.Split(' ')[0].Split(',');
                int cont = 0;
                foreach (string number in arrayNumbers)
                {
                    cont += 1;
                    addResult.Sum += Convert.ToInt32(number);
                    operations.Calculation = operations.Calculation + number.ToString() + (cont == arrayNumbers.Length ? "":"+");
                }
                if (Convert.ToInt32(trackingID) != 0)
                {
                    dt.Rows.Add(trackingID, operations.Operation, operations.Calculation + "=" + addResult.Sum, DateTime.Now);
                }
            }


            catch (Exception ex)
            {
                addResult.Sum = -1;
            }
            return addResult;
        }


        public List<Operations> query(int id) {
            List<Operations> listOperations = new List<Operations>();



        }
    }
}
