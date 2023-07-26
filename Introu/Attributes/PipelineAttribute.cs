using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PipelineAttribute : Attribute
    {
        private readonly Type _InputType;
        private readonly Type _OutputType;

        public PipelineAttribute(Type inputType, Type outputType)
        {
            _InputType = inputType;
            _OutputType = outputType;
        }
    }
}
