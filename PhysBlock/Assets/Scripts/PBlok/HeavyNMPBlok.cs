using UnityEngine;
using System.Collections;

public class HeavyNMPBlok : IPBlokType {
	
	private GameObject myObject;
	
	public HeavyNMPBlok(GameObject target){
		myObject = target;
	}
	
	public void getType(){
		Debug.Log("Heavy NMPBlok");
	}
}
