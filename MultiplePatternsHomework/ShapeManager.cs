using MultiplePatternsHomework.Commands;
using MultiplePatternsHomework.Enumerations;
using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework
{
    class ShapeManager
    {
        private AbstractShape _shape;
        private List<Command> _commands = new List<Command>();
        private int _current = 0;

        public ShapeManager(AbstractShape shape)
        {
            _shape = shape;
        }
        
        public void Compute(CommandTypeEnum commandType, double value)
        {
            Command command;
            switch(commandType)
            {
                case CommandTypeEnum.MoveX:
                    command = new MoveXShapeCommand(_shape, value);
                    break;
                case CommandTypeEnum.MoveY:
                    command = new MoveYShapeCommand(_shape, value);
                    break;
                case CommandTypeEnum.Scale:
                    command = new ScaleShapeCommand(_shape, value);
                    break;
                default:
                    throw new NotImplementedException("NOT DEFINED COMMAND TYPE!!");
            }

            command.Execute();

            _commands.Add(command);
            _current++;
        }

        public void Compute(CommandTypeEnum commandType, ColorEnum value)
        {
            if (commandType != CommandTypeEnum.SetColor)
                return;

            var command = new SetColorShapeCommand(_shape, value);

            command.Execute();

            _commands.Add(command);
            _current++;
        }

        public void Undo(int steps = 1)
        {
            var commandsForUndo = _commands
                                    .Skip(_commands.Count - steps)
                                    .Take(steps)
                                    .ToList();
            commandsForUndo.Reverse();

            foreach(var command in commandsForUndo)
            {
                if (_current == 0)
                    break;

                command.UnExecute();
                _current--;
            }
        }

        
        {
            if (steps > _commands.Count)
                steps = _commands.Count;

            var commandsForRedo = _commands
                                    .Skip(_commands.Count - steps)
                                    .Take(steps)
                                    .ToList();

            foreach(var command in commandsForRedo)
            {
                command.Execute();
                _current++;
            }
        }
    }
}
