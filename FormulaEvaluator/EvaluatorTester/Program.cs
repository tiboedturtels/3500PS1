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
            Console.WriteLine(Evaluator.Operate(1.0, 2.0, "/"));
            Console.Read();
        }
    }
}
