namespace RPNInterpreter {
    public class Define : IExpression {

        private IExpression value;
        private string name;
        public Define(IExpression value, string name) {
            this.value = value;
            this.name = name;
        }

        void IExpression.Interpret(Context context) {
            this.value.Interpret(context);
            int value;
            if(context.d.TryGetValue(name, out value)) {
                context.d[name] = context.s.Pop();
            } else {
                context.d.Add(name, context.s.Pop());
            }
            
        }
    }
}