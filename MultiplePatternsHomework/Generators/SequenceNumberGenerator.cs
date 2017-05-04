using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplePatternsHomework.Generators
{
    class SequenceNumberGenerator
    {
        private static SequenceNumberGenerator _instance;
        private int _sequenceNumber = 0;

        protected SequenceNumberGenerator()
        {
        }

        public static SequenceNumberGenerator GetInstance()
        {
            if (_instance == null)
                _instance = new SequenceNumberGenerator();

            return _instance;
        }

        public int SequenceNumber
        {
            get
            {
                return ++_sequenceNumber;
            }
        }
    }
}
