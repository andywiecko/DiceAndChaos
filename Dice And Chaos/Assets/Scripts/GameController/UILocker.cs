using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DiceAndChaos
{
    public class UILocker : MonoBehaviour
    {

        // TODO uniform the List<>
        public List<Slider> sliders;
        public List<Button> buttons;
        public List<Toggle> toggles;
        public List<Dropdown> dropdowns;
        public List<FieldsHandler> fieldsHandlers;

        public void Lock()
        {
            foreach (var slider in sliders)
                slider.interactable = false;
            foreach (var button in buttons)
                button.interactable = false;
            foreach (var togle in toggles)
                togle.interactable = false;
            foreach (var dropdown in dropdowns)
                dropdown.interactable = false;
            foreach (var fieldsHandler in fieldsHandlers)
                fieldsHandler.Lock();
        }

        public void Unlock()
        {
            foreach (var slider in sliders)
                slider.interactable = true;
            foreach (var button in buttons)
                button.interactable = true;
            foreach (var togle in toggles)
                togle.interactable = true;
            foreach (var dropdown in dropdowns)
                dropdown.interactable = true;
            foreach (var fieldsHandler in fieldsHandlers)
                fieldsHandler.Unlock();
        }


    }
}