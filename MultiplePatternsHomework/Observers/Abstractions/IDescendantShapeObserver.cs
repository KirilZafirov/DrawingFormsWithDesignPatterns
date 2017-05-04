using MultiplePatternsHomework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Observers.Abstractions
{
    public interface IDescendantShapeObserver
    {
         void Update(Command command);
    }
}
