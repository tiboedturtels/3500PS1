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


            exp = Regex.Replace(exp, " ", "");
            string[] substrings = Regex.Split(exp, "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)");

            for(int i = 0; i < substrings.Length; i++)
            {
                Double Result;
                if (Double.TryParse(substrings[i], out Result))
                    numInstructions(Result, nums, operators);

                else if (substrings[i] == "+" || substrings[i] == "-")
                    addsubInstructions(substrings[i], nums, operators);

                else if (substrings[i] == "*" || substrings[i] == "/")
                    multdivInstructions(substrings[i], nums, operators);
            }

            if (operators.Count != 0)
                return (int) Operate(nums.Pop(), nums.Pop(), operators.Pop());
            return (int) nums.Pop();
        }

        /// <summary>
        /// Completes a single operation on two Doubles
        /// </summary>
        /// <param name="num1"> The first operand </param>
        /// <param name="num2"> The second operand </param>
        /// <param name="operation"> The operation to be performed </param>
        /// <returns> The Double value of the evaluated operation </returns>
        public static Double Operate(Double num2, Double num1, String operation)
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


        private static void numInstructions(Double input, Stack<Double> numStack, Stack<String> opStack)
        {
            if (opStack.Count != 0 && (opStack.Peek() == "*" || opStack.Peek() == "/"))
                numStack.Push(Operate(input, numStack.Pop(), opStack.Pop()));

            else
                numStack.Push(input);
        }

        private static void addsubInstructions(String op, Stack<Double> numStack, Stack<String> opStack)
        {
            if (opStack.Count != 0 && (opStack.Peek() == "+" || opStack.Peek() == "-"))
                numStack.Push(Operate(numStack.Pop(), numStack.Pop(), opStack.Pop()));
            opStack.Push(op);
        }

        private static void multdivInstructions(String op, Stack<Double> numStack, Stack<String> opStack)
        {
            opStack.Push(op);
        }

    }
}
