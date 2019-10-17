namespace InterpretorPattern
{
    internal class MinusExpression : AbstractExpression, ITerminalExpression
    {
        public MinusExpression(AbstractExpression left, AbstractExpression right)
        {
            Left = left;
            Right = right;
        }
        public override void Interpret(Context context)
        {
            Left.Interpret(context);
            Right.Interpret(context);
            int b = int.Parse(context.pop());
            int a = int.Parse(context.pop());
            context.push((a-b).ToString());
        }
    }
}