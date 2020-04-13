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

        private ParametersUnpacker parametersUnpacker;


        private void Start()
        {
            parametersUnpacker = GetComponent<ParametersUnpacker>();
        }

        void ParseField(FieldsHandler fieldsHandler,
                        List<ParametersRangeTuple> parameterRangeTuples)
        {
            if (fieldsHandler.ParseFields(out ParameterRange parameterRange))
                parameterRangeTuples.Add(new ParametersRangeTuple(fieldsHandler.type, parameterRange));

        }

        public void Simulate()
        {
            StopSimulation();
            var parameterRangeTuples = new List<ParametersRangeTuple>();
            var fieldTypes = new List<FieldsHandler.Type>();

            foreach (var fields in fieldsHandlers)
                ParseField(fields, parameterRangeTuples);

            foreach (var tuple in parameterRangeTuples)
                fieldTypes.Add(tuple.Item1);

            Parameters parameters = new Parameters(parameterRangeTuples);
            Logger.CreateLogfile();
            parametersUnpacker.StartUnpacking(parameters, fieldTypes);
        }

        public void StopSimulation()
        {
            parametersUnpacker.Reset();
            parametersUnpacker.StopAllCoroutines();
        }

    }

}