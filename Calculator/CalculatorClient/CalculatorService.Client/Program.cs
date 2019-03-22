using CalculatorService.Client.Models;
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
                Console.WriteLine();
                switch (userInput)
                {

                    case 1:
                        Console.WriteLine("Suma");
                        Console.WriteLine("Ingrese los numeros separados por coma.");
                        string[] numbersAdd = Console.ReadLine().Split(',');
                        Console.WriteLine("Ingrese id Tracking-Id (opcional):");
                        string EviTrackingIDAdd = Console.ReadLine();
                        AddRequest addRequest = new AddRequest();
                        try
                        {
                            addRequest.Addends = Array.ConvertAll(numbersAdd, s => int.Parse(s));
                            Calculator.Add(addRequest, EviTrackingIDAdd);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Hubo un error al ingresar los numeros");
                        }
               
                        break;
                    case 2:
                        Console.WriteLine("Resta de 2 numeros");
                        Console.WriteLine("Ingrese primer numero(Minuendo):");
                        int Minuendo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese segundo numero(Sustraendo):");
                        int Sustraendo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese id Tracking-Id (opcional):");
                        string EviTrackingID =Console.ReadLine();
                        SubRequest subRequest = new SubRequest();
                        subRequest.Minuend = Minuendo;
                        subRequest.Subtrahend = Sustraendo;
                        Calculator.Sub(subRequest,EviTrackingID);

                        break;

                    case 3:
                        Console.WriteLine("Multiplicación");
                        Console.WriteLine("Ingrese los numeros separados por coma.");
                        string[] numbers = Console.ReadLine().Split(',');
                        Console.WriteLine("Ingrese id Tracking-Id (opcional):");
                        string EviTrackingIDMult = Console.ReadLine();
                        MultRequest MultRequest = new MultRequest();
                        try
                        {
                            MultRequest.Factors = Array.ConvertAll(numbers, s => int.Parse(s));
                            Calculator.Mult(MultRequest, EviTrackingIDMult);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Hubo un error al ingresar los numeros");
                        }
             

                        break;

                    case 4:
                        Console.WriteLine("División");
                        Console.WriteLine("Ingrese primer numero(Dividendo):");
                        int Dividendo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese segundo numero(Divisor):");
                        int Divisor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese id Tracking-Id (opcional):");
                        string EviTrackingIDDiv = Console.ReadLine();
                        DivtRequest divtRequest = new DivtRequest();
                        divtRequest.Dividend = Dividendo;
                        divtRequest.Divisor = Divisor;
                        Calculator.Div(divtRequest, EviTrackingIDDiv);
                        break;

                    case 5:
                        Console.WriteLine("Raiz Cuadrada");
                        Console.WriteLine("Ingrese el numero:");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese id Tracking-Id (opcional):");
                        string EviTrackingIDSqrt = Console.ReadLine();
                        SqrtRequest sqrtRequest = new SqrtRequest();
                        sqrtRequest.Number = number;
                        Calculator.Sqrt(sqrtRequest, EviTrackingIDSqrt);
                        break;

                    case 6:
                        Console.WriteLine("Consultar Logs");
                        Console.WriteLine("Ingrese el id.");
                        int id;
                        try
                        {
                            id = Convert.ToInt32(Console.ReadLine());
                            Calculator.Query(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Debe ingresar un valor valido: " + ex);
                        }
                       
                        break;
                    default:
                        break;
                }


            } while (userInput != 7);
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
            Console.WriteLine("5. Raiz cuadrada");
            Console.WriteLine("6. Logs Diario");
            Console.WriteLine("7. Salir");
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
