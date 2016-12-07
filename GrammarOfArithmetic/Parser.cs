using System;
using System.IO;
using Antlr.Runtime;
using Generated;

namespace GrammarOfArithmetic
{
    public class Parser
    {
        public string SolveEngineer(string s)
        {
            ANTLRReaderStream input = new ANTLRReaderStream(new StringReader(s));
            GrammarOfArithmeticLexer lexer = new GrammarOfArithmeticLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            GrammarOfArithmeticParser parser = new GrammarOfArithmeticParser(tokens);
            return parser.calc();
        }

    }
}
