using Introu.Abstractions;
using Introu.Attributes;
using Introu.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntrouTestImpl
{
    [Pipeline(typeof(string), typeof(string))]
    internal class ExcelExcelPipeline : PipelineBase
    {
        [Stage(1)]
        public StringStringTransformer T1;

        [Stage(2)]
        public IIntrouTransformer<string, string> T2;

        [Stage(3)]
        public IIntrouTransformer<string, string> T3;

        [Stage(4)]
        public IIntrouTransformer<string, string> T4;

        [Stage(5)]
        public StringStringTransformer T5 { get; set; }

        public ExcelExcelPipeline()
        {
            var sst = new StringStringTransformer();
            T1 = sst;
            T2 = sst;
            T3 = sst;
            T4 = sst;
            T5 = sst;
        }
    }
}
