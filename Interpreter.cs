using System;
using System.Collections;
using System.Collections.Generic;

namespace RPNInterpreter {
    class Context
    {
        public Stack s {get;}
        public Dictionary<string, int> d {get;}
        // Create variable map 
        public Context() {
            s = new Stack();
            d = new Dictionary<string, int>();
        }
    }

    abstract class Expression
    {
        public abstract void Interpret(Context context);
    }

    class Define : Expression {

        private Expression a;
        private string v;
        public Define(Expression a, string v) {
            this.a = a;
            this.v = v;
        }

        public override void Interpret(Context context) {
            a.Interpret(context);
            int value;
            if(context.d.TryGetValue(v, out value)) {
                context.d[v] = (int) context.s.Pop();
            } else {
                context.d.Add(v, (int) context.s.Pop());
            }
            
        }
    }

    class Variable : Expression
    {
        string v;
        public Variable(string v) {
            this.v=v;
        }
        public override void Interpret(Context context)
        {
            int value;
            if(context.d.TryGetValue(v,out value))
            {
                context.s.Push(value);
            }
            else {
                throw new Exception();
            }
        }
    }

    class Plus : Expression
    {
        private Expression a;
        private Expression b;
        public Plus(Expression a, Expression b){
            this.a = a;
            this.b = b;
        }
        public override void Interpret(Context context)
        {
            a.Interpret(context);
            b.Interpret(context);
            context.s.Push((int) context.s.Pop() + (int) context.s.Pop());
        }
    }

    class Multipli : Expression {
        private Expression a;
        private Expression b;
        public Multipli(Expression a, Expression b){
            this.a = a;
            this.b = b;
        }
        public override void Interpret(Context context)
        {
            a.Interpret(context);
            b.Interpret(context);
            context.s.Push((int) context.s.Pop() * (int) context.s.Pop());
        }
    }

    class Minus : Expression
    {
        private Expression a;
        private Expression b;
        public Minus(Expression a, Expression b){
            this.a = a;
            this.b = b;
        }
        public override void Interpret(Context context)
        {
            b.Interpret(context);
            a.Interpret(context);
            context.s.Push((int) context.s.Pop() - (int) context.s.Pop());
        }
    }

    class Divide : Expression {
        private Expression a;
        private Expression b;
        public Divide(Expression a, Expression b){
            this.a = a;
            this.b = b;
        }
        public override void Interpret(Context context)
        {
            b.Interpret(context);
            a.Interpret(context);
            context.s.Push((int) context.s.Pop() / (int) context.s.Pop());
        }
    }

    class Number : Expression
    {
        private int n;
        public Number(int n){
            this.n = n;
        }
        public override void Interpret(Context context)
        {
            context.s.Push(n);
        }
    }
}