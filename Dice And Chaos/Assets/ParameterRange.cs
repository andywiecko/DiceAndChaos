using System;
using System.Collections;
using System.Collections.Generic;

public class ParameterRange : IEnumerable
{
    private readonly float start;
    private readonly float stop;
    private readonly float step;

    public IEnumerator enumerator;

    public ParameterRange(float _start, float _stop, float _step)
    {
        start = _start - _step;
        stop = _stop;
        step = _step;
        enumerator = new ParameterRangeEnumerator(_start, _stop, _step);
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

        public ParameterRangeEnumerator(float _start, float _stop, float _step)
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

