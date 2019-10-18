namespace RPNInterpreter {

    class Number : IExpression
    {
        private int n;
        public Number(int n){
            this.n = n;
        }
        void IExpression.Interpret(Context context)
        {
            context.s.Push(n);
        }
    }
}