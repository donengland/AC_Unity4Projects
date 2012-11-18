using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class LevelScript : MonoBehaviour {
	
	public int value = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("My Value: " + value);	
	}
}
