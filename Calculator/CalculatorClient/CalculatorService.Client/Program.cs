using RestSharp;
using System;
using System.Net;
using System.Web.Script.Serialization;

namespace CalculatorService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            do
            {
                userInput = DisplayMenu();

                switch (userInput)
                {
                    case 1:
                        //// Request Test Object
                        //AddRequest request = new AddRequest();
                        //request.Addends = new int[] { 1, 2, 3 };

                        //HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(String.Format("{0}{1}", "http://localhost:62336/api/Calculator", "add"));
                        //Req.Method = "POST";
                        //Req.ContentType = "application/json";
                        //Req.Headers.Add("X-Evi-Tracking-Id", "12345678");
                        //HttpWebResponse Resp = (HttpWebResponse)Req.GetResponse();


                        Console.WriteLine();
                        Console.WriteLine("Suma");
                        Console.WriteLine("Ingrese los numeros separados por coma.");
                        string numbers = Console.ReadLine();
                        var client = new RestClient("http://localhost:62336/api/Calculator");
                        var request = new RestRequest("Add", Method.POST);
                        request.AddHeader("cache-control", "no-cache");
                        string[] arrayEviTrackingID = numbers.Split(' ');
                        if (arrayEviTrackingID.Length > 1)
                        {
                            string EviTrackingID = arrayEviTrackingID[1];
                            request.AddHeader("x-evi-tracking-id", EviTrackingID);
                        }
                        else if (arrayEviTrackingID.Length == 1)
                        {
                            request.AddHeader("x-evi-tracking-id", "0");
                        }


                        var filters = "{\"Addends\":\"" + numbers + "\"}";
                        request.AddParameter("application/json", filters, ParameterType.RequestBody);
                        request.RequestFormat = DataFormat.Json;
                        //request.AddParameter("Addends", numbers);

                        //var filters = "{\"input\"" + "as" + "\"}";
                        //request.AddParameter("application/json");
                        IRestResponse response = client.Execute(request);
                        Console.WriteLine();
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            AddResponse result = (new JavaScriptSerializer()).Deserialize<AddResponse>(response.Content);
                            Console.WriteLine("Resultado:" + result.Sum);
                        }
                        else
                        {
                            Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
                        }
                        Console.WriteLine("Fin del programa, va a volver al menu");
                        Console.WriteLine();
                        break;
                    case 2:
                        break;

                    case 3: break;

                    case 4: break;

                    case 5: break;

                    default:
                        break;
                }


            } while (userInput != 6);







            //Start:
            //Console.Write("Enter Name: ");
            //string name = Console.ReadLine();



            // var client = new RestClient("http://localhost:62336/api/Calculator");
            // var request = new RestRequest("Calculate", Method.GET);
            // request.AddParameter("input", "2");
            // request.AddHeader("cache-control", "no-cache");
            // //request.AddHeader("x-­evi-­tracking-­id", "qw");
            // //var filters = "{\"input\"" + name + "\"}";
            // //request.AddParameter("application/json", filters, ParameterType.RequestBody);
            // IRestResponse response = client.Execute(request);
            //// return response.Content;




















            //string apiUrl = "http://localhost:62336/api/Calculator";
            //var input = new
            //{
            //    input = name,
            //};
            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            //WebClient client = new WebClient();
            //client.Headers["Content-type"] = "application/json";
            ////client.Headers["X-­Evi-­Tracking-­Id"] = "1";
            //client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(apiUrl + "/Calculate", inputJson);
            //List<Customer> customers = (new JavaScriptSerializer()).Deserialize<List<Customer>>(json);



            //if (customers.Count > 0)
            //{
            //    foreach (Customer customer in customers)
            //    {
            //        Console.WriteLine(customer.ContactName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("No records found.");
            //}
            //Console.WriteLine();
            //goto Start;
        }

        static public int DisplayMenu()
        {
            int selected = 0;

            Console.WriteLine("Calculadora");
            Console.WriteLine();
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multipliación");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Logs Diario");
            Console.WriteLine("6. Salir");
            var result = Console.ReadLine();
            try
            {
                selected = Convert.ToInt32(result);
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("Seleccione una opcion valida.");
            }
            return selected;
        }
    }
}
