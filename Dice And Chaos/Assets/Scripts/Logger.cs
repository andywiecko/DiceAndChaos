using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DiceAndChaos
{

    public class Logger
    {
        public static void Save(string content)
        {
            string path = "DiceAndChaos_Simulation_";
            string now = DateTime.Now.ToString("yyyy-dd-M-HH-mm-ss");
            path += now + ".txt";
            Debug.Log(path);


            //Write some text to the test.txt file
            //StreamWriter writer = new StreamWriter(path, true);
            //writer.WriteLine(content);
            //writer.Close();
        }
    }
}