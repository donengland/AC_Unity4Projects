using UnityEngine;
using System.Collections;

public class MagneticPull : MonoBehaviour {
	
	
	private bool flag;
	// Use this for initialization
	void Start () {
		flag = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col)
	{
		col.transform.gameObject.rigidbody.useGravity = false;
	}
	
	void OnTriggerStay(Collider col)
	{
		if(flag && col.transform.position.y - transform.position.y < .01)
		{
			Debug.Log (col.gameObject.name);
			GameObject Target = transform.parent.gameObject;
			col.gameObject.BroadcastMessage ("moveTo", Target);
			flag = false;
		}
	}
	
	
}
