using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        public List<double> SolveGraph(string s, List<double> x)
        {
            return (from i in x select 
                    new GrammarOfArithmeticLexer(input("x="+ i + "\r\n" + s)) 
                    into lexer select new CommonTokenStream(lexer) 
                    into tokens select new GrammarOfArithmeticParser(tokens) 
                    into parser select parser.graph()).ToList();
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
