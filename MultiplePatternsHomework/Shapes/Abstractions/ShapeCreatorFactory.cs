using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Shapes.Abstractions
{
   public abstract class ShapeCreatorFactory
    {
        public abstract AbstractShape GetShape(string Shape);
    }
}
