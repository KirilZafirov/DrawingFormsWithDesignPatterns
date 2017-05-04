using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Shapes.Abstractions;

namespace MultiplePatternsHomework.Commands
{
    class ScaleShapeCommand : Command
    {
        private double _factor;

        public ScaleShapeCommand(double factor)
        {
            _factor = factor;
        }

        public ScaleShapeCommand(AbstractShape shape, double factor)
        {
            _shape = shape;
            _factor = factor;
        }

        public override void Execute()
        {
            if(_shape != null)
                _shape.Scale(_factor);
        }

        public override void UnExecute()
        {
            if (_shape != null)
                _shape.Scale(1/_factor);
        }
    }
}
