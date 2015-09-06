using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FormulaEvaluator
{
    public static class Evaluator
    {
        public delegate int Lookup(String v);


        /// <summary>
        /// Evaluates an an infix expression.
        /// </summary>
        /// <param name="exp"> A string representing the expression to be evaluated. </param>
        /// <param name="variableEvaluator"> Delegate method which will return the int value of a variable. </param>
        /// <returns> Returns int value of evaluated expression. </returns>
        public static int Evaluate(String exp, Lookup variableEvaluator)
        {
            Stack<double> nums = new Stack<double>();
            Stack<String> operators = new Stack<string>();

            string[] substrings = Regex.Split("", exp);

            for(int i = 0; i < substrings.Length; i++)
            {
                Double Result;
                if(Double.TryParse(substrings[i], out Result))
                {
                    if (operators.Count != 0 && (operators.Peek() == "*" || operators.Peek() == "/"))
                        nums.Push(Operate(nums.Pop(), Result, operators.Pop()));

                    else
                        nums.Push(Result);
                }
            }

            return -1;
        }

        /// <summary>
        /// Completes a single operation on two Doubles
        /// </summary>
        /// <param name="num1"> The first operand </param>
        /// <param name="num2"> The second operand </param>
        /// <param name="operation"> The operation to be performed </param>
        /// <returns> The Double value of the evaluated operation </returns>
        public static Double Operate(Double num1, Double num2, String operation)
        {
            if (operation == "*")
                return num1 * num2;

            if (operation == "/")
                return num1 / num2;

            if (operation == "+")
                return num1 + num2;

            if (operation == "-")
                return num1 - num2;

            return -1.0;
        }

    }
}
