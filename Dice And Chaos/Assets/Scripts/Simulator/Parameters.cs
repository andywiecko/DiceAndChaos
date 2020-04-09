using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{
    using ParametersRangeTuple = Tuple<FieldsHandler.Type, ParameterRange>;

    public class Parameters : IEnumerable
    {

        private readonly List<ParameterRange> parameterRanges;

        public Parameters(List<ParameterRange> _parameterRanges)
        {
            parameterRanges = _parameterRanges;
        }

        public Parameters(List<ParametersRangeTuple> tuples)
        {
            List<ParameterRange> _parameterRanges = new List<ParameterRange>();
            foreach(var tuple in tuples)
            {
                _parameterRanges.Add(tuple.Item2);
            }
            parameterRanges = _parameterRanges;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ParametersEnumerator(parameterRanges);
        }

    }

    class ParametersEnumerator : IEnumerator
    {
        List<ParameterRange> parameterRanges;
        public ParametersEnumerator(List<ParameterRange> _parameterRanges)
        {
            parameterRanges = _parameterRanges;
            Current = new List<float>();
            GetCurrent();
        }

        private void GetCurrent()
        {
            List<float> newCurrent = new List<float>();
            foreach (ParameterRange range in parameterRanges)
            {
                newCurrent.Add((float)range.GetCurrent());
            }
            Current = newCurrent;
        }


        public List<float> Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        int index = 0;
        public bool MoveNext()
        {
            if (index > 0)
            {
                foreach (ParameterRange range in parameterRanges)
                {
                    if (range.MoveNext())
                    {
                        GetCurrent();
                        return true;
                    }
                    else range.Reset();
                }
                GetCurrent();
                return false;
            }
            else
            {
                index++;
                GetCurrent();
                return true;
            }

        }

        public void Reset()
        {
            foreach (ParameterRange range in parameterRanges)
            {
                range.Reset();
            }
            GetCurrent();
        }
    }

}