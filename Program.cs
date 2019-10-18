using System;

namespace RPNInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context();
            IExpression e = new Define(new Minus(new Number(5, new Number(0)), new Number(2)), "a");
            e.Interpret(c);
            IExpression e2 = new Plus(new Number(1), new Variable("a"));
            e2.Interpret(c);
            Console.WriteLine(c.s.Pop());

        }
    }
}
