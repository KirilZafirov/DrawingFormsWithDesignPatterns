using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Commands
{
    class RemoveShapeCommand : Command
    {
        private List<AbstractShape> _shapes;

        public RemoveShapeCommand(List<AbstractShape> shapes)
        {
            _shapes = shapes;
        }

        public RemoveShapeCommand(AbstractShape shape, List<AbstractShape> shapes)
        {
            _shape = shape;
            _shapes = shapes;
        }
        
        public override void Execute()
        {
            if (_shape != null)
                _shapes.Remove(_shape);
        }

        public override void UnExecute()
        {
            if (_shape != null && _shapes.FirstOrDefault(x => x.Id == _shape.Id) == null)
                _shapes.Add(_shape);
        }
    }
}
