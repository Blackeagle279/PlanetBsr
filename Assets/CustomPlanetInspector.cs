using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlanetBase))]
public class CustomPlanetInspector : Editor{

    public int elementNum;

    public override void OnInspectorGUI()
    {
        PlanetBase myTarget = (PlanetBase)target;

        EditorGUILayout.LabelField("Planet Color");
        myTarget.mainColor = EditorGUILayout.ColorField(myTarget.mainColor);

        EditorGUILayout.LabelField("");

        EditorGUILayout.BeginVertical("Box");
        myTarget.isHabitable = EditorGUILayout.BeginToggleGroup ("Habitable", myTarget.isHabitable);
        if (myTarget.isHabitable == false)
        {
            myTarget.fauna = false;
            myTarget.flora = false;
        }

        myTarget.flora = EditorGUILayout.BeginToggleGroup("Flora", myTarget.flora);

        if (myTarget.flora == false)
        {
            myTarget.fauna = false;
        }

        myTarget.fauna = EditorGUILayout.Toggle("Fauna", myTarget.fauna);

        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.EndToggleGroup();

        myTarget.hasWater = EditorGUILayout.Toggle("Water", myTarget.hasWater);
        myTarget.intelligentCreatures = EditorGUILayout.BeginToggleGroup("Intelligent Life", myTarget.intelligentCreatures);

        if(myTarget.intelligentCreatures == false)
        {
            myTarget.icPopulation = 0;
        }

        EditorGUILayout.LabelField("Amount of Intelligent Life");
        myTarget.icPopulation = EditorGUILayout.IntField(myTarget.icPopulation);

        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.EndVertical();

        EditorGUILayout.LabelField("");

        EditorGUILayout.BeginVertical("Box");

        EditorGUILayout.LabelField("Temperature Range in Celcius");
        EditorGUILayout.MinMaxSlider(ref myTarget.lowTemp, ref myTarget.highTemp, 1f, 100f);

        EditorGUILayout.BeginHorizontal();
        myTarget.lowTemp = EditorGUILayout.FloatField(myTarget.lowTemp);
        myTarget.highTemp = EditorGUILayout.FloatField(myTarget.highTemp);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.LabelField("Planet Revolution Time in Hours");
        myTarget.revolutionTime = EditorGUILayout.FloatField(myTarget.revolutionTime);
        if(myTarget.revolutionTime < 0)
        {
            myTarget.revolutionTime = 0;
        }

        EditorGUILayout.LabelField("Planet Orbit Time in Days");
        myTarget.orbitTime = EditorGUILayout.FloatField(myTarget.orbitTime);
        if (myTarget.orbitTime < 0)
        {
            myTarget.orbitTime = 0;
        }

        EditorGUILayout.LabelField("Radius of Planet in Miles");
        myTarget.planetSize = EditorGUILayout.IntField(myTarget.planetSize);

        EditorGUILayout.LabelField("Amount of Moons");
        myTarget.moonAmount = EditorGUILayout.IntField(myTarget.moonAmount);

        EditorGUILayout.LabelField("Lowest Elevation");
        myTarget.lowElevation = EditorGUILayout.FloatField(myTarget.lowElevation);
        EditorGUILayout.LabelField("Highest Elevation");
        myTarget.highElevation = EditorGUILayout.FloatField(myTarget.highElevation);

        EditorGUILayout.LabelField("Radiation Levels");
        myTarget.radiationAmount = EditorGUILayout.FloatField(myTarget.radiationAmount);

        serializedObject.Update();
        SerializedProperty myElem = serializedObject.FindProperty("mainElements");

        EditorGUILayout.PropertyField(myElem, true);
        serializedObject.ApplyModifiedProperties();

        EditorGUILayout.EndVertical();
        //base.OnInspectorGUI();
    }

}
