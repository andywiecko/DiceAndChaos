using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{
    public class SpecimenRoller
    {
        static public void Roll(Specimen specimen)
        {
            specimen.IsActive = true;
            specimen.Rigidbody.useGravity = true;
            specimen.Rigidbody.isKinematic = false;
        }
    }
}