using System;

namespace RPNInterpreter {

    class Number : IExpression
    {
        private int digit;
        private Number child = null;
        public int numOfChildren {get;}

        public Number(int digit){
            if(-1<digit && digit<10) {
                this.digit = digit;
            }
            else {
                throw new ArgumentException("Digit should be an int from 0-9");
            }
            numOfChildren = 0;
        }

        public Number(int digit, Number child){
            if(-1<digit && digit<10) {
                this.digit = digit;
            }
            else {
                throw new ArgumentException("Digit should be an int from 0-9");
            }
            this.child = child;
            numOfChildren = child.numOfChildren+1;
        }

        void IExpression.Interpret(Context context)
        {
            if(child != null) {
                IExpression c = (IExpression) child;
                c.Interpret(context);
                int childVal = context.s.Pop();
                context.s.Push((digit * Convert.ToInt32(Math.Pow(Convert.ToDouble(10),Convert.ToDouble(numOfChildren)))) + childVal);
            }
            else {
                context.s.Push(digit);
            }
        }
    }
}