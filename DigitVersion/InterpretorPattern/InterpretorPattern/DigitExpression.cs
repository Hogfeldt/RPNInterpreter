namespace InterpretorPattern
{
    internal class DigitExpression : AbstractExpression
    {
        private readonly string _digit;

        public DigitExpression(string digit)
        {
            _digit = digit;
        }
        public override void Interpret(Context context)
        {
            int digitNumber = int.Parse(_digit);
            if (digitNumber >= 0 && digitNumber < 10)
            {
                context.push(_digit);
            }
        }
    }
}