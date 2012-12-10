using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	
	private PBlokConstants.blokAct FunctionS;
	private PBlokConstants.blokAct FunctionB;
	private GameObject HitHolder;
	
	// Use this for initialization
	void Start () {
		FunctionS = PBlokConstants.blokAct.surface_magnetic;
		FunctionB = PBlokConstants.blokAct.block_frozen;
	}
	
	// Update is called once per frame
	void Update () {
		
		// This holds the info on what we hit
		RaycastHit hit;
		// find your camera and convert your mouse position to a ray
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
		if(Input.GetKeyUp (KeyCode.Mouse0))
		{
			if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform != null)
			{
				Debug.Log (hit.collider.name);
				if(hit.collider.gameObject.name == "PBlok(Clone)")
				{
					if(hit.collider.GetComponent<PBlok>().getPotency() == PBlokConstants.blokPotency.modify)
					{
						
						switch(hit.collider.GetComponent<PBlok>().getAct ())
						{
							case PBlokConstants.blokAct.block_frozen:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionB);
								break;
							case PBlokConstants.blokAct.block_heavy:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionB);
								break;
							case PBlokConstants.blokAct.block_normal:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionB);
								break;
							case PBlokConstants.blokAct.surface_frozen:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionS);
								break;
							case PBlokConstants.blokAct.surface_magnetic:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionS);
								break;
							case PBlokConstants.blokAct.surface_normal:
								hit.collider.GetComponent<PBlok>().requestChangeAct (FunctionS);
								break;
							default:
								Debug.Log ("Default case called in Click");
								break;
						}
					}
				}
			}
		}
			
	
	
	}
	
	void OnGUI () {
		if (GUI.Button (new Rect (200, 300, 120, 40), "Magnetic")) {
			FunctionS = PBlokConstants.blokAct.surface_magnetic;
		}
		
		if (GUI.Button (new Rect(320, 300, 120, 40), "Frozen")){
			FunctionS = PBlokConstants.blokAct.surface_frozen;
			FunctionB = PBlokConstants.blokAct.block_frozen;
		}
		if (GUI.Button (new Rect(440, 300, 120, 40), "Heavy")){
			FunctionB = PBlokConstants.blokAct.block_heavy;
		}
		if (GUI.Button (new Rect(560, 300, 120, 40), "Normal")){
			FunctionS = PBlokConstants.blokAct.surface_normal;
			FunctionB = PBlokConstants.blokAct.block_normal;
		}
	}
	
}
