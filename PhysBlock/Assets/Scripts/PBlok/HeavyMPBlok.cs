using UnityEngine;
using System.Collections;

public class HeavyMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public HeavyMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Heavy MPBlok");
	}
}
