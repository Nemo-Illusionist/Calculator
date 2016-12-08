using System;
using Antlr.Runtime;
using Generated;

namespace GrammarOfArithmetic
{
    public class Parser
    {


        public string SolveEngineer(string s)
        {
            try
            {
                s = s.ToLower().Replace(" ", "").Replace(".",",") + "\r\n";
                ANTLRStringStream input = new ANTLRStringStream(s);
                //ANTLRReaderStream input = new ANTLRReaderStream(Console.In);
                GrammarOfArithmeticLexer lexer = new GrammarOfArithmeticLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                GrammarOfArithmeticParser parser = new GrammarOfArithmeticParser(tokens);
                return parser.calc();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string SolveCurrency(string s)
        {
            try
            {
                
                s = s.ToLower().Replace(" ", "").Replace(".", ",") + "\r\n";
                ANTLRStringStream input = new ANTLRStringStream(s);
                //ANTLRReaderStream input = new ANTLRReaderStream(Console.In);
                GrammarOfCurrencyLexer lexer = new GrammarOfCurrencyLexer(input);
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
