using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (WaterGen))]
public class WaterGenEditor : Editor
{
    public override void OnInspectorGUI() 
    {
        WaterGen waterGen = (WaterGen)target;

        if (DrawDefaultInspector ())
        {
            if (waterGen.autoUpdate)
            {
                waterGen.GenerateWater();
            }
        }
        if (GUILayout.Button ("Generate"))
        {
            waterGen.GenerateWater();
        }
    }
}
