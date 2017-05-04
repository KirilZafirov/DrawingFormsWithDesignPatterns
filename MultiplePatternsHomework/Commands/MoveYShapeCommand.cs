using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Shapes.Abstractions;

namespace MultiplePatternsHomework.Commands
{
    class MoveYShapeCommand : Command
    {
        private double _deltaY;

        public MoveYShapeCommand(double deltaY)
        {
            _deltaY = deltaY;
        }

        public MoveYShapeCommand(AbstractShape shape, double deltaY)
        {
            _shape = shape;
            _deltaY = deltaY;
        }

        public override void Execute()
        {
            if(_shape != null)
                _shape.MoveY(_deltaY);
        }

        public override void UnExecute()
        {
            if (_shape != null)
                _shape.MoveY(-_deltaY);
        }
    }
}
