using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Abstractions
{
    public interface IIntrouTransformer<TInput, TOutput>
    {
        public TOutput Transform(TInput input);
    }
}
