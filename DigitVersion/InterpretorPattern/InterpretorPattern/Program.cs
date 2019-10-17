using System;
using System.Collections.Generic;

namespace InterpretorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            // Usually a tree
           

            // Populate 'abstract syntax tree'
            DigitExpression digit1 = new DigitExpression("4");
            AbstractExpression number1 = new NumberExpression(digit1);
            DigitExpression digit2 = new DigitExpression("1");
            DigitExpression digit3 = new DigitExpression("0");
            DigitExpression digit4 = new DigitExpression("0");


            NumberExpression number2 = new NumberExpression(digit2);
            NumberExpression number3 = new NumberExpression(digit3, number2);
            NumberExpression number4 = new NumberExpression(digit4, number3);

            AbstractExpression plus1 = new PlusExpression(number1, number4);
            DigitExpression digit5 = new DigitExpression("2");
            NumberExpression number6 = new NumberExpression(digit5);
            AbstractExpression minus1 = new MinusExpression(plus1, number6);

            minus1.Interpret(context);
            Console.Write("Resulting number: ");
            Console.WriteLine(context.pop());

            // Interpret
           
        }
    }
}
