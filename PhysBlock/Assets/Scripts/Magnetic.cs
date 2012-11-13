using UnityEngine;
using System.Collections;

public class Magnetic : MonoBehaviour {
	
	private bool colliding = false;
	private bool inTrigger;
	private bool islockedz = false;
	private bool islockedy = false;
	private Collider CurrentField;

	// Use this for initialization
	void Start () {
		
	
	}
	
	void Update()
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(!inTrigger)
		{
			gameObject.rigidbody.useGravity = true;
		}
		
		inTrigger = false;
	
	}
	
	
	void OnTriggerStay(Collider MagField)
	{
		inTrigger = true;
		if(MagField.name == "MagneticPullZ")
		{
			gameObject.rigidbody.useGravity = false;
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, MagField.attachedRigidbody.position, .01f);
			
		}
		if(MagField.name == "MagneticPullY")
		{
			gameObject.rigidbody.useGravity = false;
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, MagField.attachedRigidbody.position, .01f);
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
			
	}
	
	void OnCollisionExit(Collision col)
	{

	}
	
	
	public void LockTransform(Collider Field)
	{
	
	}
}
