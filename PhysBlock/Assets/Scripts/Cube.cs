using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	
	private bool colliding = false;
	public string weight;
	
	// Use this for initialization
	void Start () {
	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		transform.localEulerAngles = new Vector3(0,0,0);	
	}
	
	void changeMagnetic()
	{
		
	}

}
