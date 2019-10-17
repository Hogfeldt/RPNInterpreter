using System;

namespace InterpretorPattern
{
    internal class NumberExpression : AbstractExpression, ITerminalExpression
    {

        public NumberExpression(DigitExpression digitExpression)
        {
            Left = digitExpression;
        }

        public NumberExpression(DigitExpression digitExpression, NumberExpression numberExpression)
        {
            Left = digitExpression;
            Right = numberExpression;
        }


        public override void Interpret(Context context)
        {
            Left.Interpret(context);

            if (Right != null)
            {
                Right.Interpret(context);
                string a = context.pop();
                string b = context.pop();
                context.push(a+b);
            }
            
        }
    }
}