using UnityEngine;
using System.Collections;

public class Surface : MonoBehaviour {
	
	private bool isMagnetic;

	// Use this for initialization
	void Start () {
		removeMagnetic ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	
	void changeMagnetic()
	{
		if(isMagnetic)
		{
			foreach (Transform child in transform)
			{
			    child.gameObject.SetActive(false);
				this.isMagnetic = false;
			}
		}
		
		else
		{
			foreach (Transform child in transform)
			{
			    child.gameObject.SetActive(true);
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
}
