/**** @author: Don England
	* @since: 20-Nov-2012
	*/

using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(LevelScript))]
public class LevelEditor : Editor {
	
	private SerializedObject level;
	private SerializedProperty width;
	private SerializedProperty height;
	
	void OnEnable(){
		level  = new SerializedObject(target);
		width  = level.FindProperty("width");
		height = level.FindProperty("height");
	}

	void OnSceneGUI(){
		// Call level update in scene view
		level.Update();
		
		// Properties to adjust
		
		// Handles--to wrap GUI controls--between .BeginGUI && .EndGUI
        Handles.color = Color.blue;
        Handles.BeginGUI();
			GUI.Box (new Rect(10, 10, 100,160), "Set Level Area");
			if(GUI.Button (new Rect (20,40,80,20), "Width ++"))
				width.intValue++;
			if(GUI.Button (new Rect (20,70,80,20), "Width --"))
				width.intValue--;		
			if(GUI.Button (new Rect (20,100,80,20), "Height ++"))
				height.intValue++;
			if(GUI.Button (new Rect (20,130,80,20), "Height --"))
				height.intValue--;		
		
			if(level.ApplyModifiedProperties()){
				((LevelScript)target).UpdateLevel();
			}
        Handles.EndGUI();
	}
}
