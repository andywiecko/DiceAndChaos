using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulator 
{

}


/*
Vector3 angVel = initialAngularVelocity;
string result = $"{angVel.x} {angVel.y} {angVel.z} { maxname }";
Debug.Log(result);
Logger.Save(result);
if (angVel.y <= 5.0f) Simulate();
*/

/*
*  MOVE TO CLASS SIMULATOR!
public void Simulate()
{
    Time.maximumParticleDeltaTime = 0.03f;
    Time.timeScale = 100f;
    Time.maximumDeltaTime = 0.01f;
    ParameterRange vxRange = new ParameterRange(0.0f, 1.0f, 0.25f);
    ParameterRange vyRange = new ParameterRange(0.0f, 2.0f, 0.5f);
    ParameterRange vzRange = new ParameterRange(0.0f, 1.0f, 0.25f);

    List<ParameterRange> ranges = new List<ParameterRange>
    {
        vxRange,
        vyRange,
        vzRange
    };

    Parameters parameters = new Parameters(ranges);

    string log = "\n";
    foreach (List<float> current in parameters)
    {
        string row = "";
        foreach (float value in current)
        {
            row += value.ToString() + "\t";
        }
        log += row + "\n";
    }
}
*/
