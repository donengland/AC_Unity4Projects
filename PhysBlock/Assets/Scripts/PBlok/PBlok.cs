using UnityEngine;
using System.Collections;

public class PBlok : MonoBehaviour {
	
	// =========
	// Enums from shared constants
	private PBlokConstants.blokPotency myPotency  = PBlokConstants.blokPotency.modify;
	private PBlokConstants.blokPotency oldPotency = PBlokConstants.blokPotency.modify;
	private PBlokConstants.blokAct myAct  = PBlokConstants.blokAct.empty;
	private PBlokConstants.blokAct oldAct = PBlokConstants.blokAct.empty;
	
	// Quick query for movement type if naming system gets implemented
	private PBlokConstants.blokAct standingOn = PBlokConstants.blokAct.empty;
	
	private IPBlokType myPBlok; // My current block implementation
	private Vector3 myTarget;   // target location for movement
	private float waitTime;     // wait time before moving to target

	// Use this for initialization
	void Start () {
		//myPBlok = new IcyPBlok(gameObject);
		//gameObject.renderer.material = materialX;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void changeInterface(){
		// There are not this many different ways to behave,
		// only this many different ways to be seen
		switch(myPotency){
			case PBlokConstants.blokPotency.modify:
				switch(myAct){
					case PBlokConstants.blokAct.block_heavy:
						myPBlok = new HeavyMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.block_normal:
						myPBlok = new NormalMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.empty:
						myPBlok = new EmptyMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.block_frozen:
						myPBlok = new FrozenMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.surface_frozen:
						myPBlok = new FrozenMPSurf(gameObject);
						break;
					case PBlokConstants.blokAct.surface_magnetic:
						myPBlok = new MagneticMPSurf(gameObject);
						break;
					case PBlokConstants.blokAct.surface_normal:
						myPBlok = new NormalMPSurf(gameObject);
						break;
					default:
						break;
				}
				break;
			case PBlokConstants.blokPotency.no_modify:
				switch(myAct){
					case PBlokConstants.blokAct.block_heavy:
						myPBlok = new HeavyNMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.block_normal:
						myPBlok = new NormalNMPBlok(gameObject);
						break;
					// Duplicate case from modify branch
					case PBlokConstants.blokAct.empty:
						myPBlok = new EmptyMPBlok(gameObject);
						break;
					// ^^
					case PBlokConstants.blokAct.block_frozen:
						myPBlok = new FrozenNMPBlok(gameObject);
						break;
					case PBlokConstants.blokAct.surface_frozen:
						myPBlok = new FrozenNMPSurf(gameObject);
						break;
					case PBlokConstants.blokAct.surface_magnetic:
						myPBlok = new MagneticNMPSurf(gameObject);
						break;
					case PBlokConstants.blokAct.surface_normal:
						myPBlok = new NormalNMPSurf(gameObject);
						break;
					default:
						break;
				}
				break;
			default:
				break;
		}
	}
	
	void performGetType(){
		myPBlok.getType();
	}
	
	void setTarget(Vector3 target){
		myTarget = target;
	}
	
	// editor access only, gameplay 'should' not change potency
	void setPotency(PBlokConstants.blokPotency potency){
		myPotency = potency;
		changeInterface();
	}
	PBlokConstants.blokPotency getPotency(){
		return myPotency;
	}
	
	// in-game change requests
	void requestChangeAct(PBlokConstants.blokAct act){
		if(myPotency == PBlokConstants.blokPotency.modify){
			setAct (act);
		}
		else{
			Debug.Log("Invalid request for change on "
				+ gameObject.name
				+ "(" + act + ") object unmodifiable");
		}
	}
	// editor direct access
	void setAct(PBlokConstants.blokAct act){
		myAct = act;
		changeInterface();
	}
	PBlokConstants.blokAct getAct(){
		return myAct;
	}
}
