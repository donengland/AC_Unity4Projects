/**** @author: Don England
	* @since: 20-Nov-2012
	*/

using System;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode, Serializable]
public class PBlok : MonoBehaviour {
	
	// =========
	// Enums from shared constants
	public  PBlokConstants.blokPotency myPotency  = PBlokConstants.blokPotency.modify;
	private PBlokConstants.blokPotency oldPotency = PBlokConstants.blokPotency.modify;
	public  PBlokConstants.blokAct myAct  = PBlokConstants.blokAct.empty;
	private PBlokConstants.blokAct oldAct = PBlokConstants.blokAct.empty;
	
	// Quick query for movement type if naming system gets implemented
	private PBlokConstants.blokAct standingOn = PBlokConstants.blokAct.empty;
	
	private IPBlokType myPBlok; // My current block implementation
	private Vector3 myTarget;   // target location for movement
	private float waitTime;     // wait time before moving to target
	
	private GameObject appearance;

	// Use this for initialization
	void Start () {
		changeInterface();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void FixedUpdate(){
		
	}
	void Awake(){
		if(Application.isPlaying){
			if(myAct == PBlokConstants.blokAct.empty)
				Destroy (gameObject);
			if( myAct == PBlokConstants.blokAct.block_normal ||
				myAct == PBlokConstants.blokAct.block_frozen ||
				myAct == PBlokConstants.blokAct.block_heavy){
				gameObject.AddComponent<Rigidbody>();
				rigidbody.constraints =  RigidbodyConstraints.FreezeRotationX
					| RigidbodyConstraints.FreezeRotationY
					| RigidbodyConstraints.FreezeRotationZ
					| RigidbodyConstraints.FreezePositionZ;
			}
			if(myAct == PBlokConstants.blokAct.block_death){
				collider.isTrigger = true;
				gameObject.AddComponent<PlayerReset>();
			}
		}
	}
	
	public void UpdateBlok(){
		if(myAct != oldAct || myPotency != oldPotency)
			changeInterface();
	}
	
	void changeInterface(){
		foreach(Transform child in transform){
			DestroyImmediate (child.gameObject);
		}
		
		// There are not this many different ways to behave,
		// only this many different ways to be seen		
		switch(myPotency){
			case PBlokConstants.blokPotency.modify:
				switch(myAct){
					case PBlokConstants.blokAct.block_heavy:
						appearance = Instantiate(Resources.Load("HeavyMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.block_normal:
						appearance = Instantiate(Resources.Load("NormalMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.empty:
						appearance = Instantiate(Resources.Load("EmptyMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.block_frozen:
						appearance = Instantiate(Resources.Load("FrozenMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_frozen:
						appearance = Instantiate(Resources.Load("FrozenMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_magnetic:
						appearance = Instantiate(Resources.Load("MagneticMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_normal:
						appearance = Instantiate(Resources.Load("NormalMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.block_death:
						appearance = Instantiate(Resources.Load("DeathNMPBlok", typeof(GameObject))) as GameObject;
						break;
					default:
						break;
				}
				break;
			case PBlokConstants.blokPotency.no_modify:
				switch(myAct){
					case PBlokConstants.blokAct.block_heavy:
						appearance = Instantiate(Resources.Load("HeavyNMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.block_normal:
						appearance = Instantiate(Resources.Load("NormalNMPBlok", typeof(GameObject))) as GameObject;
						break;
					// Duplicate case from modify branch
					case PBlokConstants.blokAct.empty:
						appearance = Instantiate(Resources.Load("EmptyMPBlok", typeof(GameObject))) as GameObject;
						break;
					// ^^
					case PBlokConstants.blokAct.block_frozen:
						appearance = Instantiate(Resources.Load("FrozenNMPBlok", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_frozen:
						appearance = Instantiate(Resources.Load("FrozenNMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_magnetic:
						appearance = Instantiate(Resources.Load("MagneticNMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.surface_normal:
						appearance = Instantiate(Resources.Load("NormalNMPSurf", typeof(GameObject))) as GameObject;
						break;
					case PBlokConstants.blokAct.block_death:
						appearance = Instantiate(Resources.Load("DeathNMPBlok", typeof(GameObject))) as GameObject;
						break;
					default:
						break;
				}
				break;
			default:
				break;
		}
		
		// Update previous instance
		oldAct = myAct;
		oldPotency = myPotency;
		// Ensure proper placement of new appearance, and child it
		appearance.transform.position = gameObject.transform.position;
		appearance.transform.parent = gameObject.transform;
		
		// add editor functionality callbacks via PBlokSwitcher
		appearance.AddComponent<PBlokSwitcher>();
	}
	
	void performGetType(){
		myPBlok.getType();
	}
	
	void setTarget(Vector3 target){
		myTarget = target;
	}
	
	// in-game change requests
	public void requestChangeAct(PBlokConstants.blokAct act){
		if(myPotency == PBlokConstants.blokPotency.modify){
			setAct (act);
		}
		else{
			Debug.Log("Invalid request for change on "
				+ gameObject.name + "from ( " + myAct + " )" + " to "
				+ "( " + act + " ) object unmodifiable");
		}
	}
	
	
	// editor has direct access -- but 'child' needs access
	public void setPotency(PBlokConstants.blokPotency potency){
		myPotency = potency;
		changeInterface();
	}
	public PBlokConstants.blokPotency getPotency(){
		return myPotency;
	}
	public void setAct(PBlokConstants.blokAct act){
		myAct = act;
		changeInterface();
	}
	public PBlokConstants.blokAct getAct(){
		return myAct;
	}
	
	void OnCollisionEnter(Collision col){
		Debug.Log(gameObject.transform.parent.gameObject.name + " is colliding with " +
			col.gameObject.transform.parent.gameObject.name);
	}
}
