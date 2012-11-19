using UnityEngine;
using System.Collections;

public class EmptyMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public EmptyMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Empty MPBlok");
	}
}
