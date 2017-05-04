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
    class Square : AbstractShape, ISquare
    {
        public Square()
        {
        }
  
        public Square(double x, double y, double h,double w, ColorEnum color , bool isClone,bool isDeleted , string type)
        {
            X = x;
            Y = y;
            Height = h;
            Width = w;
            _color = color;
            Type = type;
            IsClone = isClone;
            IsDeleted = isDeleted;
        }
        double h = 0, w = 0;
        public double Height
        {
            get
            {
                return h;
            }
            set
            {
                if (value < 0)
                {
                    h = 0;
                }
                else if (value > 800)
                {
                    h = 800;
                }
                else
                    h = value;
            }
        }
        public double Width
        {
            get
            {
                return w;
            }
            set
            {
                if (value < 0)
                {
                    w = 0;
                }
                else if (value > 800)
                {
                    w = 800;
                }
                else
                    w = value;
            }
        }
        public override void Scale(double factor)
        {
            Height *= factor;
            Width *= factor;

            var scaleShapeCommand = new ScaleShapeCommand(factor);
            Notify(scaleShapeCommand);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine(String.Format("Height: {0}", Height));
            sb.AppendLine(String.Format("Width: {0}", Width));
            sb.AppendLine(String.Format("Type: {0}", Type));
            return sb.ToString();
        }
    }
}
