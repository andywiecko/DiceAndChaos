using System;
using System.Collections;
using System.Collections.Generic;

namespace DiceAndChaos
{

    public class ParameterRange : IEnumerable
    {
        private readonly float start;
        private readonly float stop;
        private readonly float step;


        public IEnumerator enumerator;

        private int count;
        public int Count { get => count; set => count = value; }

        public ParameterRange(float _start, float _step, float _stop)
        {
            start = _start - _step;
            stop = _stop;
            step = _step;
            Count = (int)((stop - start) / step);
            enumerator = new ParameterRangeEnumerator(_start, _step, _stop);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return enumerator;
        }

        public void Reset()
        {
            enumerator.Reset();
        }

        public object GetCurrent()
        {
            return enumerator.Current;
        }

        public bool MoveNext()
        {
            return enumerator.MoveNext();
        }


        class ParameterRangeEnumerator : IEnumerator
        {
            private readonly float start;
            private readonly float stop;
            private readonly float step;

            public ParameterRangeEnumerator(float _start, float _step, float _stop)
            {
                start = _start;
                stop = _stop;
                step = _step;
                Current = start;
            }

            public float Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (Current < stop)
                {
                    Current += step;
                    return true;
                }
                else
                    return false;

            }

            public void Reset()
            {
                Current = start;
            }
        }

    }

}