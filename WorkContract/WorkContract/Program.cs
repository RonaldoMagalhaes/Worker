using System;
using System.Globalization;
using WorkContract.Entities;
using WorkContract.Entities.Enum;

namespace WorkContract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department´s name: ");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Base Salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Department department= new Department(depName);
            Worker worker = new Worker(name, level, department, salary);

            Console.WriteLine();

            Console.Write("How many contract´s to this worker: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value Per Hour: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration: ");
                int time = int.Parse(Console.ReadLine());
                HourContract hc = new HourContract(date, value, time);
                worker.addContract(hc);

            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income(MM/YYYY): ");
            string montAndYear = Console.ReadLine();

            int year = int.Parse(montAndYear.Substring(3,4));
            int month = int.Parse(montAndYear.Substring(0,2));

                
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("Name " + worker.Name);
            Console.WriteLine("Department " + department.Name.ToString());
            Console.WriteLine("Income for  " + montAndYear + ": " + worker.Income(year, month));

            Console.ReadLine();
        }
    }
}
