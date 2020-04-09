using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DiceAndChaos
{
    using ParametersRangeTuple = Tuple<FieldsHandler.Type, ParameterRange>;

    public class Simulator : MonoBehaviour
    {

        public List<FieldsHandler> fieldsHandlers;

        private void Start()
        {
            ParameterRange vxRange = new ParameterRange(0.0f, 0.5f, 1.0f);
            ParameterRange vyRange = new ParameterRange(0.0f, 0.5f, 1.0f);
            ParameterRange vzRange = new ParameterRange(0.0f, 0.5f, 1.0f);

            List<ParameterRange> ranges = new List<ParameterRange>
            {
                vxRange,
                vyRange,
                vzRange
            };

            Parameters parameters = new Parameters(ranges);

            string log = "\n";
            foreach (List<float> current in parameters)
            {
                string row = "";
                foreach (float value in current)
                {
                    row += value.ToString() + "\t";
                }
                log += row + "\n";
            }


            Debug.Log(log);

        }

        void ParseField(FieldsHandler fieldsHandler,
                        List<ParametersRangeTuple> parameterRangeTuples)
        {
            if (fieldsHandler.ParseFields(out ParameterRange parameterRange))
                parameterRangeTuples.Add(new ParametersRangeTuple(fieldsHandler.type, parameterRange));

        }

        public void Simulate()
        {

            List<ParametersRangeTuple> parameterRangeTuples = new List<ParametersRangeTuple>();

            foreach (var fields in fieldsHandlers)
                ParseField(fields, parameterRangeTuples);


            List<ParameterRange> parameterRanges = new List<ParameterRange>();

            Parameters parameters = new Parameters(parameterRangeTuples);

            string log = "\n";
            foreach (List<float> current in parameters)
            {
                string row = "";
                foreach (float value in current)
                {
                    row += value.ToString() + "\t";
                }
                log += row + "\n";
            }
            Debug.Log(log);

        }


    }

}