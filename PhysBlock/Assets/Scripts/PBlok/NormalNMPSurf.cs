using UnityEngine;
using System.Collections;

public class NormalNMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public NormalNMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Normal NMPSurf");
	}
}
