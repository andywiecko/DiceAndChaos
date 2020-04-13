using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{

    public class SpecimenSelector : MonoBehaviour
    {

        public GameController gameController;
        private Dropdown dropdown;

        public GameObject D6;
        public GameObject D12;

        // Start is called before the first frame update
        void Start()
        {
            dropdown = GetComponent<Dropdown>();
        }

        public void SelectSpecimen()
        {
            int index = dropdown.value;
            string selected = dropdown.options[index].text;
            GameObject specimenToSpawn;
            switch(selected)
            {
                case "D6 Dice":
                    specimenToSpawn = D6;
                    break;
                case "D12 Dice":
                    specimenToSpawn = D12;
                    break;
                default:
                    specimenToSpawn = D6;
                    break;
            }
            gameController.specimenGameObject = specimenToSpawn;
        }
        
    }

}