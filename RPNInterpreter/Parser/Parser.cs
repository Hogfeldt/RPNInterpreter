using System.Collections.Generic;
using RPNInterpreter;
using System;
using System.Text.RegularExpressions;

namespace RPNParser {
    class Parser {
        enum TokenName {Operator, Literal, Identifier};

        public IExpression parse(string input) {
            Stack<Tuple<TokenName, string>> tokens = tokenization(input);
            Tuple<TokenName, string> root = tokens.Peek();
            IExpression result = null;
            // Defining a variable is a bit special and should therefore be handled seperatly 
            if(root.Item1 == TokenName.Identifier) {
                root = tokens.Pop();
                if (tokens.Count == 0) {
                    result = new Variable(root.Item2);
                } else {
                    Tuple<TokenName, string> second = tokens.Pop();
                    if(second.Item1 == TokenName.Operator && second.Item2 == "=") {
                        result = new Define(buildSubtree(tokens), root.Item2);
                    } else {
                        throw new SyntaxErrorException("A variable cannot be followed by: "+ second.Item2);
                    }
                }
            } else {
                result = buildSubtree(tokens);
            }
            if (tokens.Count != 0) {
                throw new SyntaxErrorException("Not valid syntax");
            } 
            return result;
        }

        private IExpression buildSubtree(Stack<Tuple<TokenName, string>> tokens) {
            Tuple<TokenName, string> curr_t = tokens.Pop();
            if(curr_t.Item1 == TokenName.Literal) {
                return getNumSubTree(curr_t.Item2);
            } else if (curr_t.Item1 == TokenName.Identifier) {
                return new Variable(curr_t.Item2);
            } else {
                IExpression left = buildSubtree(tokens);
                IExpression right = buildSubtree(tokens);
                if(curr_t.Item2 == "+") {
                    return new Plus(left, right);
                } else if (curr_t.Item2 == "-") {
                    return new Minus(right, left);
                } else if (curr_t.Item2 == "*") {
                    return new Multiply(left, right);
                } else if (curr_t.Item2 == "/") {
                    return new Divide(right, left);
                } else {
                throw new SyntaxErrorException("We don't know what just happend, good luck!");
                }
            } 
        }

        private IExpression getNumSubTree(string n) {
            Stack<char> tokens = new Stack<char>();
            char[] char_n = n.ToCharArray();
            Array.Reverse(char_n);
            foreach(char c in char_n) {
                tokens.Push(c);
            }
            return generateNumSubTree(tokens);
        }

        private IExpression generateNumSubTree(Stack<char> tokens) {
            char root = tokens.Pop();
            if (tokens.Count == 0) {
                return new Number(Convert.ToInt32(Char.GetNumericValue(root)));
            }
            Number child = (Number) generateNumSubTree(tokens);
            return new Number(Convert.ToInt32(Char.GetNumericValue(root)), child);
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
    }

    class InvalidTokenException : Exception {
        public InvalidTokenException(string message)
        : base(message)
        {
        }
    }
    class SyntaxErrorException : Exception {
        public SyntaxErrorException(string message)
        : base(message)
        {
        }
    }
}
