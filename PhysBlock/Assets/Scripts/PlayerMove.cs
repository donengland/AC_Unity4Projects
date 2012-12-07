using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Debug.DrawRay(transform.position, Vector3.forward, Color.green);
		
		if(Input.GetKeyDown (KeyCode.E))
		{
			RaycastHit hit;
			Vector3 NewPosition = Vector3.zero;
			if (Physics.Raycast (transform.position, Vector3.right, out hit, 1f)) 
			{
				NewPosition = new Vector3(hit.collider.transform.position.x + 1f,
				hit.collider.transform.position.y,
				hit.collider.transform.position.z);
				
				hit.collider.gameObject.BroadcastMessage ("moveTo", NewPosition);
	    	}
			
			if (Physics.Raycast (transform.position, Vector3.left, out hit, 1f)) 
			{
				NewPosition = new Vector3(hit.collider.transform.position.x - 1f,
				hit.collider.transform.position.y,
				hit.collider.transform.position.z);
		
				hit.collider.gameObject.BroadcastMessage ("moveTo", NewPosition);
	    	}
			
		}
	
	}
}
