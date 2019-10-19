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
            int newValue = context.S.Pop();
            if(context.D.TryGetValue(name, out oldValue)) {
                context.D[name] = newValue;
            } else {
                context.D.Add(name, newValue);
            }
            context.S.Push(newValue);
            
        }
    }
}
