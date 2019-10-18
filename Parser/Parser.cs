using System.Collections.Generic;
using RPNInterpreter;
using System;
using System.Text.RegularExpressions;

namespace RPNParser {
    class Parser {
        enum TokenName {Operator, Literal, Identifier};

        public IExpression parse(string input) {
            Stack<Tuple<TokenName, string>> tokens = tokenization(Reverse(input));
            return new Number(1);
        }

        private Stack<Tuple<TokenName, string>> tokenization(string input) {
            Stack<Tuple<TokenName, string>> result = new Stack<Tuple<TokenName, string>>();
            string[] tokens = input.Split(null);
            foreach(string t in tokens){
                if (Regex.IsMatch(t, @"^[0-9]+$")) {
                    result.Push(new Tuple<TokenName, string>(TokenName.Literal, t));
                } else if (Regex.IsMatch(t, @"^[a-z]") && t.Length==1) {
                    result.Push(new Tuple<TokenName, string>(TokenName.Identifier, t));
                } else if (Regex.IsMatch(t, @"^[=+-/*]") && t.Length==1) {
                    result.Push(new Tuple<TokenName, string>(TokenName.Operator, t));
                }
                else {
                    throw new InvalidTokenException(t + " is not recognized as a valid token");
                }
            }
            return result;
        }

        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class InvalidTokenException : Exception {
        public InvalidTokenException(string message)
        : base(message)
        {
        }
    }
}
