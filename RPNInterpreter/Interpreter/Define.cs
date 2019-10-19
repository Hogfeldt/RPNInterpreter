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
            if(context.D.TryGetValue(name, out value)) {
                context.D[name] = context.S.Pop();
            } else {
                context.D.Add(name, context.S.Pop());
            }
            
        }
    }
}