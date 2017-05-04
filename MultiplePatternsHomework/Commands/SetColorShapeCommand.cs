using MultiplePatternsHomework.Enumerations;
using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Commands
{
    class SetColorShapeCommand : Command
    {
        private ColorEnum _color;
        private ColorEnum _oldColor;

        public SetColorShapeCommand(ColorEnum color)
        {
            _color = color;
        }

        public SetColorShapeCommand(AbstractShape shape, ColorEnum color)
        {
            _shape = shape;
            _color = color;
        }

        public override void Execute()
        {
            if(_shape != null)
            {
                _oldColor = _shape.Color;
                _shape.Color = _color;
            }
        }

        public override void UnExecute()
        {
            if(_shape != null)
                _shape.Color = _oldColor;
        }
    }
}
