using System;

namespace RPNInterpreter {
    public class Variable : IExpression
    {
        string v;
        public Variable(string v) {
            this.v=v;
        }
        void IExpression.Interpret(Context context)
        {
            int value;
            if(context.D.TryGetValue(v,out value))
            {
                context.S.Push(value);
            }
            else {
                throw new VariableNotFoundException();
            }
        }
    }

    class VariableNotFoundException : Exception {

        public VariableNotFoundException()
        {
        }
    }
}