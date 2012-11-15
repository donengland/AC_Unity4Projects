using UnityEngine;
using System.Collections;

public class PBlok : MonoBehaviour {
	
	private IPBlokType myPBlok; // My current block type
	private Vector3 myTarget;   // target location for movement
	private float waitTime;     // wait time before moving to target

	// Use this for initialization
	void Start () {
		myPBlok = new IcyPBlok();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void performGetType(){
		myPBlok.GetType();
	}
	
	void setTarget(Vector3 target){
		myTarget = target;
	}
}
