namespace RPNInterpreter {
    public class Minus : IExpression
    {
        private IExpression left;
        private IExpression b;
        public Minus(IExpression left, IExpression right){
            this.left = left;
            this.b = right;
        }
        void IExpression.Interpret(Context context)
        {
            b.Interpret(context);
            left.Interpret(context);
            context.S.Push( context.S.Pop() -  context.S.Pop());
        }
    }
}