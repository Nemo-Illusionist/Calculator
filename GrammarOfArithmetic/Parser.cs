using System;
using System.Collections.Generic;
using Antlr.Runtime;
using Generated;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace GrammarOfArithmetic
{
    public class Parser
    {
        private ANTLRStringStream input(string s)
        {
            s = s.ToLower().Replace(" ", "").Replace(".", ",") + "\r\n";
            return new ANTLRStringStream(s);
        }

        public string SolveEngineer(string s)
        {
            try
            {
                GrammarOfArithmeticLexer lexer = new GrammarOfArithmeticLexer(input(s));
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GrammarOfArithmeticParser parser = new GrammarOfArithmeticParser(tokens);
                return parser.calc();
            }
            catch (Exception e)
            {
                return " = " + e.Message;
            }
        }

        public List<double> SolveGraph(string s, double a, double b, double h)
        {
            List<double> y = new List<double>();
            for (double i = a<b?a:b; i < (a > b ? a : b); i +=h)
            {
                GrammarOfArithmeticLexer lexer = new GrammarOfArithmeticLexer(input(s.Replace("x", i.ToString())));
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GrammarOfArithmeticParser parser = new GrammarOfArithmeticParser(tokens);
                y.Add(parser.graph());

            }
            
            
            return y;
        }

        public string SolveCurrency(string s)
        {
            try
            {
                
                GrammarOfCurrencyLexer lexer = new GrammarOfCurrencyLexer(input(s));
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GrammarOfCurrencyParser parser = new GrammarOfCurrencyParser(tokens);

                return " = " + parser.calc();
            }
            catch (Exception e)
            {
                return " = " + e.Message;
            }
        }

    }
}
