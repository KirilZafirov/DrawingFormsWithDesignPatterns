using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiplePatternsHomework.Enumerations;
using MultiplePatternsHomework.Generators;
using MultiplePatternsHomework.Observers.Abstractions;
using MultiplePatternsHomework.Commands;
using MultiplePatternsHomework.Observers;
using System.Collections;
using MultiplePatternsHomework.Iterator;
using MultiplePatternsHomework.IteratorsPattern;

namespace MultiplePatternsHomework.Shapes.Abstractions
{
 
    public abstract class AbstractShape : IShape, IAbstractCollection
    {
        #region PROPERTIES
        protected int? _id;
        protected ColorEnum _color;
        private double x = 0, y = 0;
        public int Id
        {
            get
            {
                if (_id == null)
                    _id = SequenceNumberGenerator.GetInstance().SequenceNumber;

                return _id.Value;
            }
        }

        public virtual double X
        {
            get
            {

                return x;
            }
            set
            {
                if (value < 0)
                {
                    x = 0;
                }
                else if (value > 800)
                {
                    x = 800;
                }
                else
                    x = value;
            }
        }

        public virtual double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0)
                {
                    y = 0;
                }
                else if (value > 800)
                {
                    y = 800;
                }
                else
                    y = value;
            }
        }

        private bool _isClone;
        private bool _isDeleted;
        public bool IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }
        public bool IsClone
        {
            get { return _isClone; }
            set { _isClone = value; }
        }

        public virtual ColorEnum Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

                var setColorShapeCommand = new SetColorShapeCommand(value);
                Notify(setColorShapeCommand);
            }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion

        public abstract void Scale(double factor);

        public virtual AbstractShape Clone(double deltaX, double deltaY)
        {
            var clone = (AbstractShape)this.MemberwiseClone();

            this._id = null;

            clone.descendantShapeObservers = new List<IDescendantShapeObserver>();
            clone.IsClone = true;
            clone.MoveX(deltaX);
            clone.MoveY(deltaY);
            
            var descendantShapeObserver = new DescendantShapeObserver(clone);
            this.descendantShapeObservers.Add(descendantShapeObserver);
        
            return clone;
        }
       
        public virtual void MoveX(double deltaX)
        {
            X += deltaX;

            var moveXShapeCommand = new MoveXShapeCommand(deltaX);
            Notify(moveXShapeCommand);
        }

        public virtual void MoveY(double deltaY)
        {
            Y += deltaY;

            var moveXShapeCommand = new MoveYShapeCommand(deltaY);
            Notify(moveXShapeCommand);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(String.Format("Id: {0}", Id));
            sb.AppendLine(String.Format("X: {0}", X));
            sb.AppendLine(String.Format("Y: {0}", Y));
            sb.AppendLine(String.Format("Is Clone: {0}", IsClone));
            sb.AppendLine(String.Format("Is Deleted: {0}", IsDeleted));
            sb.Append(String.Format("Color: {0}", Color.ToString()));
            return sb.ToString();
        }
        #region Iterator
        private ArrayList _items = new ArrayList();

        public MyIteratorClass CreateIterator()
        {
            return new MyIteratorClass(this);
        }

        // Gets item count
        public int Count
        {
            get { return _items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value); }
        }
        #endregion

        #region Observable

        public List<IDescendantShapeObserver> descendantShapeObservers = new List<IDescendantShapeObserver>();

        public void Attach(IDescendantShapeObserver observer)
        {
            descendantShapeObservers.Add(observer);
        }

        public void Detach(IDescendantShapeObserver observer)
        {
            descendantShapeObservers.Remove(observer);
        }

        public void Notify(Command command)
        {
            descendantShapeObservers.ForEach(x => x.Update(command));
        }

        #endregion
    }
}
