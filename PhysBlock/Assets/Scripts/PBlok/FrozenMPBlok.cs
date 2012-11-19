using UnityEngine;
using System.Collections;

public class FrozenMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public FrozenMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Frozen MPBlok");
	}
}
