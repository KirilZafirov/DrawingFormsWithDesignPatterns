using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Iterator
{
    public interface  IAbstractIterator
    {
         AbstractShape First();
         AbstractShape Next();
         bool IsDone();
         AbstractShape CurrentItem();
    }
}
