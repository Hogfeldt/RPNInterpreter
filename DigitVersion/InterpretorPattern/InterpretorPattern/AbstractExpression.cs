using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace InterpretorPattern
{
    public abstract class AbstractExpression
    {
        protected AbstractExpression Left, Right;
        public abstract void Interpret(Context context);
    }
}
