using UnityEngine;
using System.Collections;

public class NormalMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public NormalMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Normal MPSurf");
	}
}
