using System;
using System.Diagnostics;

namespace SqlDataReaderToListDaynamicMap
{
    class Program
    {
        static void Main(string[] args)
        {
            DBOperations _DBOperations = new DBOperations();
            //var result = _DBOperations.GetAllPersonalInfo();


            Console.WriteLine("Started....");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Reset();


            stopWatch.Start();
            var result1 = _DBOperations.GetAllCustomersDynamicMap();
            Console.WriteLine("Total execution time by dynamic mapping: " + stopWatch.Elapsed.TotalSeconds);
            stopWatch.Reset();

            stopWatch.Start();
            var result2 = _DBOperations.GetAllCustomers();
            stopWatch.Stop();
            Console.WriteLine("Total execution time by manual mapping: " + stopWatch.Elapsed.TotalSeconds);





            stopWatch.Reset();
            Console.WriteLine("The End....");
            Console.ReadLine();
        }
    }
}
