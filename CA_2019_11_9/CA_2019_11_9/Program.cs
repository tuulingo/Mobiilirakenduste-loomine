using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_2019_11_9
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter sutends count");
            int studentsCount = int.Parse(Console.ReadLine());
            double[] grades = new double[studentsCount];

            for (int i = 0; i < studentsCount; i++)
            {
                Console.WriteLine("enter grade for students "+(i+1));
                grades[i]=double.Parse(Console.ReadLine());
            }

            double averagesGrade = average(grades);
            Console.WriteLine("Averages grade is "+ averagesGrade);


            //double student1Grade = 4.5;
            //double student2Grade = 3.0;
            //double student3Grade = 4.2;

            //double averageGrade = (student1Grade + student2Grade + student3Grade) / 3;
            //Console.WriteLine("Average grade "+averageGrade);


            double[] studentGrades = new double[4] { 4.5, 3.0, 4.2,5.0 };  //Samas võid kasutada ka üksikuid sisendeid
            //studentGrades[0] = 4.5;
            //studentGrades[1] = 3.0;
            //studentGrades[2] = 4.2;
            //studentGrades[3] = 5.0;


            //Console.WriteLine(studentGrades[0]);
            //Console.WriteLine(studentGrades[1]);
            // Console.WriteLine(studentGrades[2]);
            // Console.WriteLine(studentGrades[3]);


            

            Console.WriteLine(average(studentGrades));


            

            foreach (var item in studentGrades)
            {
                Console.WriteLine(item);
            }

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
