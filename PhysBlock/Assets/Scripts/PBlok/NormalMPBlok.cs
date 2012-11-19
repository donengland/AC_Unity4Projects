using UnityEngine;
using System.Collections;

public class NormalMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public NormalMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Normal MPBlok");
	}
}
