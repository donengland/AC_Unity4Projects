using UnityEngine;
using System.Collections;

public class introGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void activateGravity(){
		gameObject.rigidbody.useGravity = true;
	}
}
