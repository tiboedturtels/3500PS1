using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEvaluator;


namespace EvaluatorTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Evaluator.Evaluate("5+A3", TempLookup));
            Console.Read();
        }

        static int TempLookup(String s)
        {
            return -1;
        }
    }
}
