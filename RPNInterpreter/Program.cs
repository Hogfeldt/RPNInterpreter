using System;
using RPNInterpreter;
using RPNParser;

class Program
{
    static void Main(string[] args)
    {
        Parser p = new Parser();
        Context c = new Context();
        while(true) {
            Console.Write('>');
            string input = Console.ReadLine();
            IExpression e = p.parse(input);
            e.Interpret(c);
            if (c.s.Count != 0) {
                Console.WriteLine(c.s.Pop());
            }
        }
    }
}
