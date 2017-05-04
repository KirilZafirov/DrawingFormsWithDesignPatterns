using MultiplePatternsHomework.Shapes;
using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;


namespace MultiplePatternsHomework
{
    class Program
    {   
        static void Main(string[] args)
        {

            var myApp = new HelperFunctions();
            var answer = new List<AbstractShape>();
            myApp.Action(answer);
            
            //The following implementation is with the Implemented Iterator Pattern
            //AbstractShape collection = new Circle();
            //collection[0] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //collection[1] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //collection[2] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //collection[3] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //collection[4] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //collection[5] = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //ListShapesWithIterator(collection);

            //var c = new Circle(10, 10, 20, Enumerations.ColorEnum.Blue, false, false, "Circle");
            //var managerCommand = new ShapeManager(c);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
