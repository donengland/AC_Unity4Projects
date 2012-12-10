using UnityEngine;
using System.Collections;

public class levelTransfer : MonoBehaviour {
	
	public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collide){
		Debug.Log(collide.name);
		if(collide.name.Equals("PlayerSphere")){
			Application.LoadLevel(nextLevel);
		}
	}
}
