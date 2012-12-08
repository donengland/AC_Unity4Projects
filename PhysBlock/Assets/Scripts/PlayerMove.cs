using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	
	void Update () {
		
		if(Input.GetKeyUp (KeyCode.E))
		{
			Debug.Log ("Trying to call MoveTo");
			RaycastHit hit;
			Vector3 NewPosition = Vector3.zero;
			if (Physics.Raycast (transform.position, Vector3.right, out hit, 1f)) 
			{
				NewPosition = new Vector3(hit.collider.transform.position.x + 1f,
				hit.collider.transform.position.y,
				hit.collider.transform.position.z);
				
				hit.collider.gameObject.BroadcastMessage ("moveTo", NewPosition);
			
	    	}
			else if (Physics.Raycast (transform.position, Vector3.left, out hit, 1f)) 
			{
				NewPosition = new Vector3(hit.collider.transform.position.x - 1f,
				hit.collider.transform.position.y,
				hit.collider.transform.position.z);
		
				hit.collider.gameObject.BroadcastMessage ("moveTo", NewPosition);
	    	}
			else
			{
				Debug.Log ("No Raycast hit");
			}
			
			
		}
	
	}
}
