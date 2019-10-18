using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorPattern
{
    public class Context
    {
        private Stack<string> stack = new Stack<string>();
        public void push(string number)
        {
            stack.Push(number);
        }

        public string pop()
        {
            return stack.Pop();
        }
    }
}
