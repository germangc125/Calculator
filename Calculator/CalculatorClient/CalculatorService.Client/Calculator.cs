using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;
using System.Web.Script.Serialization;
using CalculatorService.Client.Models;

namespace CalculatorService.Client
{
    public class Calculator
    {
        public static string urlBase = "http://localhost:62336/api/Calculator";

        public static void Add(AddRequest numbers,string EviTrackingID)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Add", Method.POST);
            if (EviTrackingID != "")
            {
                request.AddHeader("x-evi-tracking-id", EviTrackingID);
            }
            else if (EviTrackingID == "")
            {
                request.AddHeader("x-evi-tracking-id", "0");
            }
            //var filters = "{\"Addends\":\"" + numbers.Split(' ')[0] + "\"}";
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(numbers), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                AddResponse result = (new JavaScriptSerializer()).Deserialize<AddResponse>(response.Content);
                Console.WriteLine("Resultado:" + result.Sum + ". " + (EviTrackingID != "" ? "y se guardo en el log." : ""));
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

        public static void Sub(SubRequest numbers, string EviTrackingID)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Sub", Method.POST);
            if (EviTrackingID != "")
            {
                request.AddHeader("x-evi-tracking-id", EviTrackingID);
            }
            else if (EviTrackingID == "")
            {
                request.AddHeader("x-evi-tracking-id", "0");
            }
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(numbers), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                SubResult result = (new JavaScriptSerializer()).Deserialize<SubResult>(response.Content);
                Console.WriteLine("Resultado: Diferencia: " + result.Difference + ". " + (EviTrackingID != "" ? "y se guardo en el log." : ""));
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

        public static void Mult(MultRequest numbers, string EviTrackingID) {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Mult", Method.POST);
            if (EviTrackingID != "")
            {
                request.AddHeader("x-evi-tracking-id", EviTrackingID);
            }
            else if (EviTrackingID == "")
            {
                request.AddHeader("x-evi-tracking-id", "0");
            }
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(numbers), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                MultResult result = (new JavaScriptSerializer()).Deserialize<MultResult>(response.Content);
                Console.WriteLine("Resultado: Producto: " + result.Product + ". " + (EviTrackingID != "" ? "y se guardo en el log." : ""));
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

        internal static void Div(DivtRequest divtRequest, string EviTrackingIDDiv)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Div", Method.POST);
            if (EviTrackingIDDiv != "")
            {
                request.AddHeader("x-evi-tracking-id", EviTrackingIDDiv);
            }
            else if (EviTrackingIDDiv == "")
            {
                request.AddHeader("x-evi-tracking-id", "0");
            }
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(divtRequest), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                DivtResult result = (new JavaScriptSerializer()).Deserialize<DivtResult>(response.Content);
                Console.WriteLine("Resultado: Cociente: " + result.Quotient + " - Resto: " + result.Remainder + "." + (EviTrackingIDDiv != "" ? "y se guardo en el log." : ""));
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

        internal static void Sqrt(SqrtRequest sqrtRequest, string eviTrackingIDSqrt)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Sqrt", Method.POST);
            if (eviTrackingIDSqrt != "")
            {
                request.AddHeader("x-evi-tracking-id", eviTrackingIDSqrt);
            }
            else if (eviTrackingIDSqrt == "")
            {
                request.AddHeader("x-evi-tracking-id", "0");
            }
            request.AddParameter("application/json", new JavaScriptSerializer().Serialize(sqrtRequest), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                SqrtResult result = (new JavaScriptSerializer()).Deserialize<SqrtResult>(response.Content);
                Console.WriteLine("Resultado: Cuadrado: " + result.Square + ". " + (eviTrackingIDSqrt != "" ? "y se guardo en el log." : ""));
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

        public static void Query(int id)
        {
            var client = new RestClient(urlBase);
            var request = new RestRequest("Query", Method.POST);
            var filters = "{\"id\":\"" + id + "\"}";
            request.AddParameter("application/json", id, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Operations> result = (new JavaScriptSerializer()).Deserialize<List<Operations>>(response.Content);
                if (result.Count > 0)
                {
                    foreach (var item in result)
                    {
                        Console.WriteLine("Id:" + item.Id + "- Operación: " + item.Operation + "- Calculo: " + item.Calculation + "- Fecha: " + item.Date);
                    }
                }
                else if (result.Count == 0)
                {
                    Console.WriteLine("No hay resultados");
                }
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error: " + response.ErrorMessage);
            }
            Console.WriteLine("Fin del programa, va a volver al menu");
            Console.WriteLine();
        }

    }
}
