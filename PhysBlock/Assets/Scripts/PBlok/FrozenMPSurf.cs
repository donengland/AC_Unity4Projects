using UnityEngine;
using System.Collections;

public class FrozenMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public FrozenMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Frozen MPSurf");
	}
}
