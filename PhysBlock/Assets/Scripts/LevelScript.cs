using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode, Serializable]
public class LevelScript : MonoBehaviour {
	
	public int width  = 3;
	public int height = 3;
	
	private int lastWidth  = 3;
	private int lastHeight = 3;
	
	public List<GameObject> myPBloks;

	// Use this for initialization
	void Start () {
		CreateLevel();
	}
	
	// Update is called once per frame
	void Update(){
	}
	
	void OnEnable(){
		UpdateLevel ();
	}
	
	void OnDisable(){
		if(Application.isEditor){
			foreach (GameObject element in myPBloks){
				DestroyImmediate (element);
			}
			myPBloks   = null;
			lastWidth  = 0;
			lastHeight = 0;
		}
	}
	
	public void UpdateLevel () {
		if( (myPBloks == null) || (width != lastWidth) || (height != lastHeight)){
			foreach (GameObject element in myPBloks){
				DestroyImmediate (element);
			}
			CreateLevel();
		}
	}
	
	void CreateLevel(){
		myPBloks = new List<GameObject>();
		for(int i = 0; i < width; i++){
			for(int j = 0; j < height; j++){
				GameObject tempObj;
				tempObj = GameObject.Find("Cell"+i.ToString() + j.ToString());
				if(tempObj != null){
					// Object already exists
				}else{
					tempObj = Instantiate(Resources.Load("PBlok", typeof(GameObject))) as GameObject;
					tempObj.name = "Cell" +i.ToString() + j.ToString();
					tempObj.transform.position = new Vector3(i,j,0);
					tempObj.transform.parent = gameObject.transform;
				}
				myPBloks.Add( tempObj );
			}
		}
		lastWidth  = width;
		lastHeight = height;		
	}
}
