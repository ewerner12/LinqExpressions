using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//////Use LINQ query expressions or query operators for the following questions:
//////1. Write a function that takes in a list of strings and returns 
//////    a copy of the list without duplicates. [DONE]
//////2. Write a function that calculates the class grade average after dropping 
//////    the lowest grade for each student. That is:
//////Write a function that takes in a list of strings of grades 
//////        (e.g., one string might be "90,100,82,89,55"), 
//////drops the lowest grade from each string, averages the rest of the grades 
//////    from that string, then averages the averages.

namespace LINQExpressions
{
    class LINQ
    {
        static void Main(string[] args)
        {
            //--method test for removing duplicates--//
            var testList = new List<string>();
            testList.Add("alpha");
            testList.Add("bravo");
            testList.Add("charlie");
            testList.Add("delta");
            testList.Add("alpha");
            testList.Add("charlie");
            testList.Add("echo");
            testList.Add("foxtrot");
            testList.Add("echo");

            var newList = RemoveDuplicates(testList);

            foreach(string s in newList)
            {
                Console.WriteLine(s);
            }

            //--method test for averaging students' class grades--//
            List<string> studentsGrades = new List<string>();
            studentsGrades.Add("77,88,99"); //93.5 average after removing lowest value
            studentsGrades.Add("67,78,89"); //83.5
            studentsGrades.Add("33,44,55"); //49.5 = 75.5 average of averages

            Console.WriteLine("\nClass score average = {0:0.00}", AverageMyAverages(studentsGrades));

            Console.ReadLine();
        }

        public static List<string> RemoveDuplicates(List<string> listOfDuplicates)
        {
            var distinctValuesList = listOfDuplicates.Distinct().ToList();

            //var distinctValuesList = new List<string>();

            //foreach (string item in listOfDuplicates)
            //{
            //    if (!distinctValuesList.Contains(item))
            //    {
            //        distinctValuesList.Add(item);
            //    }
            //}

            return distinctValuesList;
        }

        public static double AverageMyAverages(List<string> nonAverageList)
        {
            char[] separators = new char[] { ' ', ',' };
            string[] studentGradesArray;
            List<double> studentGrades;
            List<double> classGrades = new List<double>();

            foreach (string item in nonAverageList)
            {
                studentGradesArray = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                studentGrades = new List<double>();

                for(int i = 0; i < studentGradesArray.Count(); i++)
                {
                    studentGrades.Add(Convert.ToDouble(studentGradesArray[i]));
                }
                studentGrades.Remove(studentGrades.Min());
                classGrades.Add(studentGrades.Average());
            }

            return classGrades.Average();
        }




    }
}
