using MultiplePatternsHomework.Observers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Commands;
using MultiplePatternsHomework.Shapes.Abstractions;

namespace MultiplePatternsHomework.Observers
{
    class DescendantShapeObserver : IDescendantShapeObserver
    {
        private AbstractShape _shape;

        public AbstractShape Shape
        {
            get { return _shape; }
        }

        public DescendantShapeObserver(AbstractShape shape)
        {
            _shape = shape;
        }

   

        public void Update(Command command)
        {
            command.Shape = _shape;
            command.Execute();
        }
    }
}
