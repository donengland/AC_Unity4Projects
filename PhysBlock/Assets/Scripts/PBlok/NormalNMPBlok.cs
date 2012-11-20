using UnityEngine;
using System.Collections;

public class NormalNMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public NormalNMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Normal NMPBlok");
	}
}
