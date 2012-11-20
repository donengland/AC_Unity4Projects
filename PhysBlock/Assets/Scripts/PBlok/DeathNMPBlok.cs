using UnityEngine;
using System.Collections;

public class DeathNMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public DeathNMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Death MPBlok");
	}
}
