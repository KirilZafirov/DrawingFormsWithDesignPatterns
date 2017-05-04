using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Shapes.Abstractions;

namespace MultiplePatternsHomework.Iterator
{
    public class MyIteratorClass : IAbstractIterator
    {
        private AbstractShape _collection;
        private int _current = 0;
        private int _step = 1;
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public MyIteratorClass(AbstractShape collection)
        {
            _collection = collection;
        }

        public AbstractShape CurrentItem()
        {
            return _collection[_current] as AbstractShape; 
        }

        public AbstractShape First()
        {
            _current = 0;
            return _collection[_current] as AbstractShape;
        }

        public bool IsDone()
        {
            return _current >= _collection.Count; 
        }

        public AbstractShape Next()
        {
            _current += _step;
            if (!IsDone())
                return _collection[_current] as AbstractShape;
            else
                return null;
        }
    }
   
}
