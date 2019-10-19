using System.Collections.Generic;

namespace RPNInterpreter {
    public class Context
    {
        public Stack<int> S {get;}
        public Dictionary<string, int> D {get;}
        public Context() {
            S = new Stack<int>();
            D = new Dictionary<string, int>();
        }
        // For testing purpose
        public Context(Stack<int> s, Dictionary<string, int> d) {
            this.S = s;
            this.D = d;
        }
    }
}