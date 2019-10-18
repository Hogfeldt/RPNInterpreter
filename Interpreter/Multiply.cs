
namespace RPNInterpreter {
    class Multiply : IExpression {
        private IExpression a;
        private IExpression b;
        public Multiply(IExpression a, IExpression b){
            this.a = a;
            this.b = b;
        }
        void IExpression.Interpret(Context context)
        {
            a.Interpret(context);
            b.Interpret(context);
            context.s.Push((int) context.s.Pop() * (int) context.s.Pop());
        }
    }
}