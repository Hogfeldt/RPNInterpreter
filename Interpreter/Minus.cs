namespace RPNInterpreter {
    class Minus : IExpression
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
            context.s.Push( context.s.Pop() -  context.s.Pop());
        }
    }
}