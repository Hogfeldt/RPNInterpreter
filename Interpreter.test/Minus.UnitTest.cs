using RPNInterpreter;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class MinusUnitTest
    {
        private IExpression _uut;
        private IExpression _a;
        private IExpression _b;
        private Context _context;
        [SetUp]
        public void Setup()
        {
            _a = Substitute.For<IExpression>();
            _b = Substitute.For<IExpression>();
            _uut = new Minus(_a, _b);
            _context = new Context(Substitute.For<Stack<int>>(), Substitute.For<Dictionary<string, int>>());
        }

        [TestCase(1, 1, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(-3, 1, -4)]
        [TestCase(-3, -3, 0)]


        public void Minus_UnitTest(int a, int b, int result)
        {
            _context.S.Push(a);
            _context.S.Push(b);

            _uut.Interpret(_context);

            _a.Received().Interpret(_context);
            _b.Received().Interpret(_context);

            _context.S.Received(2).Pop();
            _context.S.Received().Push(result);
        }
    }
}
