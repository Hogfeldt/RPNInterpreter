namespace RPNInterpreter {
    class Divide : IExpression {
        private IExpression a;
        private IExpression b;
        public Divide(IExpression a, IExpression b){
            this.a = a;
            this.b = b;
        }
        void IExpression.Interpret(Context context)
        {
            b.Interpret(context);
            a.Interpret(context);
            context.s.Push((int) context.s.Pop() / (int) context.s.Pop());
        }
    }
}