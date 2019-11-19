using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_2019_11_09
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> b = new List<int>() { 1, 2, 3 };
            b.Add(4);
            b.Insert(0,99); //saab muuta väärtust
                      

            for (int i = 0; i < b.Count; i++) // listi puhul pole pikkust, selle asemel on count
            {
                Console.WriteLine(b[i]);
            }
            string a = "Hello World!";
            Console.WriteLine(a[0]+a[6]);
            Console.WriteLine(a.Length);

            string path = @"C:\Users\opilane\Documents\KTA-19E.txt"; // faili asukoht antud arvutis

            string[] lines = System.IO.File.ReadAllLines(path);

            double[] grades = new double[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                grades[i]= double.Parse(lines[i]);
            }


            Console.WriteLine(average(grades));


            Console.ReadKey();
        }
        static double average(double[] grades)
        {
            double sum = 0.0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum = sum + grades[i];
            }
            double average = sum / grades.Length;

            return average;
        }
    }
}
