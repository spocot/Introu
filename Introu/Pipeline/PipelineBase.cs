using Introu.Attributes;
using OneOf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Pipeline
{
    public abstract class PipelineBase
    {
        private PipelineAttribute _Attribute { get; set; }

        protected PipelineBase()
        {
            Attribute? attribute = Attribute.GetCustomAttribute(this.GetType(), typeof(PipelineAttribute));

            if (attribute is null)
                throw new InvalidOperationException($"PipelineBase instance {this.GetType().FullName} is missing required Pipeline attribute");

            _Attribute = (PipelineAttribute)attribute;
        }

        public void Run()
        {
            var fieldList = from fi in this.GetType().GetFields() select (OneOf<FieldInfo, PropertyInfo>)fi;
            var propertyList = from pi in this.GetType().GetProperties() select (OneOf<FieldInfo, PropertyInfo>)pi;

            // Use null coalesce to avoid issues
            var memberList = fieldList.Concat(propertyList);

            IOrderedEnumerable<(OneOf<FieldInfo, PropertyInfo>, StageAttribute?)> orderedStages =
                memberList.Select(m =>
                {
                    return m.Match<(OneOf<FieldInfo, PropertyInfo>, StageAttribute?)>(
                        fi => (fi, (StageAttribute?)Attribute.GetCustomAttribute(fi, typeof(StageAttribute))),
                        pi => (pi, (StageAttribute?)Attribute.GetCustomAttribute(pi, typeof(StageAttribute))));
                }).Where(memAtt => memAtt.Item2 is not null).OrderBy(memAtt => memAtt.Item2!.StageNumber);

            foreach (var stage in orderedStages)
            {
                OneOf<FieldInfo, PropertyInfo> field = stage.Item1;
                StageAttribute attr = stage.Item2!; // Not null assumption is safe given above .Where()

                string name = field.Match(fi => fi.Name, pi => pi.Name);
                Console.WriteLine($"Stage #{attr.StageNumber} = Field [{name}]");
            }
        }
    }
}
