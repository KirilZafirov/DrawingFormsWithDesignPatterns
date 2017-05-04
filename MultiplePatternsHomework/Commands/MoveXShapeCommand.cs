using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Shapes.Abstractions;

namespace MultiplePatternsHomework.Commands
{
    class MoveXShapeCommand : Command
    {
        private double _deltaX;

        public MoveXShapeCommand(double deltaX)
        {
            _deltaX = deltaX;
        }

        public MoveXShapeCommand(AbstractShape shape, double deltaX)
        {
            _shape = shape;
            _deltaX = deltaX;
        }

        public override void Execute()
        {
            if(_shape != null)
                _shape.MoveX(_deltaX);
        }
        
        public override void UnExecute()
        {
            if (_shape != null)
                _shape.MoveX(-_deltaX);
        }
    }
}
