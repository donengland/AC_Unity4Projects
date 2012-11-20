using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
	
	private string Function;
	private GameObject HitHolder;
	
	// Use this for initialization
	void Start () {
		Function = "Magnet";
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown (KeyCode.Alpha1))
		{
			Function = "Magnet";
		}
		if(Input.GetKeyDown (KeyCode.Alpha2))
		{
			Function = "Frozen";
		}
		if(Input.GetKeyDown (KeyCode.Alpha3))
		{
			Function = "Heavy";
		}
		if(Input.GetKeyDown (KeyCode.Alpha4))
		{
			Function = "Light";
		}
		
		
		
		// This holds the info on what we hit
		RaycastHit hit;
		// find your camera and convert your mouse position to a ray
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
		//Camera.current.ScreenPointToRay(Input.mousePosition);
		// rayCast into the scene And require that something is hit has a transform
		if(Input.GetKey (KeyCode.Mouse0))
		{
			if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform != null)
			{
				
				
				if(HitHolder != hit.collider.gameObject)
				{
					if(Function == "Magnet")
					{
						hit.collider.gameObject.SendMessage ("changeMagnetic");	
					}
					if(Function == "Frozen")
					{
						hit.collider.gameObject.SendMessage ("changeFrozen");
					}
				}
				
				HitHolder = hit.collider.gameObject;
				
			}
			
		}
	
	}
}
