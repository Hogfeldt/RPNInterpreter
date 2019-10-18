using System;
using RPNInterpreter;
using RPNParser;

class Program
{
    static void Main(string[] args)
    {
        
        Parser p = new Parser();
        IExpression e1 = p.parse("120 = a");
        Context c = new Context();
        e1.Interpret(c);
        IExpression e2 = p.parse("a 21 *");
        e2.Interpret(c);
        Console.WriteLine(c.s.Pop());
        /*Context c = new Context();
        IExpression e = new Define(new Minus(new Number(5, new Number(0)), new Number(2)), "a");
        e.Interpret(c);
        IExpression e2 = new Plus(new Number(1), new Variable("a"));
        e2.Interpret(c);
        Console.WriteLine(c.s.Pop());
        */
    }
}
