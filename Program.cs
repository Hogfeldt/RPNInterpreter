using System;

namespace RPNInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            Expression e = new Define(new Minus(new Number(10), new Number(2)), "a");
            e.Interpret(c);
            Expression e2 = new Plus(new Number(1), new Variable("a"));
            e2.Interpret(c);
            Console.WriteLine(c.s.Pop());

        }
    }
}
