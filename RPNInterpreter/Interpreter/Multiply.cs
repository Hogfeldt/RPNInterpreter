
namespace RPNInterpreter {
    public class Multiply : IExpression {
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
            context.S.Push(context.S.Pop() * context.S.Pop());
        }
    }
}