using UnityEngine;
using System.Collections;

public class FrozenNMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public FrozenNMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Frozen NMPBlok");
	}
}
