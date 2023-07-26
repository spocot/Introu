using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introu.Abstractions
{
    public interface IIntrouReader<TOutput>
    {
        public TOutput Read();
    }
}
