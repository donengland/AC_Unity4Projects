using UnityEngine;
using System.Collections;

public class MagneticNMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public MagneticNMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Magnetic NMPSurf");
	}
}
