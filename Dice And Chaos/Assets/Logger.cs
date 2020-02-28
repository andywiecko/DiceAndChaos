using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logger 
{
    public static void Save(string content)
    {
        string path = Application.persistentDataPath + "/test.txt";
        Debug.Log(path);
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(content);
        writer.Close();
    }
}
