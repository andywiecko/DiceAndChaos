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

        IEnumerator IERoll()
        {
            gameController.Roll();
            readyForRun = false;
            yield return new WaitUntil(()=>!gameController.IsActive());
            readyForRun = true;
            Debug.Log("done!");
        }

        public void StartUnpacking(Parameters parameters, List<FieldsHandler.Type> fieldTypes)
        {
            object[] parms = new object[2] { parameters, fieldTypes };
            StartCoroutine("Unpack",parms);
        }

        bool readyForRun = true;

        IEnumerator Unpack(object[] parms)
        {
            Parameters parameters = (Parameters)parms[0];
            List<FieldsHandler.Type> fieldTypes = (List<FieldsHandler.Type>) parms[1];
            foreach (List<float> parameter in parameters)
            {
                InitialConditions initialConditions = gameController.initialConditions;
                var merged = fieldTypes.Zip(parameter, (a, b) => Tuple.Create(a, b));

                foreach (var item in merged)
                {
                    var type = item.Item1;
                    var value = item.Item2;
                    InitialConditionSwitcher.SwitchFields(type, value, initialConditions);
                    gameController.initialConditions = initialConditions;
                    //yield return new WaitForSeconds(3);
                    yield return new WaitUntil(()=>readyForRun);
                    
                    StartCoroutine("IERoll");

                }

            }
        }
    }

}