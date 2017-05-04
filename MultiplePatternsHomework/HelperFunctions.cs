using MultiplePatternsHomework.Shapes;
using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Commands;
using MultiplePatternsHomework.Iterator;
using MultiplePatternsHomework.Enumerations;

namespace MultiplePatternsHomework
{
    public class HelperFunctions
    {
        
        static int IdNumber()
        {
            Console.WriteLine(" Give me an Id number:");
            int idOfShapeToBeCopyed = Int32.Parse(Console.ReadLine()) - 1;
            return idOfShapeToBeCopyed;
        }
        //Helper Function to decide which is the input Color
        static Enumerations.ColorEnum MakeColor()
        {
            string colorPicked;
            Console.WriteLine("Enter Color From Choice : Red ,Green ,Blue then press Enter!");
            colorPicked = Console.ReadLine();
            if (colorPicked == "Red")
            {
                return Enumerations.ColorEnum.Red;
            }
            else if (colorPicked == "Green")
            {
                return Enumerations.ColorEnum.Green;
            }
            else
            {
                return Enumerations.ColorEnum.Blue;
            }
        }
        //Helper Function to decide which is the input value for some double Number
        static double GiveValueForFieldDouble()
        {
            Console.WriteLine("Enter value Then Press Enter");
            return Double.Parse(Console.ReadLine());
        }
        //Helper Function to make the creation of circle easy 
        static Circle MakeCircle()
        {
            double x, y, r;
            Console.WriteLine("X Coordinate");
            x = GiveValueForFieldDouble();
            Console.WriteLine("Y Coordinate");
            y = GiveValueForFieldDouble();
            Console.WriteLine("Radius");
            r = GiveValueForFieldDouble();
            var myColor = MakeColor();
            return new Circle(x, y, r, myColor, false, false, "Circle");
        }
        //Helper Function to make the creation of square easy 
        static Square MakeSquare()
        {
            double x, y, h, w;

            Console.WriteLine("X Coordinate");
            x = GiveValueForFieldDouble();
            Console.WriteLine("Y Coordinate");
            y = GiveValueForFieldDouble();
            Console.WriteLine("Height");
            h = GiveValueForFieldDouble();
            Console.WriteLine("Width");
            w = GiveValueForFieldDouble();
            var myColor = MakeColor();
            return new Square(x, y, h, w, myColor, false, false, "Square");
        }
        //Even though i made a factory to decide which shape to create i decided to use this
        //helper function instead of the ConcreteShapeFactory Class
        static AbstractShape PickAShape()
        {
            //  ShapeCreatorFactory shape = new ConcreteShapeFactory();
            Console.WriteLine("Please Select a Shape to be Added:");
            Console.WriteLine("Valid values are: Circle or Square");
            string concreteShape = Console.ReadLine();
            switch (concreteShape)
            {
                case "Circle":
                    return MakeCircle();
                case "Square":
                    return MakeSquare();
                default:
                    throw new ApplicationException(string.Format("Shape'{0}' cannot be created", concreteShape));
            }
        }
        //helper Function to Clone Some shape
        static AbstractShape CloneShape(AbstractShape shape)
        {
            double x, y;

            if (shape.Type == "Circle")
            {
                Console.WriteLine("Enter DeltaX value for the Copy to be Moved and then Press Enter,Enter DeltaY value for the Copy to be Moved and then Press Enter!");
                x = Double.Parse(Console.ReadLine());
                y = Double.Parse(Console.ReadLine());
                Circle c1 = shape.Clone(x, y) as Circle;
                return c1;
            }
            else
            {
                Console.WriteLine("Enter DeltaX value for the Copy to be Moved and then Press Enter,Enter DeltaY value for the Copy to be Moved and then Press Enter!");
                x = Double.Parse(Console.ReadLine());
                y = Double.Parse(Console.ReadLine());
                Square s1 = shape.Clone(x, y) as Square;
                return s1;
            }

        }
        //helper Function to Clone specific shape
        static AbstractShape PickShapeToCopy(List<AbstractShape> shape)
        {
            Console.WriteLine("Which shape do you want to Copy?");
            return CloneShape(shape[IdNumber()]);
        }
        //helper Function to pick a command from set of commands
        static Command PickCommand(AbstractShape shape)
        {

            Console.WriteLine("Pick a Command to Do One of the Following:");
            Console.WriteLine("Color,MoveX,MoveY,Scale");
            string command = Console.ReadLine();
            switch (command)
            {
                case "Color":
                    return new SetColorShapeCommand(shape, MakeColor());
                case "MoveX":
                    return new MoveXShapeCommand(shape, GiveValueForFieldDouble());
                case "MoveY":
                    return new MoveYShapeCommand(shape, GiveValueForFieldDouble());
                case "Scale":
                    return new ScaleShapeCommand(shape, GiveValueForFieldDouble());
                default:
                    throw new ApplicationException(string.Format("Command'{0}' cannot be created", command));
            }
        }
        static void executeCommand(List<AbstractShape> shape)
        {
            Console.WriteLine("Execute Command");
            PickCommand(shape[IdNumber()]).Execute();
        }
        static void UnexecuteCommand(List<AbstractShape> shape)
        {
            Console.WriteLine("UnExecute Command");
            PickCommand(shape[IdNumber()]).UnExecute();
        }
        //helper Function to do the certain command picked previously
        static void DoCommand(List<AbstractShape> shape)
        {
            Console.WriteLine("On Which shape do you want to Do Manipulation/Command?");

            var managerCommand = new ShapeManager(shape[IdNumber()]);
            Console.WriteLine("Which command do you want to do");
            Console.WriteLine("Pick a Command to Do One of the Following:");
            Console.WriteLine("Color,MoveX,MoveY,Scale,UnDo,ReDo");
            string command = Console.ReadLine();
            string undoRedo;
            if (command == "Color")
            {
                managerCommand.Compute(CommandTypeEnum.SetColor, MakeColor());
                Console.WriteLine("You Changed the Color of the shape");
                Console.WriteLine("Do you want to Undo Or Redo Some Command? Yes/No");
                undoRedo = Console.ReadLine();
                if (undoRedo == "Yes")
                {
                    managerCommand.Undo();
                    Console.WriteLine("You undid the last command");
                }
               if(undoRedo == "No")
                {
                    Console.WriteLine("How many steps do you want to redo?");
                    managerCommand.Redo(Convert.ToInt32(GiveValueForFieldDouble()));
                }
            }
            if (command == "MoveX")
            {
                managerCommand.Compute(CommandTypeEnum.MoveX, GiveValueForFieldDouble());
                Console.WriteLine("You moved the X Coordinate of the shape");
                Console.WriteLine("Do you want to Undo Or Redo Some Command? Yes/No");
                undoRedo = Console.ReadLine();
                if (undoRedo == "Yes")
                {
                    managerCommand.Undo();
                    Console.WriteLine("You undid the last command");
                }
                if (undoRedo == "No")
                {
                    Console.WriteLine("How many steps do you want to redo?");
                    managerCommand.Redo(Convert.ToInt32(GiveValueForFieldDouble()));
                }
            }
            if (command == "MoveY")
            {
                managerCommand.Compute(CommandTypeEnum.MoveY, GiveValueForFieldDouble());
                Console.WriteLine("You moved the Y Coordinate of the shape");
                Console.WriteLine("Do you want to Undo Or Redo Some Command? Yes/No");
                undoRedo = Console.ReadLine();
                if (undoRedo == "Yes")
                {
                    managerCommand.Undo();
                    Console.WriteLine("You undid the last command");
                }
                if (undoRedo == "No")
                {
                    Console.WriteLine("How many steps do you want to redo?");
                    managerCommand.Redo(Convert.ToInt32(GiveValueForFieldDouble()));
                }
            }
            if (command == "Scale")
            {
                managerCommand.Compute(CommandTypeEnum.Scale, GiveValueForFieldDouble());
                Console.WriteLine("You used scale on shape");
                Console.WriteLine("Do you want to Undo Or Redo Some Command? Yes/No");
                undoRedo = Console.ReadLine();
                if (undoRedo == "Yes")
                {
                    managerCommand.Undo();
                    Console.WriteLine("You undid the last command");
                }
                if (undoRedo == "No")
                {
                    Console.WriteLine("How many steps do you want to redo?");
                    managerCommand.Redo(Convert.ToInt32(GiveValueForFieldDouble()));
                }
            }
            else
            Console.WriteLine("Command Has not been picked");
        }
        
        //Does List all the Spaes that are created with The build In Iterator Pattern 
        static void ListShapes(List<AbstractShape> shape)
        {
            foreach (var item in shape)
            {
                Console.WriteLine(item.ToString());
            }

        }
        //Does List all the Shapes that are created with the Iterator Pattern
        static void ListShapesWithIterator(AbstractShape shape)
        {
            MyIteratorClass iterator = shape.CreateIterator();
            iterator.Step = 1;
            Console.WriteLine("Iterating over collection:");
            for (AbstractShape item = iterator.First(); !iterator.IsDone(); item = iterator.Next())
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void RemoveItemFromList(List<AbstractShape> shape)
        {
            Console.WriteLine("Which shape do you want to remove?");
            shape.Remove(shape[IdNumber()]);
        }
        //Helper function to implented the repeating actions to Choose in order to do Something
        public List<AbstractShape> Action(List<AbstractShape> answer)
        {
            var continueWithAction = true;
            
            Console.WriteLine("Pick an action to do:");
            Console.WriteLine("Add Some Shape ,List Shapes,Delete Shape Copy Shape , Do manipulation on Shape , And Exit! ");
            Console.WriteLine("Respective Actions are : Shape, ListShapes ,Delete, Copy , Command,UnExecute,Execute,Exit ");
            string _doAction = Console.ReadLine();
            while (continueWithAction)
            {
                if (_doAction == "Exit")
                {
                    break;
                }
                else if (_doAction == "Shape")
                { 
                    answer.Add(PickAShape());
                    Action(answer);
                }
                else if (_doAction == "Copy")
                {
                    answer.Add(PickShapeToCopy(answer));
                    Action(answer);
                }
                else if (_doAction == "Command")
                {
                    DoCommand(answer);
                    Action(answer);
                }
                else if (_doAction == "Execute")
                {
                    executeCommand(answer);
                    Action(answer);
                }
                else if (_doAction == "UnExecute")
                {
                    UnexecuteCommand(answer);
                    Action(answer);
                }
                else if (_doAction == "ListShapes")
                {
                    ListShapes(answer);
                    Action(answer);
                }
                else if (_doAction == "Delete")
                {
                    RemoveItemFromList(answer);
                    Action(answer);
                }
                else
                {
                    Console.WriteLine("Gonna start Doing somethig Usefull now");
                }
            }
            return answer;
        }
    }
}
