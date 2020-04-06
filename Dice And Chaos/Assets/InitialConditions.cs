﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditions
    {
        [SerializeField]
        public Vector3 Position { get; set; } = Vector3.zero;
        [SerializeField]
        public Quaternion Rotation { get; set; } = Quaternion.identity;
        [SerializeField]
        public Vector3 Velocity { get; set; } = Vector3.zero;
        [SerializeField]
        public Vector3 AngularVelocity { get; set; } = Vector3.zero;

        public InitialConditions()
        {
            
        }

    }
}
