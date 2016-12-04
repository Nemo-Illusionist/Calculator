using System;
using Antlr.Runtime;
using Generated;

namespace GrammarOfArithmetic
{
    class Parser
    {
        Parser()
        {
            try
            {
                // В качестве входного потока символов устанавливаем консольный ввод
                ANTLRReaderStream input = new ANTLRReaderStream(Console.In);
                // Настраиваем лексер на этот поток
                GrammarOfArithmeticLexer lexer = new GrammarOfArithmeticLexer(input);
                // Создаем поток токенов на основе лексера
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                // Создаем парсер
                GrammarOfArithmeticParser parser = new GrammarOfArithmeticParser(tokens);
                // И запускаем первое правило грамматики!!!
                parser.calc();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
