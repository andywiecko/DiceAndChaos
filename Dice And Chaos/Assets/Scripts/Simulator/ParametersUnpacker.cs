using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace DiceAndChaos
{

    public class ParametersUnpacker : MonoBehaviour
    {

        static private GameController gameController;

        private void Start()
        {
            gameController = GetComponent<GameController>();
        }

        IEnumerator IERoll(object[] parms)
        {
            InitialConditions init = (InitialConditions)parms[0];
            gameController.initialConditions = init;
            gameController.Roll();
            readyForRun = false;
            yield return new WaitUntil(() => !gameController.IsActive());
            Debug.Log(init + gameController.Result);
            Logger.Save(init + gameController.Result);
            readyForRun = true;
        }

        public void StartUnpacking(Parameters parameters, List<FieldsHandler.Type> fieldTypes)
        {
            object[] parms = new object[2] { parameters, fieldTypes };
            StartCoroutine("Unpack", parms);
        }

        bool readyForRun = true;

        IEnumerator Unpack(object[] parms)
        {
            Parameters parameters = (Parameters)parms[0];
            List<FieldsHandler.Type> fieldTypes = (List<FieldsHandler.Type>)parms[1];
            foreach (List<float> parameter in parameters)
            {
                InitialConditions initialConditions = gameController.initialConditions;
                var merged = fieldTypes.Zip(parameter, (a, b) => Tuple.Create(a, b));

                foreach (var item in merged)
                {
                    var type = item.Item1;
                    var value = item.Item2;
                    InitialConditionSwitcher.SwitchFields(type, value, ref initialConditions);
                }

                object[] rollParms = new object[1] { initialConditions };
                StartCoroutine("IERoll", rollParms);
                yield return new WaitUntil(() => readyForRun);
            }
        }
    }

}