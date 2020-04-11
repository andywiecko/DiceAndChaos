using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DiceAndChaos
{

    public class Logger
    {

        public static string path;

        private static void ResetPath()
        {
            path = "DiceAndChaos_Simulation_";
            string now = DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss");
            path += now + ".txt";
        }

        public static void CreateLogfile()
        {
            ResetPath();
            Save(InitialConditions.ToStringHeader());
        }


        public static void Save(string content)
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(content);
            writer.Close();
        }
    }
}