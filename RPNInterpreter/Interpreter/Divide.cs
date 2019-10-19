namespace RPNInterpreter {
    public class Divide : IExpression {
        private IExpression left;
        private IExpression right;
        public Divide(IExpression left, IExpression right){
            this.left = left;
            this.right = right;
        }
        void IExpression.Interpret(Context context)
        {
            right.Interpret(context);
            left.Interpret(context);
            context.s.Push(context.s.Pop() /  context.s.Pop());
        }
    }
}