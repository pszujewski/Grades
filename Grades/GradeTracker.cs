using System;
using System.IO;
using System.Collections;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        protected string _name = "Default Grade Book Name";

        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                // We need to announce here that the Name property 
                // is changing. This is a scenario for delegates
                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;
            }
        }


        // Other objects can walk up to this delegate and subscribe their methods
        // to it. Using "event" means clients of this class can only add or remove subscribers
        // to this delegate. They cannot simply assign directly a subscriber to the delegate.
        // This is the use of event keyword
        //
        public event NameChangedDelegate NameChanged;
    }
}
