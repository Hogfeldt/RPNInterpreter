using System.Collections;
using System.Collections.Generic;

namespace RPNInterpreter {
    class Context
    {
        public Stack s {get;}
        public Dictionary<string, int> d {get;}
        public Context() {
            s = new Stack();
            d = new Dictionary<string, int>();
        }
    }
}