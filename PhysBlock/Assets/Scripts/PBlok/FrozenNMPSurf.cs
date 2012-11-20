using UnityEngine;
using System.Collections;

public class FrozenNMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public FrozenNMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Frozen NMPSurf");
	}
}
