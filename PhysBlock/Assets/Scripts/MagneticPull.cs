using UnityEngine;
using System.Collections;

public class MagneticPull : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		
	}
	
	
	
	void OnTriggerStay(Collider col)
	{
		//Debug.Log (col.gameObject.name);
		Move move = col.gameObject.GetComponentInChildren<Move>();
		bool BlockMoving = move.isMoving;
		
		if(!BlockMoving && col.transform.position.y - transform.position.y < .01)
			{
				//Debug.Log (col.gameObject.name);
				Transform Target = transform.parent.gameObject.transform;
				col.gameObject.BroadcastMessage ("moveTo", Target);
			}
		
	}
	
	
}
