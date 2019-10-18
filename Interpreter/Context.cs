using System.Collections.Generic;

namespace RPNInterpreter {
    class Context
    {
        public Stack<int> s {get;}
        public Dictionary<string, int> d {get;}
        public Context() {
            s = new Stack<int>();
            d = new Dictionary<string, int>();
        }
    }
}