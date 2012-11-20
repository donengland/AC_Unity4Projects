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
			((PBlokSwitcher)target).UpdateBlok();
		}
    
	}
	
	void OnSceneGUI(){
		// Call level update in scene view
		pblok.Update();
		
		// Properties to adjust
		
		// Handles--to wrap GUI controls--between .BeginGUI && .EndGUI
        Handles.color = Color.blue;
        Handles.BeginGUI();
			GUI.Box (new Rect(5, 5, 110,200), "Modifiable");
			GUI.Box (new Rect(10,25,100,175), "Blocks");
			if(GUI.Button (new Rect (20,45,80,20), "Empty")){
				act.intValue = (int)PBlokConstants.blokAct.empty;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (20,75,80,20), "Normal")){
				act.intValue = (int)PBlokConstants.blokAct.block_normal;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
			if(GUI.Button (new Rect (20,105,80,20), "Heavy")){
				act.intValue = (int)PBlokConstants.blokAct.block_heavy;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
			if(GUI.Button (new Rect (20,135,80,20), "Frozen")){
				act.intValue = (int)PBlokConstants.blokAct.block_frozen;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
			if(GUI.Button (new Rect (20,165,80,20), "Death")){
				act.intValue = (int)PBlokConstants.blokAct.block_death;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
		
			GUI.Box (new Rect(5, 205, 110,170), "Modifiable");
			GUI.Box (new Rect(10,225, 100,145), "Surfaces");
			if(GUI.Button (new Rect (20,245,80,20), "Empty")){
				act.intValue = (int)PBlokConstants.blokAct.empty;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (20,275,80,20), "Normal")){
				act.intValue = (int)PBlokConstants.blokAct.surface_normal;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
			if(GUI.Button (new Rect (20,305,80,20), "Magnetic")){
				act.intValue = (int)PBlokConstants.blokAct.surface_magnetic;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
			if(GUI.Button (new Rect (20,335,80,20), "Frozen")){
				act.intValue = (int)PBlokConstants.blokAct.surface_frozen;
				potency.intValue = (int)PBlokConstants.blokPotency.modify;
			}
		
			GUI.Box (new Rect(115, 5, 110,200), "Not Modifiable");
			GUI.Box (new Rect(120,25,100,175), "Block");
			if(GUI.Button (new Rect (130,45,80,20), "Empty")){
				act.intValue = (int)PBlokConstants.blokAct.empty;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,75,80,20), "Normal")){
				act.intValue = (int)PBlokConstants.blokAct.block_normal;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,105,80,20), "Heavy")){
				act.intValue = (int)PBlokConstants.blokAct.block_heavy;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,135,80,20), "Frozen")){
				act.intValue = (int)PBlokConstants.blokAct.block_frozen;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,165,80,20), "Death")){
				act.intValue = (int)PBlokConstants.blokAct.block_death;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
		
			GUI.Box (new Rect(115, 205, 110,170), "Not Modifiable");
			GUI.Box (new Rect(120,225, 100,145), "Surfaces");
			if(GUI.Button (new Rect (130,245,80,20), "Empty")){
				act.intValue = (int)PBlokConstants.blokAct.empty;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,275,80,20), "Normal")){
				act.intValue = (int)PBlokConstants.blokAct.surface_normal;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,305,80,20), "Magnetic")){
				act.intValue = (int)PBlokConstants.blokAct.surface_magnetic;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
			if(GUI.Button (new Rect (130,335,80,20), "Frozen")){
				act.intValue = (int)PBlokConstants.blokAct.surface_frozen;
				potency.intValue = (int)PBlokConstants.blokPotency.no_modify;
			}
		
			if(pblok.ApplyModifiedProperties()){
				((PBlokSwitcher)target).UpdateBlok();
			}
        Handles.EndGUI();
	}
}
