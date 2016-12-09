using System;
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

        public string SolveCurrency(string s)
        {
            try
            {
                
                GrammarOfCurrencyLexer lexer = new GrammarOfCurrencyLexer(input(s));
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GrammarOfCurrencyParser parser = new GrammarOfCurrencyParser(tokens);

                return parser.calc();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
