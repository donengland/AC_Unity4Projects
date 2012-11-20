/**** @author: Don England
	* @since: 20-Nov-2012
	*/

using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode, Serializable]
public class PBlokSwitcher : MonoBehaviour {	
	
	public  PBlokConstants.blokPotency myPotency  = PBlokConstants.blokPotency.modify;
	public  PBlokConstants.blokAct myAct  = PBlokConstants.blokAct.empty;
	
	private PBlok myPBlok;

	// Use this for initialization
	void Start () {
		myPBlok = transform.parent.gameObject.GetComponent<PBlok>();
	}
	
	// Update is called once per frame
	void Update () {
		//myPBlok.requestChangeAct(myAct);
	}
	
	public void UpdateBlok(){
		myPBlok.setAct(myAct);
		myPBlok.setPotency(myPotency);
	}
}
