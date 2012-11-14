using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {
	
	private bool colliding = false;
	public string type1;
	private string type2;
	private string type3;
	// Use this for initialization
	void Start () {
	
		type1 = "normal";
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
		transform.localEulerAngles = new Vector3(0,0,0);	
	}

}
