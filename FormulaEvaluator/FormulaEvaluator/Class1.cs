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
        /// 
        /// </summary>
        /// <param name="exp"> A string representing the expression to be evaluated. </param>
        /// <param name="variableEvaluator"> Delegate method which will return the int value of a variable. </param>
        /// <returns> Returns int value of evaluated expression. </returns>
        public static int Evaluate(String exp, Lookup variableEvaluator)
        {
            Stack<double> nums = new Stack<double>();
            Stack<String> operators = new Stack<string>();

            string[] substrings = Regex.Split(s, exp);

            for(int i = 0; i < substrings.Length; i++)
            {
                Double Result;
                if(Double.TryParse(substrings[i], out Result))
                {
                    if()
                }
            }
        }
    }
}
