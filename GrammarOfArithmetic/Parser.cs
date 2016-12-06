using System;
using System.IO;
using System.Text;
using Antlr.Runtime;
using Generated;

namespace GrammarOfArithmetic
{
    public class Parser
    {
        public Parser()
        {
            try
            {
                
                // В качестве входного потока символов устанавливаем консольный ввод
                ANTLRReaderStream input = new ANTLRReaderStream(Console.In);
                // Настраиваем лексер на этот поток
                calcLexer lexer = new calcLexer(input);
                // Создаем поток токенов на основе лексера
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                // Создаем парсер
                calcParser parser = new calcParser(tokens);
                // И запускаем первое правило грамматики!!!
                parser.calc();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

    }
}
