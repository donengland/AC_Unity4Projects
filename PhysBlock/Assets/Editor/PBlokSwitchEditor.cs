using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PBlokSwitcher))]
public class PBlokSwitchEditor : Editor {
	
	private SerializedObject pblok;
	private SerializedProperty potency;
	private SerializedProperty act;
	
	void OnEnable(){
		pblok   = new SerializedObject(target);
		potency = pblok.FindProperty("myPotency");
		act     = pblok.FindProperty("myAct");
	}

	public override void OnInspectorGUI(){
		// Call level update in scene view
		pblok.Update();
		
		// Properties to adjust
		EditorGUILayout.PropertyField(potency);
		EditorGUILayout.PropertyField(act);
	
		if(pblok.ApplyModifiedProperties()){
			((PBlok)target).UpdateBlok();
		}
    
	}
}
