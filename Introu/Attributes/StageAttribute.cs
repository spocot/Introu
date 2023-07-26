using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class StageAttribute : Attribute
    {
        public int StageNumber { get; init; }

        public StageAttribute(int stageNumber) => StageNumber = stageNumber;
    }
}
