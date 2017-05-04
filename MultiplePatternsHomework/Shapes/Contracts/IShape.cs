using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Enumerations;

namespace MultiplePatternsHomework.Shapes
{
    interface IShape
    {
        double X { get; set; }
        double Y { get; set; }
        ColorEnum Color { get; set; }
    }
}
