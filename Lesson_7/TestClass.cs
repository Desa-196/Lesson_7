using Lesson_7.CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_7
{
    internal class TestClass
    {

        [DontSave]
        public int I { get; set; }
        public char[]? C { get; set; }

        public string? S { get; set; }
        public decimal D { get; set; }

        public TestClass(int i)
        {
            I = i;
        }

        public TestClass()
        {
        }

        public TestClass(int i, char[]? c, string? s, decimal d) : this(i)
        {
            C = c;
            S = s;
            D = d;
        }

    }
}
