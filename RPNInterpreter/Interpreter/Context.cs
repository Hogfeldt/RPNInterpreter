using System.Collections.Generic;

namespace RPNInterpreter {
    public class Context
    {
        public Stack<int> s {get;}
        public Dictionary<string, int> d {get;}
        public Context() {
            s = new Stack<int>();
            d = new Dictionary<string, int>();
        }
        // For testing purpose
        public Context(Stack<int> s, Dictionary<string, int> d) {
            this.s = s;
            this.d = d;
        }
    }
}