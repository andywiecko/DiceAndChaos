using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceAndChaos
{

    public class InitialConditions
    {

        public Vector3 Position { get; set; } = Vector3.zero;

        public Quaternion Rotation { get; set; } = Quaternion.identity;

        private Vector3 rotationVector;
        public Vector3 RotationVector
        {
            get => rotationVector;
            set
            {
                rotationVector = value;
                Rotation = Quaternion.Euler(rotationVector);
            }
        }

        public Vector3 Velocity { get; set; } = Vector3.zero;

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
            ret += $"{rotationVector.x} {rotationVector.y} {rotationVector.z} ";
            ret += $"{Velocity.x} {Velocity.y} {Velocity.z} ";
            ret += $"{AngularVelocity.x} {AngularVelocity.y} {AngularVelocity.z} ";
            return ret;
        }


    }
}

