namespace RPNInterpreter {
    class Define : IExpression {

        private IExpression a;
        private string v;
        public Define(IExpression a, string v) {
            this.a = a;
            this.v = v;
        }

        void IExpression.Interpret(Context context) {
            a.Interpret(context);
            int value;
            if(context.d.TryGetValue(v, out value)) {
                context.d[v] = (int) context.s.Pop();
            } else {
                context.d.Add(v, (int) context.s.Pop());
            }
            
        }
    }
}