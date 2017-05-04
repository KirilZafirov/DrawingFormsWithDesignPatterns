using MultiplePatternsHomework.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.IteratorsPattern
{
    interface IAbstractCollection
    {
        MyIteratorClass CreateIterator();
    }
}
