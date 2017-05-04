using MultiplePatternsHomework.Shapes.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Commands
{
   public abstract class Command
    {
        protected AbstractShape _shape;

        public AbstractShape Shape
        {
            get { return _shape; }
            set { _shape = value; }
        }

        public abstract void Execute();
        public abstract void UnExecute();
    }
}
