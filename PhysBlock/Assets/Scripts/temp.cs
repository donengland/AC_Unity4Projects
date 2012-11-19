using UnityEngine;
using System.Collections;

public class temp : MonoBehaviour {
	
	private GameObject myChild;

	// Use this for initialization
	void Start () {
		myChild = Instantiate(Resources.Load("IceCube", typeof(GameObject))) as GameObject;
		myChild.transform.position = gameObject.transform.position;
		myChild.transform.parent = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			Destroy(myChild);
			myChild = Instantiate (Resources.Load("GreenCube", typeof(GameObject))) as GameObject;
			myChild.transform.position = gameObject.transform.position;
			myChild.transform.position += new Vector3 (1,1,1);
			myChild.transform.parent = gameObject.transform;
		}
	}
}
