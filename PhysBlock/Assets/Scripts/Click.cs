using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		// This holds the info on what we hit
		RaycastHit hit;
		// find your camera and convert your mouse position to a ray
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
		//Camera.current.ScreenPointToRay(Input.mousePosition);
		// rayCast into the scene And require that something is hit has a transform
		if(Input.GetKeyDown (KeyCode.Space))
		{
			if (Physics.Raycast(ray, out hit, Mathf.Infinity) && hit.transform != null)
			{
				if(hit.collider.gameObject.name == "BaseCube")
				{
					//Debug.Log (hit.collider.gameObject.name);
					
					hit.collider.gameObject.SendMessage ("changeMagnetic");	
				}
			}
			
		}
	
	}
}
