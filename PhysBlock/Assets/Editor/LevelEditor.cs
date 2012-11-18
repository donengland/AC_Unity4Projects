using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(LevelScript))]
public class LevelEditor : Editor {
	
	private SerializedObject level;
	private SerializedProperty value;
	
	void OnEnable(){
		level = new SerializedObject(target);
		value = level.FindProperty("value");
	}

	void OnSceneGUI(){
		// Call level update in scene view
		level.Update();
		
		// Properties to adjust
		
		// Handles--to wrap GUI controls--between .BeginGUI && .EndGUI
        Handles.color = Color.blue;
        Handles.BeginGUI();
			GUI.Box (new Rect(10, 10, 90,100), "Reset Area");
			if(GUI.Button (new Rect (20,40,80,20), "value += 1"))
				value.intValue++;
			if(GUI.Button (new Rect (20,70,80,20), "value += 2"))
				value.intValue += 2;		
		
			level.ApplyModifiedProperties();
        Handles.EndGUI();
	}
}
