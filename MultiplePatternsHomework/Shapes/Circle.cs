using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Enumerations;
using MultiplePatternsHomework.Shapes.Abstractions;
using MultiplePatternsHomework.Generators;
using MultiplePatternsHomework.Commands;

namespace MultiplePatternsHomework.Shapes
{
    class Circle : AbstractShape, ICircle
    {
        public Circle()
        {
        }
        public Circle(double x, double y, double r, ColorEnum color,bool isClone,bool isDeleted, string type)
        {
            X = x;
            Y = y;
            Radius = r;
            _color = color;
            IsClone = isClone;
            IsDeleted = isDeleted;
            Type = type;
        }
        double r = 0;
        public double Radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value > 400)
                {
                    r = 400;
                }
                else if (value < 0)
                {
                    r = 10;
                }
                else
                    r = value;
            }
        }

 
        public override void Scale(double factor)
        {
            Radius *= factor;

            var scaleShapeCommand = new ScaleShapeCommand(factor);
            Notify(scaleShapeCommand);
        }
  
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format("Radius: {0}", Radius));
            sb.AppendLine(String.Format("Type: {0}", Type));

            return sb.ToString();
        }
    }
}
