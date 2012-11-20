using UnityEngine;
using System.Collections;

public class MagneticMPSurf : IPBlokType {
	
	private GameObject myObject;
	
	public MagneticMPSurf(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Magnetic MPSurf");
	}
}
