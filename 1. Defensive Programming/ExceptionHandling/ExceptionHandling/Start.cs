using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
   public class Start
    {
        static void Main()
        {
            ExceptionsHomework exceptionsHomework = new ExceptionsHomework(); 
            
            var substr = exceptionsHomework.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = exceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(String.Join(" ", subarr));

            var allarr = exceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(String.Join(" ", allarr));

            var emptyarr = exceptionsHomework.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(String.Join(" ", emptyarr));

            Console.WriteLine(exceptionsHomework.ExtractEnding("I love C#", 2));
            Console.WriteLine(exceptionsHomework.ExtractEnding("Nakov", 4));
            Console.WriteLine(exceptionsHomework.ExtractEnding("beer", 4));
            Console.WriteLine(exceptionsHomework.ExtractEnding("Hi", 2/*100*/));

            try
            {
                exceptionsHomework.CheckPrime(23);
                Console.WriteLine("23 is prime.");
            }
            catch (ArgumentException ex)
            {
                //Console.WriteLine("23 is not prime");
                Console.WriteLine(ex.Message);
            }

            try
            {
                exceptionsHomework.CheckPrime(33);
                Console.WriteLine("33 is prime.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message/*"33 is not prime"*/);
            }

            List<IExam> peterExams = new List<IExam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
