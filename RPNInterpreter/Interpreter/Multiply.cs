
namespace RPNInterpreter {
    class Multiply : IExpression {
        private IExpression left;
        private IExpression right;
        public Multiply(IExpression left, IExpression right){
            this.left = left;
            this.right = right;
        }
        void IExpression.Interpret(Context context)
        {
            left.Interpret(context);
            right.Interpret(context);
            context.s.Push(context.s.Pop() * context.s.Pop());
        }
    }
}