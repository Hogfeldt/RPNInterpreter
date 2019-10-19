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
            int oldValue;
            int newValue = context.s.Pop();
            if(context.d.TryGetValue(name, out oldValue)) {
                context.d[name] = newValue;
            } else {
                context.d.Add(name, newValue);
            }
            context.s.Push(newValue);
            
        }
    }
}