using System;

namespace RPNInterpreter {
    class Variable : IExpression
    {
        string v;
        public Variable(string v) {
            this.v=v;
        }
        void IExpression.Interpret(Context context)
        {
            int value;
            if(context.d.TryGetValue(v,out value))
            {
                context.s.Push(value);
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
    
        public VariableNotFoundException(string message)
        : base(message)
        {
        }

        public VariableNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}