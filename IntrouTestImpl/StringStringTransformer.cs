using Introu.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrouTestImpl
{
    internal class StringStringTransformer : IIntrouTransformer<string, string>
    {
        public string Transform(string input)
            => input + " - ";
    }
}
