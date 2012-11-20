using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour {
	
	private bool inTrigger;
	private int triggerCount;
	private bool isLocked;
	private bool iscolliding;
	
	private bool wasPainted;

	// Use this for initialization
	void Start () {
		
		triggerCount = 0;
		wasPainted = false;
	
	}
	
	void Update()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		//Debug.Log (triggerCount);
		//Debug.Log (gameObject.transform.position);
		
		if(!inTrigger)
		{
			if(gameObject.rigidbody.useGravity == false)
			{
				gameObject.rigidbody.useGravity = true;
			}
		}
		
		inTrigger = false;
	
	}
	
	void OnTriggerEnter(Collider MagField)
	{
		triggerCount = triggerCount + 1;
	}
	
	void OnTriggerExit(Collider MagField)
	{
		triggerCount = triggerCount - 1;
		isLocked = false;
	}
	
	void triggerInactive()
	{
		//Debug.Log ("triggerInactive called");
		triggerCount = triggerCount - 1;
		isLocked = false;
	}
	
	
	void OnTriggerStay(Collider MagField)
	{
		inTrigger = true;
		if(isLocked)
		{
			gameObject.rigidbody.useGravity = false;
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, MagField.transform.position, .01f);
		}
		else
		{
			gameObject.rigidbody.useGravity = false;
			
			if(MagField.name == "MagneticPullY")
			{
				if(gameObject.transform.position.x == MagField.transform.position.x)
				{
					isLocked = true;
				}
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position,
					new Vector3(MagField.transform.position.x, gameObject.transform.position.y,
					gameObject.transform.position.z), .01f);
			}
			
			if(MagField.name == "MagneticPullX")
			{
				if(gameObject.transform.position.y == MagField.transform.position.y)
				{
					isLocked = true;
				}
				gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position,
					new Vector3(gameObject.transform.position.x, MagField.transform.position.y,
					gameObject.transform.position.z), .01f);
			}
		}
	}
	
	void OnCollisionEnter(Collision surface)
	{
		iscolliding = true;
	}
	
	
	void OnCollisionExit(Collision surface)
	{
		iscolliding = false;
	}
	

	
	
	
}
