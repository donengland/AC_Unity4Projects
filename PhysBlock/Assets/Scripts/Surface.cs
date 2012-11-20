using UnityEngine;
using System.Collections;

public class Surface : MonoBehaviour {
	
	private bool isMagnetic;
	private bool isFrozen;
	public Material Frozen;
	public Material Normal;

	// Use this for initialization
	void Start () {
		removeMagnetic ();
		isFrozen = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void changeFrozen()
	{
		if(isFrozen)
		{
			gameObject.renderer.material = Normal;
			isFrozen = false;
		}
		else
		{
			gameObject.renderer.material = Frozen;
			isFrozen = true;
		}
	}
	
	void changeMagnetic()
	{
		//Debug.Log("Changed Magnet");
		if(isMagnetic)
		{
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive (false);
				this.isMagnetic = false;
			}
		}
		
		else
		{
			//Destroy(gameObject.GetComponent<SurfaceMagnet>());
			foreach (Transform child in transform)
			{
				child.gameObject.SetActive (true);
				this.isMagnetic = true;
			}
		}
	}
	
	void removeMagnetic()
	{
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive (false);
			this.isMagnetic = false;
		}
	}
	
	void setTriggerInactive()
	{
		RaycastHit hit;
		
		Ray rayDown = new Ray (gameObject.transform.position, Vector3.down);
		Ray rayUp = new Ray (gameObject.transform.position, Vector3.up);
		Ray rayLeft = new Ray (gameObject.transform.position, Vector3.left);
		Ray rayRight = new Ray (gameObject.transform.position, Vector3.right);
		
		if (Physics.Raycast(rayDown, out hit, Mathf.Infinity) && hit.transform != null)
			{
				//Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.gameObject.name == "Cube")
				{
					hit.collider.gameObject.SendMessage ("triggerInactive");	
				}
			}
		if (Physics.Raycast(rayUp, out hit, Mathf.Infinity) && hit.transform != null)
			{
				//Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.gameObject.name == "Cube")
				{
					hit.collider.gameObject.SendMessage ("triggerInactive");	
				}
			}
		if (Physics.Raycast(rayLeft, out hit, Mathf.Infinity) && hit.transform != null)
			{
				//Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.gameObject.name == "Cube")
				{
					hit.collider.gameObject.SendMessage ("triggerInactive");	
				}
			}
		if (Physics.Raycast(rayRight, out hit, Mathf.Infinity) && hit.transform != null)
			{
				//Debug.Log (hit.collider.gameObject.name);
				if(hit.collider.gameObject.name == "Cube")
				{
					hit.collider.gameObject.SendMessage ("triggerInactive");	
				}
			}
	}
}
