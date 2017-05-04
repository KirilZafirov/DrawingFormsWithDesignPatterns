using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Shapes
{
    interface ISquare : IShape
    {
        double Height { get; set; }
        double Width { get; set; }
    }
}
