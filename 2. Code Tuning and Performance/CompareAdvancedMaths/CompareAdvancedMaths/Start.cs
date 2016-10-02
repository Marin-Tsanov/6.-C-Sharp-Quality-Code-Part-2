namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Start
    {
        public static void Main(string[] args)
        {
            IntTest testInt = new IntTest();
            testInt.StartIntTest();

            Console.WriteLine("<--------------------------------------------->");

            LongTest testLong = new LongTest();
            testLong.StartLongTest();

            Console.WriteLine("<--------------------------------------------->");

            FloatTest testFloat = new FloatTest();
            testFloat.StartFloatTest();

            Console.WriteLine("<--------------------------------------------->");

            DoubleTest testDouble = new DoubleTest();
            testDouble.StartDoubleTest();

            Console.WriteLine("<--------------------------------------------->");

            DecimalTest testDecimal = new DecimalTest();
            testDecimal.StartDecimalTest();
        }
    }
}