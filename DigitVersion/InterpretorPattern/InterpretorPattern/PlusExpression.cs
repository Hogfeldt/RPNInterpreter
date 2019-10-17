namespace InterpretorPattern
{
    internal class PlusExpression : AbstractExpression, ITerminalExpression
    {
        public PlusExpression(AbstractExpression left, AbstractExpression right)
        {
            Left = left;
            Right = right;
        }
        public override void Interpret(Context context)
        {
            Left.Interpret(context);
            Right.Interpret(context);
            int result = int.Parse(context.pop()) + int.Parse(context.pop());
            context.push(result.ToString());
        }
    }
}