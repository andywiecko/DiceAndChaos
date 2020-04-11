using System.Collections;
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
        
        // TODO automate the header and ToString
        public static string ToStringHeader()
        {
            return "#PosX PosY PosZ VelX VelY VelZ AngVelX AngVelY AngVelZ Result";
        }

        public override string ToString()
        {
            
            string ret = "";
            ret += $"{Position.x} {Position.y} {Position.z} ";
            ret += $"{Rotation.eulerAngles.x} {Rotation.eulerAngles.y} {Rotation.eulerAngles.z} ";
            ret += $"{Velocity.x} {Velocity.y} {Velocity.z} ";
            ret += $"{AngularVelocity.x} {AngularVelocity.y} {AngularVelocity.z} ";
            return ret;
        }


    }
}

