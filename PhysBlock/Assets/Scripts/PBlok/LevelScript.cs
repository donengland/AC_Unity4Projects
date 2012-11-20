/**** @author: Don England
	* @since: 20-Nov-2012
	*/

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
		// Sanity Check
		if(height <= 1)
			height = 1;
		if(width <= 1)
			width = 1;
		
		// Modified check
		if(width < lastWidth){
			for(int i = lastWidth; width <= i; i--){
				for(int j = 0; j <= lastHeight; j++){
					DestroyImmediate ((GameObject.Find("Cell"+i.ToString()+"-"+j.ToString())));
				}
			}
		}
		if(height < lastHeight){
			for(int j = lastHeight; height <= j; j--){
				for(int i = 0; i <= lastWidth; i++){
					DestroyImmediate ((GameObject.Find("Cell"+i.ToString()+"-"+j.ToString())));
				}
			}
		}
		CreateLevel();
	}
	
	void CreateLevel(){
		myPBloks = new List<GameObject>();
		for(int i = 0; i < width; i++){
			for(int j = 0; j < height; j++){
				GameObject cellObj;
				cellObj = GameObject.Find("Cell"+i.ToString() + "-" + j.ToString());
				if(cellObj != null){
					// Object already exists
				}else{
					cellObj = new GameObject("Cell" +i.ToString() + "-" + j.ToString());
					cellObj.transform.position = new Vector3(i,j,0);
					cellObj.transform.parent = gameObject.transform;
					GameObject tempObj = Instantiate(Resources.Load("PBlok", typeof(GameObject))) as GameObject;
					tempObj.transform.position = new Vector3(i,j,0);
					tempObj.transform.parent = cellObj.transform;
				}
				myPBloks.Add( cellObj );
			}
		}
		lastWidth  = width;
		lastHeight = height;		
	}
}
