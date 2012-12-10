using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagneticPull : MonoBehaviour {
	
	
	private List<Collider> ColliderList;
	
	// Use this for initialization
	void Start () {
		ColliderList = new List<Collider>();
	}
	
	// Update is called once per frame
	void Update () {
		

	}
	
	void OnTriggerEnter(Collider col)
	{
		
	}
	
	
	void OnTriggerStay(Collider col)
	{
		if(col.name == "PBlok(Clone)")
		{
			Debug.Log ("Has entered OnTriggerStay");
			Move move = col.gameObject.GetComponentInChildren<Move>();
			
			if(!move.getisInMagnet())
			{
				Vector3 Target = transform.parent.gameObject.transform.position;
				ColliderList.Add (col);
				col.gameObject.BroadcastMessage ("moveTo", Target);
				col.rigidbody.isKinematic = true;
			}
			
			
			move.setMagnetTrue();
			
			if(!(Mathf.Abs (transform.position.y - col.transform.position.y) <.01))
			{
				col.transform.position = Vector3.MoveTowards (col.transform.position, new Vector3(
					col.transform.position.x,
					transform.position.y,
					col.transform.position.z),1f);
			}
			
		}
		
		
	}
	
	void OnTriggerExit(Collider col)
	{
		
	}
	
	void OnDestroy()
	{
		Debug.Log ("On Destroy Called");
		ColliderList.ForEach(OnTriggerExit);
	}
	
	
	
}
