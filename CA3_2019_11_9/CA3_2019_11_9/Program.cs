using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA3_2019_11_9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> grades = new List<double>();
            Console.WriteLine("Enter grades. Use 'x' to finish.");
            while (true)
            {
                string input= Console.ReadLine();
                if (input=="x")
                {
                    break;
                }

                grades.Add(double.Parse(input));
               
            }

            Console.WriteLine(grades);

            Console.WriteLine("Average is "+average(grades));
            Console.ReadKey();

        }
        static double average(List<double> grades)
        {
            double sum = 0.0;
            for (int i = 0; i < grades.Count; i++)
            {
                sum = sum + grades[i];
            }
            double average = sum / grades.Count;

            return average;
        }
    }
}
