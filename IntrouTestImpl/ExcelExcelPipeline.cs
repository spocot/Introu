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
        public string T1 = "1";

        [Stage(2)]
        public string T2 = "2";

        [Stage(3)]
        public string T3 = "3";

        [Stage(4)]
        public string T4 = "4";

        [Stage(5)]
        public string T5 { get; set; }

        public ExcelExcelPipeline()
        {
            T5 = "5";
        }
    }
}
