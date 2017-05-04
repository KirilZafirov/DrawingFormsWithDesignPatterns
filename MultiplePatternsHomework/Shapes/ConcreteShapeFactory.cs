using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Shapes
{
    public class ConcreteShapeFactory : ShapeCreatorFactory
    {
        public override AbstractShape GetShape(string Shape)
        {
            switch (Shape)
            {
                case "Circle":
                    return new Circle();
                case "Square":
                    return new Square();
                default:
                    throw new ApplicationException(string.Format("Shape'{0}' cannot be created", Shape));
            }
        }
    }
}
