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
            
          

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
